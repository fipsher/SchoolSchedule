USE SchoolSchedule
GO

DROP TABLE [dbo].[tblLesson]
GO
DROP TABLE [dbo].tblGroup
GO
DROP TABLE [dbo].tblRoom
GO
DROP TABLE [dbo].[tblSubject]
GO
DROP TABLE [dbo].[tblTeacher]
GO
DROP TABLE [dbo].[tblUser]
GO

DROP PROCEDURE [dbo].[spAddGroup]
GO
DROP PROCEDURE [dbo].[spAddRoom]
GO
DROP PROCEDURE [dbo].[spAddSubject]
GO
DROP PROCEDURE [dbo].[spAddTeacher]
GO
DROP PROCEDURE [dbo].[spGetUserByLogin]
GO
DROP PROCEDURE [dbo].[spInputLesson]
GO
DROP PROCEDURE [dbo].[spRemoveGroup]
GO
DROP PROCEDURE [dbo].[spRemoveLesson]
GO
DROP PROCEDURE [dbo].[spRemoveRoom]
GO
DROP PROCEDURE [dbo].[spRemoveSubject]
GO
DROP PROCEDURE [dbo].[spRemoveTeacher]
GO
