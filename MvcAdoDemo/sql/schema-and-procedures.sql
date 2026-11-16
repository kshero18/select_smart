-- Demo-only SQL Server schema for the recovered 2020 candidate CRUD exercise.
-- Run MvcAdoDemo/cpsmart.sql first. Use a dedicated local database with fictional data.
-- Run this file in SQL Server Management Studio (GO is an SSMS/sqlcmd batch separator).
USE cpsmart;
GO

IF OBJECT_ID(N'dbo.candidate', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.candidate
    (
        Regno INT NOT NULL CONSTRAINT PK_candidate PRIMARY KEY,
        Name NVARCHAR(150) NOT NULL,
        Email NVARCHAR(254) NOT NULL,
        Phoneno NVARCHAR(30) NOT NULL,
        Dept NVARCHAR(20) NULL,
        skills NVARCHAR(100) NULL,
        Yearofpassing INT NULL,
        CGPA FLOAT NULL,
        Backlogs INT NULL
    );
END;
GO

CREATE OR ALTER PROCEDURE dbo.cpGetAllCandidate
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Regno, Name, Email, Phoneno, Dept, skills, Yearofpassing, CGPA, Backlogs
    FROM dbo.candidate ORDER BY Regno;
END;
GO

CREATE OR ALTER PROCEDURE dbo.cpAddCandidate
    @Regno INT,
    @Name NVARCHAR(150),
    @Email NVARCHAR(254),
    @Phoneno NVARCHAR(30),
    @Dept NVARCHAR(20) = NULL,
    @skills NVARCHAR(100) = NULL,
    @Yearofpassing INT = NULL,
    @CGPA FLOAT = NULL,
    @Backlogs INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.candidate (Regno, Name, Email, Phoneno, Dept, skills, Yearofpassing, CGPA, Backlogs)
    VALUES (@Regno, @Name, @Email, @Phoneno, @Dept, @skills, @Yearofpassing, @CGPA, @Backlogs);
END;
GO

CREATE OR ALTER PROCEDURE dbo.cpUpdateCandidate
    @Regno INT,
    @Name NVARCHAR(150),
    @Email NVARCHAR(254),
    @Phoneno NVARCHAR(30),
    @Dept NVARCHAR(20) = NULL,
    @skills NVARCHAR(100) = NULL,
    @Yearofpassing INT = NULL,
    @CGPA FLOAT = NULL,
    @Backlogs INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.candidate
    SET Name = @Name, Email = @Email, Phoneno = @Phoneno, Dept = @Dept,
        skills = @skills, Yearofpassing = @Yearofpassing, CGPA = @CGPA, Backlogs = @Backlogs
    WHERE Regno = @Regno;
END;
GO

CREATE OR ALTER PROCEDURE dbo.cpDeleteCandidate
    @Regno INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.candidate WHERE Regno = @Regno;
END;
GO
