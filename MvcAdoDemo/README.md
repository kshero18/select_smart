# MvcAdoDemo — ASP.NET Core MVC candidate CRUD (2020 internship)

Archived internship implementation demonstrating C#, ASP.NET Core MVC, Razor views, ADO.NET (`System.Data.SqlClient`), and SQL Server stored procedures for candidate management.

## Included
- Candidate controller, model, and data-access layer
- Razor views for listing, creating, viewing, editing, and deleting candidates
- `cpsmart.sql` contains a database creation snippet, **not** a complete stored-procedure/schema setup

## Configuration and limitations
- Targets .NET Core 3.1, which is **end-of-support**. This is historical portfolio code, not a production-ready app.
- Database connection information has been removed from source. Set the `CPSMART_CONNECTION_STRING` environment variable locally before running. Never commit real credentials.
- SQL Server database schema and stored procedures (`cpGetAllCandidate`, etc.) may need to be recreated; the included SQL file alone is insufficient.
- Build and execution have not been verified.

## Provenance
Created during a 2020 Generis Technologies internship. This repository is an archival presentation of internship source, with sensitive connection details removed for public sharing.
