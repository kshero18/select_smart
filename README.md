# SelectSmart — Student & Candidate Management Platform

**SelectSmart** is a web-based student and candidate management project developed during a January–February 2020 internship at Generis Technologies, Bengaluru. The application concept was to help academic or placement teams organise student profiles, review candidate information, and support communication and selection workflows.

**Two separate codebases from the 2020 internship have been uploaded here:** an ASP.NET MVC 5 / AngularJS implementation (`SelectSmart/`) and an ASP.NET Core MVC 3.1 candidate CRUD implementation (`MvcAdoDemo/`). They are two related implementations, **not a confirmed v1 → v2 development sequence**. Both were recovered from older internship materials and later subjected to an attempt to restore and preserve them for portfolio use.

## What the application is for

Academic and placement teams may need to maintain student records across spreadsheets, identify candidates by academic background or skills, and communicate with groups of students. SelectSmart was conceived as a central interface for those tasks.

The wider internship project covered:

- **Student records:** Manage information such as registration number, contact details, department, skills, passing year, CGPA, and backlogs.
- **Candidate management:** Add, view, update, and remove candidate profiles.
- **Candidate discovery:** Filter candidate information to support shortlisting and review.
- **Spreadsheet workflows:** Import student information from Excel and export candidate lists.
- **Communication:** Support bulk email activity associated with uploaded student records.

**Implementation scope:** The recovered source in this repository demonstrates candidate-record management. Excel upload/export, filtering, and bulk email workflows are described in the wider internship materials; their complete implementations are **not established by this published source**.

## Candidate information

Both implementations use a candidate record with these fields:

| Field | Purpose |
| --- | --- |
| Registration number | Identifies a candidate |
| Name, email, phone number | Basic personal and contact details |
| Department | Academic department or discipline |
| Skills | Technical skills associated with the candidate |
| Year of passing | Graduation/passing year |
| CGPA | Academic performance |
| Backlogs | Outstanding academic subjects |

These fields provide the basis for candidate listing, profile review, and CRUD operations.

## How candidate management works

1. **Browse candidates:** View a table of registered students and their academic/contact details.
2. **Create a profile:** Enter a registration number, personal details, department, skills, and academic information.
3. **View details:** Open an individual candidate record.
4. **Edit a profile:** Update a candidate's stored information.
5. **Delete a profile:** Remove a candidate record when no longer needed.

The ASP.NET Core implementation exposes these steps through Razor pages. The legacy AngularJS implementation contains a candidate form and list with JavaScript create/read/update/delete operations, although its API routes and integration have not been fully validated.

## Application structure

| Component | Technology | Role |
| --- | --- | --- |
| User interface | HTML, CSS, Bootstrap, AngularJS or Razor | Forms, candidate tables, navigation and actions |
| Web application | C#, ASP.NET MVC / ASP.NET Core MVC | Handles candidate requests and responses |
| Data access | ADO.NET, SQL Server stored procedures | Reads and changes candidate records |
| Database | Microsoft SQL Server | Stores structured candidate information |

### 1. [SelectSmart — ASP.NET MVC and AngularJS](SelectSmart/)

The legacy application is built using **C#, ASP.NET MVC 5, .NET Framework 4.7.2, AngularJS, Bootstrap, and SQL Server**.

Explore:
- [Candidate controller](SelectSmart/SelectSmart/Controllers/CandidateController.cs)
- [AngularJS controller](SelectSmart/SelectSmart/Scripts/SSFOLDER/Controller.js)
- [AngularJS service](SelectSmart/SelectSmart/Scripts/SSFOLDER/Service.js)
- [Candidate page](SelectSmart/SelectSmart/Views/SS/Index.cshtml)

Its candidate screen contains a data-entry form, a candidate list, and actions to save, select, and delete records. The application uses client-side JavaScript to communicate with server-side endpoints. Some route and variable inconsistencies remain in the recovered files, so this version has **not been verified as runnable**.

### 2. [MvcAdoDemo — ASP.NET Core MVC](MvcAdoDemo/)

This related CRUD exercise uses **C#, ASP.NET Core MVC 3.1, Razor views, ADO.NET, and SQL Server**.

It includes:
- Candidate listing and details pages
- Create and edit forms with basic input validation
- Delete confirmation and candidate removal
- SQL Server data-access methods and stored procedures
- A separate demonstration database setup using fictional records

See the [MvcAdoDemo application guide](MvcAdoDemo/README.md) for its components and local setup.

## Example candidate workflow

A placement team member opens the candidate list, reviews student profiles, and creates a record for a new student. They can select that student to inspect details, edit the department or skills as needed, or remove the record when appropriate. Candidate records are stored in SQL Server and accessed through the MVC application.

This describes the workflow supported by the candidate-management code; it is **not a claim that the full internship platform is presently deployed**.

## Project origin and restoration

**Internship:** Generis Technologies, Bengaluru  
**Original work:** January–February 2020  
**Project:** Student Academic Activities Management Platform / SelectSmart  
**GitHub preservation/restoration attempt:** 2026

Both uploaded codebases come from the 2020 internship materials. They were retained in older project files and uploaded to GitHub years later. The 2026 work was an **attempt to recover, sanitise, compile and restore the historical source**, not a claim that these applications were newly developed in 2026.

The two source folders should not be interpreted as formally numbered releases of one complete application. Their precise relationship in the original development process, and whether either represents the final internship submission, have **not been independently verified**. In particular, the recovered `SelectSmart/` source has not been shown to be the exact final 2020 deliverable.

The ASP.NET Core code has subsequently received some fixes and reconstructed SQL demo scripts to aid restoration. Those additions are separately identifiable in Git history and **are not presented as work completed in 2020**.

This was an internship team project; this repository does not claim sole authorship or ownership of the entire platform.

## Running the project and current status

- **MvcAdoDemo:** Restores and compiles successfully in [GitHub Actions](https://github.com/kshero18/select_smart/actions/workflows/mvcado-build.yml). SQL Server integration and end-to-end CRUD have not yet been tested.
- **SelectSmart:** Recovered legacy source; build and runtime have not been verified.
- **Database demonstration:** [SQL setup scripts](MvcAdoDemo/sql/) create a candidate table, procedures, and fictional records for local experimentation. Those scripts were reconstructed later, not part of the recovered original database.
- **Security:** These are historical applications using older frameworks. Do not deploy publicly without reviewing dependencies and security controls. Database credentials and real candidate records are not included.

This repository showcases the **application design, candidate data model, web development and data-access patterns** represented by the two historical codebases. Restoration remains partial: a passing build for the ASP.NET Core implementation is not proof that either full application has been recovered and tested end to end.
