# SchoolSchedule
FIRST download and install MS SQL Server 2014 and MS SQL Managemant studio from<br/> https://www.microsoft.com/ru-ru/download/details.aspx?id=42299 <br/>
there you have a list of downloads. You shold chose:<br/>

Express 32BIT\SQLEXPR_x86_RUS.exe<br/>
OR <br/>
Express 64BIT\SQLEXPR_x64_RUS.exe<br/>

AND<br/>

MgmtStudio 32BIT\SQLManagementStudio_x86_RUS.exe<br/>
OR	<br/>
MgmtStudio 64BIT\SQLManagementStudio_x64_RUS.exe<br/>

SECOND Download Visual studio 2015 from https://www.visualstudio.com/ then install it.

THIRD Run SchoolScheduleManager.sln and choose DesktopUI progect<br/>
hen you shold change connection string in <br/>
SchoolScheduleManager\SchoolScheduleManager.DesktopUI\App.config using this pattern: :<br/>
 
Server=myServerAddress;Database=myDataBase;User Id=myUsername;<br/>
Password=myPassword;<br/>

FOURTH chose Database progect and open Create.sql<br/>
there you should uncomment first twi lines and change DB name<br/>
if you changed DB name you shold change Line USE SchooldeSchedule into USE YourDbName in all scripts that available<br/>
in Database progect.<br/>
RUN Create.sql<br/>
RUN Procs.slq<br/>
RUN Insert.sql<br/>


FIFTH to use your prog you have to authenticate <br/>
Loggin: Admin<br/>
Pass: admin<br/>

enjoy this app.

      

      
