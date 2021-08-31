# Dapper vs. Entity Framework Core

## Prerequisites

Setup a (local) [Northwind DB](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/linq/downloading-sample-databases), e.g. using our [DapperPlayground](https://github.com/bbvch/DapperPlayground) and/or adjust the ConnectionString in [Program.ConnectionString](./src/DapperPerfTest.PerfTest/Program.cs)

## Run

### Time to first query

```ps
dotnet run --project .\src\DapperPerfTest.PerfTest -c Release -- -f TimeToFirstQuery
```

### Query benchmarks

```ps
dotnet run --project .\src\DapperPerfTest.PerfTest -c Release -- --join -f *.Query.*
```

#### Generate plots

```ps
dotnet run --project .\src\DapperPerfTest.Report
```
