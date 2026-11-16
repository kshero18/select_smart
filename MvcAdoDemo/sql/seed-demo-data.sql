-- Optional synthetic data. Do not commit real student or candidate records.
USE cpsmart;
GO
IF NOT EXISTS (SELECT 1 FROM dbo.candidate WHERE Regno = 1001)
INSERT INTO dbo.candidate
(Regno, Name, Email, Phoneno, Dept, skills, Yearofpassing, CGPA, Backlogs)
VALUES
(1001, N'Alex Example', N'alex@example.com', N'0000000000', N'CSE', N'Python', 2020, 8.1, 0);
IF NOT EXISTS (SELECT 1 FROM dbo.candidate WHERE Regno = 1002)
INSERT INTO dbo.candidate
(Regno, Name, Email, Phoneno, Dept, skills, Yearofpassing, CGPA, Backlogs)
VALUES
(1002, N'Sam Sample', N'sam@example.com', N'0000000000', N'ISE', N'Java', 2021, 7.7, 1);
GO
