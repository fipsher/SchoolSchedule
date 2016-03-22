USE [SchoolSchedule]
GO

INSERT INTO [dbo].[tblSubject]
           ([Name]
		   ,[Deleted])
     VALUES
           ('Geometry', 0)
		   ,('Algebra', 0)
		   ,('History', 0)
		   ,('Physical training', 0)
		   ,('Ukrainian language', 0)
		   ,('Ukrainian literature', 0)
		   ,('Foreign literature', 0)
GO

INSERT INTO [dbo].[tblRoom]
           ([Number]
		   ,[Deleted])
     VALUES
           (1, 0)
		   ,(2, 0)
		   ,(3, 0)
		   ,(4, 0)
		   ,(5, 0)
		   ,(6, 0)
		   ,(7, 0)
		   ,(8, 0)
		   ,(11, 0)
		   ,(12, 0)
		   ,(13, 0)
		   ,(14, 0)
		   ,(15, 0)
GO

INSERT INTO [dbo].[tblGroup]
           ([Name]
		   ,[Deleted])
     VALUES
            ('7-A', 0)
		   ,('7-B', 0)
		   ,('8-A', 0)
		   ,('8-B', 0)
		   ,('9-A', 0)
		   ,('9-B', 0)
		   ,('10-A', 0)
		   ,('10-B', 0)
		   ,('11-A', 0)
		   ,('11-B', 0)

GO

INSERT INTO [dbo].[tblTeacher]
           ([Name]
           ,[Surname]
		   ,[Deleted])
     VALUES
           ('Ksenia'
           ,'Nesobchak'
		   , 0)

		   ,('Ivan'
           ,'Plushkin'
		   , 0)

		   ,('Eugen'
           ,'Samijskiy'
		   , 0)

		   ,('Luda'
           ,'Som'
		   , 0)

		   ,('Roman'
           ,'Bezfantaziynuy'
		   , 0)

		   ,('Andriy'
           ,'Ostanniy'
		   , 0)
GO


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
           (1
           ,1
           ,1
           ,1
           ,2016
           ,2
           ,1
           ,1
		   ,0)

		   ,(2
           ,2
           ,2
           ,2
           ,2016
           ,2
           ,1
           ,2
		   ,0)

		   ,(3
           ,3
           ,3
           ,3
           ,2016
           ,2
           ,1
           ,3
		   ,0)

		   ,(4
           ,4
           ,4
           ,4
           ,2016
           ,2
           ,1
           ,4
		   ,0)

		   ,(5
           ,5
           ,5
           ,5
           ,2016
           ,2
           ,1
           ,5
		   ,0)
		   
		   ,(1
           ,1
           ,1
           ,1
           ,2016
           ,2
           ,2
           ,2
		   ,0)
GO

set identity_insert tblUser on;

insert into tblUser (Id, FirstName, Surname, [Login], [Password], [Disabled])
	values
				(1, 'UserName', 'UserSurName', 'Admin', '21232f297a57a5a743894a0e4a801fc3', 0)

set identity_insert tblUser off;

GO