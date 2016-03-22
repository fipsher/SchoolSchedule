FIRST download and install MS SQL Server 2014 and MS SQL Managemant studio from https://www.microsoft.com/ru-ru/download/details.aspx?id=42299 
there you have a list of downloads. You shold chose:

Express 32BIT\SQLEXPR_x86_RUS.exe
OR 
Express 64BIT\SQLEXPR_x64_RUS.exe

AND

MgmtStudio 32BIT\SQLManagementStudio_x86_RUS.exe
OR	
MgmtStudio 64BIT\SQLManagementStudio_x64_RUS.exe

SECOND Run SchoolScheduleManager.sln and choose DesktopUI progect
 then you shold change connection string in this pattern :
 
Server=myServerAddress;Database=myDataBase;User Id=myUsername;
Password=myPassword;

THIRD chose Database progect and open Create.sql
there you should uncomment first twi lines and change DB name
if you changed DB name you shold change Line USE SchooldeSchedule into USE YourDbName in all scripts that available
in Database progect.
RUN Create.sql
RUN Procs.slq
RUN Insert.sql

FOURTH to use your prog you have to authenticate 
Loggin: Admin
Pass: admin

enjoy this app.

      