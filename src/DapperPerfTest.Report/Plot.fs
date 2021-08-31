module DapperPerfTest.Report.Plot

open CsvHelper
open System.Globalization
open System.IO
open XPlot.Plotly
open DapperPerfTest.PerfTest

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
        Bar(
            name = name,
            x = (data |> Seq.map fst),
            y = (data |> Seq.map snd))

    let groupedLayout =
        let legend = Legend(xanchor = "center", x = 0.5, yanchor = "top", orientation = "h")
        let yAxis = Yaxis(title = "Zeit [ms]")
        let font = Font(family = "Times New Roman")
        Layout(barmode = "group", legend = legend, yaxis = yAxis, font = font)

    [ dataFor "Dapper" "Dapper"; dataFor "EfCore" "EF Core"; dataFor "EfCoreCompiled" "EF Core (compiled)" ]
    |> Chart.Plot
    |> Chart.WithLayout groupedLayout
    |> Chart.WithSize (768, 512)
    |> Chart.Show
    0
