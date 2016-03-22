--CREATE DATABASE SchoolSchedule
--GO

USE SchoolSchedule
GO


CREATE TABLE tblTeacher(
	Id INT IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Surname NVARCHAR(50),
	Deleted BIT NOT NULL,

	CONSTRAINT PK_TeacherID PRIMARY KEY (Id)
	
);
GO



CREATE TABLE tblRoom(
	Id INT IDENTITY NOT NULL,
	Number INT NOT NULL,
	Deleted BIT NOT NULL,

	CONSTRAINT PK_RoomID PRIMARY KEY (Id),
	CONSTRAINT chk_RoomQuantity CHECK(Id <= 50),
	CONSTRAINT UQ_tblRoom_Number UNIQUE (Number),
	
);
GO

CREATE TABLE tblSubject(
	Id INT IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Deleted BIT NOT NULL,

	CONSTRAINT PK_SubjuctID PRIMARY KEY (Id),	
	CONSTRAINT UQ_tblSubject_Name UNIQUE(Name)
);
GO

CREATE TABLE tblGroup(
	Id INT IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Deleted BIT NOT NULL,


	CONSTRAINT PK_GroupID PRIMARY KEY (Id),	
	CONSTRAINT UQ_tblGroup_Name UNIQUE(Name)
);
GO

CREATE TABLE tblLesson(
	Id INT IDENTITY NOT NULL,
	SubjectId INT NOT NULL,
	TeacherId INT NOT NULL,
	GroupId INT NOT NULL,
	RoomId INT NOT NULL,
	[Year] INT NOT NULL,
	Semester INT NOT NULL,
	[DayOfWeek] INT NOT NULL,
	LessonNumber INT NOT NULL,
	[Deleted] BIT NOT NULL,
	

	CONSTRAINT PK_tblLessonId PRIMARY KEY (Id),
	CONSTRAINT FK_tblLesson_SubjectId_tblSubject_Id FOREIGN KEY (SubjectId) REFERENCES tblSubject(Id),
	CONSTRAINT FK_tblLesson_GroupId_tblGroup_Id FOREIGN KEY (GroupId) REFERENCES tblGroup(Id),
	CONSTRAINT FK_tblLesson_TeacherId_tblTeacher_Id FOREIGN KEY (TeacherId) REFERENCES tblTeacher(Id),
	CONSTRAINT FK_tblRoom_RoomId_tblRoom_Id FOREIGN KEY (RoomId) REFERENCES tblRoom(Id),
	CONSTRAINT chk_DayOfWeek CHECK([DayOfWeek] >= 1 AND [DayOfWeek]<=7),

	);
GO


CREATE TABLE tblUser
(
	Id int not null IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	Surname NVARCHAR(50) NOT NULL,
	[Login] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Disabled] BIT NOT NULL,
	CONSTRAINT PK_tblUser_Id PRIMARY KEY (Id),
	CONSTRAINT UQ_tblUser_Login UNIQUE ([Login])
);
GO
