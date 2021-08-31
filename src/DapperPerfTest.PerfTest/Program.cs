using System;
using System.Globalization;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using DapperPerfTest.PerfTest.Query;

namespace DapperPerfTest.PerfTest
{
    public static class Program
    {
        public const string ConnectionString = "ConnectionStrings:Sql=Data Source=localhost,1434;Initial Catalog=Northwind;User Id=SA;Password=Change_Me;";

        public static readonly Type[] BenchmarkTypes =
        {
            typeof(TimeToFirstQuery),
            typeof(Select42),
            typeof(Entity),
            typeof(PartialEntity),
            typeof(RelatedEntities)
        };

        private const int LoopCount = 70;

        public static void Main(string[] args)
        {
            var customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            customCulture.NumberFormat.NumberGroupSeparator = string.Empty;
            var exporter = new CsvExporter(
                CsvSeparator.Comma,
                new SummaryStyle(
                    customCulture,
                    true,
                    printUnitsInContent: false,
                    printZeroValuesInContent: true,
                    timeUnit: Perfolizer.Horology.TimeUnit.Millisecond,
                    sizeUnit: SizeUnit.B));
            var config = DefaultConfig.Instance.StopOnFirstError()
                .AddJob(Job.Default.WithUnrollFactor(LoopCount).WithId($"Default+Unroll{LoopCount}"))
                .AddExporter(exporter)
                .AddDiagnoser(new MemoryDiagnoser(new MemoryDiagnoserConfig(false)));
            BenchmarkSwitcher.FromTypes(BenchmarkTypes).Run(args, config);
        }
    }
}
