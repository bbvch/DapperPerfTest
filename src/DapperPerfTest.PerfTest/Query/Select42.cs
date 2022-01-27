using System.Linq;
using BenchmarkDotNet.Attributes;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace DapperPerfTest.PerfTest.Query
{
    public class Select42 : PerfTestBase
    {
        [Benchmark(Baseline = true)]
        public int Dapper()
        {
            return this.DbConnection.QueryFirstOrDefault<int>("SELECT 42");
        }

        [Benchmark]
        public int EFCore5()
        {
            return this.EF5Context.IntResult.FromSqlRaw("SELECT 42 AS [value]").Single().Value;
        }

        [Benchmark]
        public int EFCore6()
        {
            return this.EF6Context.IntResult.FromSqlRaw("SELECT 42 AS [value]").Single().Value;
        }

        [Benchmark]
        public int EFCore6Compiled()
        {
            return this.EF6Context.IntResult.FromSqlRaw("SELECT 42 AS [value]").Single().Value;
        }
    }
}
