# MvcAdoDemo — Candidate Management Application

A C# **ASP.NET Core MVC** application for maintaining student/candidate profiles with Microsoft SQL Server. This source was created during the **2020 internship** and was one of **two related codebases uploaded to this repository** from the older project materials. The other codebase is the ASP.NET MVC 5 / AngularJS implementation in [`SelectSmart/`](../SelectSmart/).

The two folders are **not verified as sequential versions (v1/v2)** of a single release. The code was uploaded years later as part of a **2026 attempt to recover and restore the 2020 work**, not newly authored from scratch in 2026.

## What it does

The application provides a simple interface for staff to maintain candidate information:

| Screen | What it allows |
| --- | --- |
| Candidate list | Browse registration numbers, names, contact information, departments, skills and academic details |
| Create candidate | Enter a new candidate profile using a web form |
| Candidate details | Review the stored information for one candidate |
| Edit candidate | Change an existing candidate's information |
| Delete candidate | Confirm and remove a record |

Each record includes **registration number, name, email, phone number, department, skills, year of passing, CGPA, and backlogs**. The registration number identifies the candidate.

## Application flow

```text
User (browser)
    |
    v
Razor views (candidate forms, table, details)
    |
    v
candidateController.cs (ASP.NET Core MVC actions)
    |
    v
CandidateDataAccessLayer.cs (ADO.NET / SqlClient)
    |
    v
SQL Server (candidate table and CRUD stored procedures)
```

A user opens **Candidates**, selects **Create New**, fills out the candidate form, and submits it. The controller validates the input and calls the data-access layer to save the record. The updated list is then displayed. The same controller provides details, edit and delete actions.

## Main technologies

- **C# and ASP.NET Core MVC 3.1** — request handling and application logic
- **Razor views, HTML, Bootstrap, jQuery validation** — user interface
- **ADO.NET (`System.Data.SqlClient`)** — database commands and result mapping
- **Microsoft SQL Server** — candidate records and stored procedures

## Explore the code

- [Candidate model](Models/candidate.cs) — profile fields and input validation
- [Candidate controller](Controllers/candidateController.cs) — create, list, details, edit and delete actions
- [Data-access layer](Models/CandidateDataAccessLayer.cs) — parameterized SQL query and stored-procedure calls
- [Razor candidate views](Views/candidate/) — screens and forms
- [Database scripts](sql/) — reconstructed schema, procedures, and fictional sample candidates

## Local demo setup

The ASP.NET Core application **builds successfully** in [GitHub Actions](https://github.com/kshero18/select_smart/actions/workflows/mvcado-build.yml), but execution with SQL Server and end-to-end CRUD have not been verified.

1. Set up a local Microsoft SQL Server instance and open SQL Server Management Studio.
2. Run [`cpsmart.sql`](cpsmart.sql) to create the database.
3. Run [`sql/schema-and-procedures.sql`](sql/schema-and-procedures.sql) to create the candidate table and stored procedures.
4. Optionally run [`sql/seed-demo-data.sql`](sql/seed-demo-data.sql) to insert fictional candidates.
5. Set the `CPSMART_CONNECTION_STRING` environment variable locally with a connection string for your development database. Never commit passwords.
6. With a compatible .NET SDK, run `dotnet restore MvcAdoDemo.csproj` and `dotnet run --project MvcAdoDemo.csproj`, then use the displayed local URL and navigate to `/candidate`.

## Project context

This is historical internship source from **2020**, not a currently deployed product. It was uploaded during a **2026 restoration attempt**, alongside the separate `SelectSmart/` implementation. Later maintenance improved validation, queries and Razor forms; the SQL setup under `sql/` and fictional records were reconstructed for demonstration, not recovered from the original 2020 submission. The precise relationship between the two original codebases has not been conclusively established.

**Known limitations:** .NET Core 3.1 is no longer supported; the database-backed application has not yet been runtime-tested; it should not be deployed publicly without an upgrade and security review. The broader SelectSmart project also discusses filtering, Excel workflows and bulk emails, but those are **not features of this CRUD demo**.

[Back to the overall SelectSmart project](../README.md)
