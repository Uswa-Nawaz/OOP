USE UMS; -- This ensures you are inside the correct database
GO

CREATE TABLE DegreeSubjectLink (
    DegreeName nvarchar(50),
    SubjectCode nvarchar(50),
    PRIMARY KEY (DegreeName, SubjectCode),
    FOREIGN KEY (DegreeName) REFERENCES DegreePrograms(DegreeName),
    FOREIGN KEY (SubjectCode) REFERENCES Subjects(SubjectCode)
);