USE SchoolSchedule
GO
 
CREATE PROCEDURE spInputLesson
	@groupId INT,
	@teacherId INT,
	@subjectId INT,
	@roomId INT,
	@semester INT,
	@year INT,
	@dayOfWeek INT,
	@lessonNumber INT,

	@result INT OUT
AS

BEGIN
	IF EXISTS(SELECT 1
			  FROM [dbo].[tblLesson] as l
			  INNER JOIN [dbo].[tblGroup] as g
			  ON g.Id = l.GroupId
			  WHERE g.Id = @groupId AND
					  l.Semester = @semester AND
					  l.[Year] = @year AND
					  l.[DayOfWeek] = @dayOfWeek AND
					  l.LessonNumber = @lessonNumber AND
					  l.Deleted = 0)
	BEGIN
		SET @result = 1;
		RETURN 1;
	END;

	IF EXISTS(SELECT 1
			  FROM [dbo].[tblLesson] as l
			  INNER JOIN [dbo].[tblTeacher] as t
			  ON t.Id = l.TeacherId
			  WHERE t.Id = @teacherId AND
					  l.Semester = @semester AND
					  l.[Year] = @year AND
					  l.[DayOfWeek] = @dayOfWeek AND
					  l.LessonNumber = @lessonNumber AND
					  l.Deleted = 0)
	BEGIN
		SET @result = 2;
		RETURN 2;
	END;
	
	IF EXISTS(SELECT 1
			  FROM [dbo].[tblLesson] as l
			  INNER JOIN [dbo].[tblRoom] as r
			  ON r.Id = l.RoomId
			  WHERE r.Id = @roomId AND
					  l.Semester = @semester AND
					  l.[Year] = @year AND
					  l.[DayOfWeek] = @dayOfWeek AND
					  l.LessonNumber = @lessonNumber AND 
					  l.Deleted = 0)
	BEGIN
		SET @result = 3;
		RETURN 3;
	END;
	
	INSERT INTO [dbo].[tblLesson]
           ([SubjectId]
           ,[TeacherId]
           ,[GroupId]
           ,[RoomId]
           ,[Year]
           ,[Semester]
           ,[DayOfWeek]
           ,[LessonNumber]
           ,[Deleted])
     VALUES
           (@subjectId
           ,@teacherId
           ,@groupId
           ,@roomId
           ,@year
           ,@semester
           ,@dayOfWeek
           ,@lessonNumber
           ,0)
	SET @result = 0;
END;
GO

CREATE PROCEDURE spAddTeacher
	@name NVARCHAR(50),
	@surName NVARCHAR(50),
	@result INT OUT
AS
BEGIN
	INSERT INTO [dbo].[tblTeacher]
           ([Name]
           ,[Surname]
           ,[Deleted])
     VALUES
           (@name
           ,@surName
           ,0);
SET @result = 0;

END;
GO

CREATE PROCEDURE spAddGroup
	@name NVARCHAR(50),
	@result INT OUTPUT
AS
BEGIN
	IF EXISTS(SELECT g.Id FROM [dbo].[tblGroup] as g WHERE g.Name = @name AND g.Deleted = 1)
	BEGIN
		UPDATE [dbo].[tblGroup]
		SET [Deleted] = 0
		WHERE Name = @name;
		SET @result = 0;
		RETURN 0;
	END

	IF EXISTS(SELECT g.Id FROM [dbo].[tblGroup] as g WHERE g.Name = @name AND g.Deleted = 0)
	BEGIN
		SET @result = 1;
		RETURN 1;
	END

	INSERT INTO [dbo].[tblGroup]
           ([Name]
           ,[Deleted])
     VALUES
           (@name
           ,0);
		   SET @result = 0;	
END;
GO

CREATE PROCEDURE spAddSubject
	@subjectName NVARCHAR(50),
	@result INT OUTPUT
AS
BEGIN
	IF EXISTS(SELECT s.Id FROM [dbo].[tblSubject] as s WHERE s.Name = @subjectName AND s.Deleted = 1)
	BEGIN
		UPDATE [dbo].[tblsubject]
		 SET [Deleted] = 0
		 WHERE Name = @subjectName;
		 SET @result = 0;
		 RETURN 0;
	END;

	IF EXISTS(SELECT s.Id FROM [dbo].[tblSubject] as s WHERE s.Name = @subjectName)
	BEGIN
		SET @result = 1;
		RETURN 1;
	END;

	INSERT INTO [dbo].[tblSubject]
           ([Name]
           ,[Deleted])
     VALUES
           (@subjectName
           ,0);
	SET @result = 0;	
END;
GO

CREATE PROCEDURE [dbo].[spAddRoom]
	@roomNumber INT,
	@result INT OUTPUT
AS
BEGIN
	IF EXISTS(SELECT r.Id FROM [dbo].[tblRoom] as r WHERE r.Number = @roomNumber AND r.Deleted = 1)
	BEGIN
	PRINT 1;
		UPDATE [dbo].[tblRoom]
		 SET [Deleted] = 0
		 WHERE Number = @roomNumber;
		 SET @result = 0;
		 RETURN 0;
	END;
	
	IF EXISTS(SELECT r.Id FROM [dbo].[tblRoom] as r WHERE r.Number = @roomNumber)
	BEGIN
	PRINT 1;
		
		 SET @result = 1;
		 RETURN 1;
	END;

	INSERT INTO [dbo].[tblRoom]
           ([Number]
           ,[Deleted])
     VALUES
           (@roomNumber
           ,0);
		   SET @result = 0;	
END;
GO

CREATE PROCEDURE spGetUserByLogin
	@Login VARCHAR(50),
	@Password VARCHAR(50)

AS

BEGIN

	SELECT 
		Id, 
		FirstName, 
		Surname, 
		[Login], 
		[Disabled] 
	FROM tblUser
	WHERE [Login] = @Login and [Password] = @Password and [Disabled] <> 1;

END;
GO

CREATE PROCEDURE spRemoveTeacher
	@id INT
AS
BEGIN
DECLARE @lesId INT;
SELECT @lesId = l.Id 
	FROM tblTeacher as t
	INNER JOIN tblLesson as l
	ON l.TeacherId = t.Id
	WHERE t.Id = @id;

	UPDATE  tblTeacher
	SET Deleted = 1
	WHERE Id = @id;

	UPDATE tblLesson
	SET Deleted = 1
	WHERE Id = @lesId;
	

END;
GO

CREATE PROCEDURE spRemoveGroup
	@id INT
AS
BEGIN
DECLARE @lesId INT;
SELECT @lesId = l.Id 

	FROM tblGroup as g
	INNER JOIN tblLesson as l
	ON l.GroupId = g.Id
	WHERE g.Id = @id;

	UPDATE  tblGroup
	SET Deleted = 1
	WHERE Id = @id;

	UPDATE tblLesson
	SET Deleted = 1
	WHERE Id = @lesId;
	

END;
GO

CREATE PROCEDURE spRemoveRoom
	@id INT
AS
BEGIN
DECLARE @lesId INT;
SELECT @lesId = l.Id 

	FROM tblRoom as r
	INNER JOIN tblLesson as l
	ON l.GroupId = r.Id
	WHERE r.Id = @id;

	UPDATE  tblRoom
	SET Deleted = 1
	WHERE Number = @id;

	UPDATE tblLesson
	SET Deleted = 1
	WHERE Id = @lesId;
	

END;
GO

CREATE PROCEDURE spRemoveSubject
	@id INT
AS
BEGIN
DECLARE @lesId INT;
SELECT @lesId = l.Id 

	FROM tblSubject as s
	INNER JOIN tblLesson as l
	ON l.GroupId = s.Id
	WHERE s.Id = @id;

	UPDATE  tblSubject
	SET Deleted = 1
	WHERE Id = @id;

	UPDATE tblLesson
	SET Deleted = 1
	WHERE Id = @lesId;
	

END;
GO

CREATE PROCEDURE spRemoveLesson
	@id INT,
	@result INT OUT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM tblLesson WHERE Id = @id AND Deleted = 0)
	BEGIN
		UPDATE [dbo].[tblLesson]
		   SET [Deleted] = 1
		 WHERE Id = @id;

		SET @result =0;
		RETURN 0;
	END

	SET @result = 1;
	RETURN 1;
	
END
GO