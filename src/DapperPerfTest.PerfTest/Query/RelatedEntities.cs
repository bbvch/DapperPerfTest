using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Dapper;

namespace DapperPerfTest.PerfTest.Query
{
    public class RelatedEntities : PerfTestBase
    {
        private const int ProductId = 75;

        [Benchmark(Baseline = true)]
        public IReadOnlyCollection<EndangeredCustomer> Dapper()
        {
            const string Sql = @"
                SELECT c.CustomerId, c.ContactName, c.Phone, o.OrderId, od.UnitPrice * od.Quantity AS Total FROM
                Customers c JOIN
                Orders o ON c.CustomerID = o.CustomerID JOIN
                [Order Details] od ON o.OrderID = od.OrderId
                WHERE od.ProductId = @prodID";
            var customers = this.DbConnection
                .Query<dynamic, dynamic, EndangeredCustomer>(
                    Sql,
                    (customer, order) => new EndangeredCustomer
                    {
                        CustomerId = customer.CustomerId,
                        Name = customer.ContactName,
                        Phone = customer.Phone,
                        OrderIds = new int[] { order.OrderId },
                        TotalAmount = order.Total
                    },
                    new { prodId = ProductId },
                    splitOn: "OrderId")
                .GroupBy(_ => _.CustomerId).Select(endangeredCustomers =>
            {
                var customer = endangeredCustomers.First();
                customer.OrderIds = endangeredCustomers.SelectMany(_ => _.OrderIds!).ToList();
                customer.TotalAmount = endangeredCustomers.Select(_ => _.TotalAmount).Sum();
                return customer;
            }).ToList();
            return customers;
        }

        [Benchmark]
        public IReadOnlyCollection<EndangeredCustomer> EfCore()
        {
            var customerQuery =
                from c in this.EfContext.Customers
                let affectedOrders = c.Orders.SelectMany(o => o.OrderDetails.Where(_ => _.ProductId == ProductId))
                where affectedOrders.Any()
                select new EndangeredCustomer
                {
                    CustomerId = c.CustomerId,
                    Name = c.ContactName,
                    Phone = c.Phone,
                    OrderIds = affectedOrders.Select(_ => _.OrderId).ToList(),
                    TotalAmount = affectedOrders.Select(__ => __.UnitPrice * __.Quantity).Sum()
                };

            var customers = customerQuery.ToList();
            return customers;
        }

        public class EndangeredCustomer
        {
            public string? CustomerId { get; set; }

            public string? Name { get; set; }

            public string? Phone { get; set; }

            public IReadOnlyCollection<int>? OrderIds { get; set; }

            public decimal TotalAmount { get; set; }
        }
    }
}
