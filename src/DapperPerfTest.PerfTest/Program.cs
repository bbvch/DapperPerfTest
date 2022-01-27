using System;
using System.Globalization;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using DapperPerfTest.PerfTest.Query;

namespace DapperPerfTest.PerfTest
{
    public static class Program
    {
        public static readonly Type[] BenchmarkTypes =
        {
            typeof(TimeToFirstQueryEF5),
            typeof(TimeToFirstQueryEF6),
            typeof(Select42),
            typeof(Entity),
            typeof(PartialEntity),
            typeof(RelatedEntities)
        };

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
            var config = DefaultConfig.Instance
                .StopOnFirstError()
                .AddExporter(exporter)
                .AddDiagnoser(new MemoryDiagnoser(new MemoryDiagnoserConfig(false)));
            BenchmarkSwitcher.FromTypes(BenchmarkTypes).Run(args, config);
        }
    }
}
