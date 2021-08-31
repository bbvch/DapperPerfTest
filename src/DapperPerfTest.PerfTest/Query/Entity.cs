using System.Linq;
using BenchmarkDotNet.Attributes;
using Dapper;
using DapperPerfTest.EFCore.Scaffold;
using Microsoft.EntityFrameworkCore;

namespace DapperPerfTest.PerfTest.Query
{
    public class Entity : PerfTestBase
    {
        [Benchmark(Baseline = true)]
        public Product Dapper()
        {
            return this.DbConnection.QuerySingle<Product>("SELECT * FROM Products WHERE ProductId=42");
        }

        [Benchmark]
        public Product EfCore()
        {
            return this.EfContext.Products.AsNoTracking().Single(_ => _.ProductId == 42);
        }
    }
}
