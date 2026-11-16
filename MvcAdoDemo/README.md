# MvcAdoDemo — candidate CRUD (2020 internship exercise)

An archived **C# / ASP.NET Core MVC 3.1** candidate-management exercise using Razor views, ADO.NET (`System.Data.SqlClient`) and Microsoft SQL Server.

The original application was created during the 2020 internship. Later 2026 modernisation commits improve data handling and forms and add an **optional synthetic-data database setup**. These improvements are not represented as original 2020 deliverables.

## Included functionality

- List candidate records, display details, create, edit, and delete
- Controller and strongly typed Razor views
- SQL Server data-access layer using parameterized commands and stored procedures
- Model validation for required fields and formats
- Example SQL schema, procedures, and fictional sample records

## Layout

- `Controllers/candidateController.cs` — MVC action methods
- `Models/candidate.cs` — model and validation rules
- `Models/CandidateDataAccessLayer.cs` — SQL Server access
- `Views/candidate/` — Razor CRUD views
- `cpsmart.sql` — original basic database creation snippet
- `sql/schema-and-procedures.sql` — **2026 reconstruction** of SQL objects for demonstration
- `sql/seed-demo-data.sql` — **2026 synthetic demonstration records**

## Local setup (unverified)

> **Do not deploy this archival application as a public-facing service.** .NET Core 3.1 and its older dependencies are unsupported. SQL Server and a compatible .NET SDK are required; the application **has passed a restore and Release build** in GitHub Actions (16 November 2026). SQL Server execution and end-to-end runtime operation remain **unverified**.

1. Use a local/development SQL Server instance. Open SQL Server Management Studio and execute `cpsmart.sql`.
2. Execute `sql/schema-and-procedures.sql` in the same instance to create `dbo.candidate` and the four stored procedures. This script is a later reconstruction; it is not the original internship schema.
3. Optionally execute `sql/seed-demo-data.sql` to insert two **fictional** records.
4. Set the `CPSMART_CONNECTION_STRING` environment variable on your local computer using your own SQL Server credentials. Do **not** put credentials in Git, screenshots, issues, or committed configuration.
5. With a compatible .NET Core 3.1 SDK installed, try `dotnet restore MvcAdoDemo.csproj` and `dotnet run --project MvcAdoDemo.csproj`; use the port printed in the console and navigate to `/candidate`.

### Validation checklist (not yet completed)

- [x] Restore and compile the project in GitHub Actions on Windows (16 November 2026; no database used)
- [ ] Run the SQL scripts against an isolated local SQL Server instance
- [ ] Test list/details/create/edit/delete using fake candidate data
- [ ] Check model validation, malformed input and duplicate registration numbers
- [x] Update `System.Data.SqlClient` from 4.4.0 to 4.8.6 to address reported package advisories
- [ ] Review remaining dependency and framework security alerts before any deployment

Build status: [GitHub Actions — archived ASP.NET Core build](https://github.com/kshero18/select_smart/actions/workflows/mvcado-build.yml). The passing build still warns that the .NET Core 3.1 target framework is out of support.

## Archival and security notes

The recovered 2020 code originally included a database connection string. The public copy removes that detail and reads the connection information from the local `CPSMART_CONNECTION_STRING` environment variable. Changes to old code should be understood as later portfolio modernisation, not evidence of historical implementation details.

The database scripts in `sql/` are newly authored demonstrations and do not prove that the archived source is a complete or runnable copy of the internship application.
