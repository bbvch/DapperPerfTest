module DapperPerfTest.Report.Plot

open System.Globalization
open System.IO
open CsvHelper
open DapperPerfTest.PerfTest
open Plotly.NET
open Plotly.NET.StyleParam

type Benchmark() =
  member val Method = "" with get, set
  member val Type = "" with get, set
  member val ``Mean [ms]`` = 0m with get, set

let benchmarksOrder =
    Program.BenchmarkTypes
    |> Seq.indexed
    |> Seq.map (fun (i, v) -> v.Name, i)
    |> Map.ofSeq

[<EntryPoint>]
let main _ =
    let reports =
        Path.Join(__SOURCE_DIRECTORY__, "..", "..", "BenchmarkDotNet.Artifacts", "results")

    let latestRun =
        Directory.GetFiles(reports, "BenchmarkRun-joined-*-report.csv")
        |> Seq.max

    let measurements =
        use stream = new StreamReader(latestRun)
        use csv = new CsvReader(stream, CultureInfo.InvariantCulture)
        csv.GetRecords<Benchmark>()
        |> Seq.sortBy (fun r -> benchmarksOrder.Item r.Type)
        |> Seq.toList

    let dataFor framework name =
        let data =
            measurements
            |> List.filter (fun r -> r.Method = framework)
            |> List.map (fun r -> (r.Type, r.``Mean [ms]``))
        Chart.Column(data |> Seq.map fst, data |> Seq.map snd, name)

    let groupedLayout =
        let legend = Legend.init(XAnchor = XAnchorPosition.Center, X = 0.5, YAnchor = YAnchorPosition.Top, Orientation = Orientation.Horizontal)
        Layout.init(Barmode = Barmode.Group, Font = Font.init(Family = FontFamily.Times_New_Roman), Legend = legend)

    [ dataFor "Dapper" "Dapper"; dataFor "EfCore" "EF Core"; dataFor "EfCoreCompiled" "EF Core (compiled)" ]
    |> Chart.combine
    |> Chart.withYAxisStyle "Zeit [ms]"
    |> Chart.withLayout groupedLayout
    |> Chart.withSize (768., 512.)
    |> Chart.show
    0
