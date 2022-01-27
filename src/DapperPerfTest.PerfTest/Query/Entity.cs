using System.Linq;
using BenchmarkDotNet.Attributes;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace DapperPerfTest.PerfTest.Query
{
    public class Entity : PerfTestBase
    {
        [Benchmark(Baseline = true)]
        public EFCore5.Scaffold.Product Dapper()
        {
            return this.DbConnection.QuerySingle<EFCore5.Scaffold.Product>("SELECT * FROM Products WHERE ProductId=42");
        }

        [Benchmark]
        public EFCore5.Scaffold.Product EFCore5()
        {
            return this.EF5Context.Products.AsNoTracking().Single(_ => _.ProductId == 42);
        }

        [Benchmark]
        public EFCore6.Scaffold.Product EFCore6()
        {
            return this.EF6Context.Products.AsNoTracking().Single(_ => _.ProductId == 42);
        }

        [Benchmark]
        public EFCore6.Scaffold.Product EFCore6Compiled()
        {
            return this.EF6Context.Products.AsNoTracking().Single(_ => _.ProductId == 42);
        }
    }
}
