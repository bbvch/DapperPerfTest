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
        public int EfCore()
        {
            return this.EfContext.IntResult.FromSqlRaw("SELECT 42 AS [value]").Single().Value;
        }
    }
}
