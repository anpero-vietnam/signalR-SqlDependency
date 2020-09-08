
https://github.com/christiandelbianco/monitor-table-change-with-sqltabledependency/blob/master/README.md
Install-Package SqlTableDependency -Version 8.5.4
1) Add new connection string with name ="connectionString"
2) Update <httpRuntime targetFramework="4.6.2" or higher to using web socket

update database to test SqlTableDependency 
3) ALTER DATABASE [DataBaseName] SET ENABLE_BROKER
4) ALTER DATABASE [DataBaseName] SET TRUSTWORTHY ON

create table to test SqlTableDependency 
Create table Users(
UserName nvarchar(300),
UserId [uniqueidentifier] NOT NULL,
Status varchar(30)
)