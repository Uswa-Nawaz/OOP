-- for creating UAMS tables
CREATE TABLE Subjects (
    SubjectCode nvarchar(50) PRIMARY KEY,
    SubjectType nvarchar(50),
    CreditHours int,
    SubjectFee int
);

CREATE TABLE DegreePrograms (
    DegreeName nvarchar(50) PRIMARY KEY,
    Duration float,
    Seats int
);

CREATE TABLE Students (
    StudentName nvarchar(50) PRIMARY KEY,
    Age int,
    FscMarks float,
    EcatMarks float,
    Merit float
);