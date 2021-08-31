using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Dapper;

namespace DapperPerfTest.PerfTest.Query
{
    public class PartialEntity : PerfTestBase
    {
        [Benchmark(Baseline = true)]
        public IReadOnlyCollection<DapperProductInfo> Dapper()
        {
            return this.DbConnection.Query<DapperProductInfo>(
                "SELECT ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel" +
                " FROM Products" +
                " WHERE Discontinued = 0 AND ReorderLevel > UnitsInStock + UnitsOnOrder")
                .AsList();
        }

        [Benchmark]
        public IReadOnlyCollection<EfProductInfo> EfCore()
        {
            return this.EfContext.Products
                .Where(_ => !_.Discontinued && _.ReorderLevel > _.UnitsInStock + _.UnitsOnOrder)
                .Select(_ => new EfProductInfo(_.ProductName)
                {
                    UnitsInStock = _.UnitsInStock,
                    UnitsOnOrder = _.UnitsOnOrder,
                    ReorderLevel = _.ReorderLevel
                })
                .ToList();
        }

        public record EfProductInfo(string ProductName)
        {
            public short? UnitsInStock { get; init; }

            public short? UnitsOnOrder { get; init; }

            public short? ReorderLevel { get; init; }
        }

        public class DapperProductInfo
        {
            public string? ProductName { get; set; }

            public short? UnitsInStock { get; set; }

            public short? UnitsOnOrder { get; set; }

            public short? ReorderLevel { get; set; }
        }
    }
}
