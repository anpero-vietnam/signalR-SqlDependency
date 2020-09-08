
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
5) go to /SqlDependency page
6) Insert or update,delete to SqlTableDependency function. In this demo only UserId=1 canbe reveice messenge for Update,remove data
insert into Users(UserId,UserName,Status) values('1','User Name 01','actice')