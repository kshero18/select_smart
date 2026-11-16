# SelectSmart — 2020 C#/.NET Internship Portfolio

Historical source from a student academic activities and candidate-management project developed during an internship at **Generis Technologies, Bengaluru (January–February 2020)**.

This repository contains two related C# implementations recovered from internship materials. They illustrate candidate CRUD workflows and SQL Server integration, but should **not** be treated as one complete, deployable application.

## Projects at a glance

| Project | Stack | What is included | Current status |
| --- | --- | --- | --- |
| [SelectSmart](SelectSmart/) | C#, ASP.NET MVC 5, .NET Framework 4.7.2, AngularJS, SQL Server | Candidate controller, models, AngularJS scripts, Razor/HTML assets and a Visual Studio solution | Historical source; not verified to build or run |
| [MvcAdoDemo](MvcAdoDemo/) | C#, ASP.NET Core MVC 3.1, Razor, ADO.NET (`System.Data.SqlClient`), SQL Server | Candidate listing, creation, details, editing, deletion, and stored-procedure calls | Historical source; database schema/procedures incomplete; not verified to build or run |

## Project context and contributions

The broader SelectSmart internship work concerned student academic activities and candidate management. The internship documentation describes work related to:

- Uploading student records from Excel and supporting bulk email workflows
- Filtering candidates and exporting candidate lists to Excel
- Candidate create/read/update/delete (CRUD) workflows
- C#/.NET application development, web interfaces, and SQL Server data access

These were activities within an internship/team project. **Not every feature described in the presentation or certificate is demonstrably implemented by the source currently included in this repository.** This archive does not claim sole authorship of the full platform.

## Repository layout

```text
.
├── SelectSmart/              # Legacy ASP.NET MVC 5 and AngularJS implementation
│   └── SelectSmart.sln
├── MvcAdoDemo/               # ASP.NET Core MVC 3.1 + ADO.NET CRUD exercise
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   ├── cpsmart.sql
│   └── README.md
├── CPSMART.sln               # Legacy root solution; references a missing CPSMART.csproj
└── README.md
```

## Setup and limitations

**This is an archival portfolio, not a production-ready service.**

- Both implementations are based on older, unsupported frameworks/dependencies. Do not deploy them publicly as-is.
- Neither project has been confirmed to build or run from this repository.
- The included `MvcAdoDemo/cpsmart.sql` creates a database only. It does **not** provide the candidate table or the SQL Server stored procedures required by the application.
- `MvcAdoDemo` reads its database connection string from the local `CPSMART_CONNECTION_STRING` environment variable; no real connection credentials should be committed.
- Sensitive configuration, SQL Server database files, and personal records are intentionally excluded.
- Some legacy API/client routes, model references, and SQL handling require correction before the source is runnable.

For the candidate CRUD exercise, see the [MvcAdoDemo-specific README](MvcAdoDemo/README.md).

## Portfolio review roadmap

- [x] Publish source-only copies on a review branch, excluding local databases and credentials
- [x] Record technologies, provenance, and known limitations
- [ ] Resolve the outstanding build/model issues and check that the apps compile
- [ ] Recreate a synthetic-data SQL schema and stored procedures if a runnable demo is desired
- [ ] Fix parameterized queries, missing-record handling, and form issues
- [ ] Add screenshots using **synthetic or fully redacted** candidate details
- [ ] Merge into `main` after reviewing source-sharing permission and the changes

### Historical vs subsequent changes

The underlying applications originated in 2020. GitHub commits made later reflect source recovery, sanitization, and documentation; they do not represent when the original project was developed. Any future functional improvements should be identified separately as modernisation work.
