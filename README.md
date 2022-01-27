# Dapper vs. Entity Framework Core

## Prerequisites

Setup a (local) [Northwind DB](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/linq/downloading-sample-databases), e.g. using our [DapperPlayground](https://github.com/bbvch/DapperPlayground) and/or adjust the ConnectionString in [Config.Connection](./src/DapperPerfTest.Common/Config.cs)

## Run

### Time to first query

```ps
dotnet run --project .\src\DapperPerfTest.PerfTest -c Release -- --join -f *TimeToFirstQuery*
```

### Query benchmarks

```ps
dotnet run --project .\src\DapperPerfTest.PerfTest -c Release -- --join -f *.Query.*
```

#### Generate plots

```ps
dotnet run --project .\src\DapperPerfTest.Report
```

## Scaffolding notes

- `dotnet ef dbcontext scaffold Name=ConnectionStrings:Sql Microsoft.EntityFrameworkCore.SqlServer --output-dir Scaffold`
- in [EFCore6](./src/DapperPerfTest.EFCore6): `dotnet ef dbcontext optimize --output-dir Scaffold`
