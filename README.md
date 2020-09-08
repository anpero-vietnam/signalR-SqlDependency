# SignalR simple example and SignalR + SqlTableDependency
 1) Signalr simple example
 2) Signalr simple example trigger Hub function from MVC Control
 3) Simple set userid and send messege to logger by userid
 3) SqlTableDependency example
 
SqlTableDependency is a high-level C# component to used to audit, monitor and receive notifications on SQL Server's record table change.
For all Insert/Update/Delete operation on monitored table, TableDependency receive events containing values for the record inserted, changed or deleted, as well as the DML operation executed on the table, eliminating the need of an additional SELECT to update application’s data cache.

How to user user SqlTableDependency

1) Install-Package SqlTableDependency -Version 8.5.4

2) Add new connection string with name ="connectionString"

3) Update .net Framework="4.6.2" or higher to using web socket
update database 
3) ALTER DATABASE [DataBaseName] SET ENABLE_BROKER

4) ALTER DATABASE [DataBaseName] SET TRUSTWORTHY ON
create table to test SqlTableDependency 
Create table Users(
  UserName nvarchar(300),
  UserId [uniqueidentifier] NOT NULL,
  Status varchar(30)
)

5) go to page /SqlDependency
6) Insert/Update/Delete and see change in /SqlDependency page

# Optimization

1) Open Startup.cs to see how to set or get userId

If you need help don't hesitate to mail me: thangtd.hn@gmail.com
