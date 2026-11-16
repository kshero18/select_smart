# MvcAdoDemo — Candidate Management Application

A C# **ASP.NET Core MVC** application for maintaining student/candidate profiles with Microsoft SQL Server. It represents the candidate-management CRUD workflow developed as part of the 2020 SelectSmart internship work.

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

This is historical internship work, not a currently deployed product. The original source dates to **2020**; later maintenance improved validation, queries and Razor forms. The SQL setup under `sql/` and its fictional sample records were reconstructed for demonstration and should not be mistaken for original internship deliverables.

**Known limitations:** .NET Core 3.1 is no longer supported; the database-backed application has not yet been runtime-tested; it should not be deployed publicly without an upgrade and security review. The broader SelectSmart project also discusses filtering, Excel workflows and bulk emails, but those are **not features of this CRUD demo**.

[Back to the overall SelectSmart project](../README.md)
