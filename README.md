# Example project dotnet core 5

!!! working in progress !!!

An experiment of a project structure with many repository from different sources/providers in dotnet core 5.

## Create a project

Open visual studio and create a *ASP.NET Core Web API*

Give a *Solution name* (for example: *it.example.dotnetcore5*) and add a project name to solution name (for example: *it.example.dotnetcore5.webapi*)

Select *Target Framework* as *.NET 5.0 (Current)*, *Authentication Type* None.

This project will be your WebApi controllers.

## Add Domain model project

Add a new project *Class library (for .NET Standard or .NET Core)*, call it (for example: *it.example.dotnetcore5.domain*) and select *Target Framework* as *.NET 5.0 (Current)*

This project will be your domain model class. This project contains Interfaces (models, repositories and services) and Classes for the Models of the solution.

## Add DAL(s) project(s)

Add a new project *Class library (for .NET Standard or .NET Core)*, call it (for example: *it.example.dotnetcore5.dal.<your_provider>*) and select *Target Framework* as *.NET 5.0 (Current)*

This project will be your dal classes and contexts, you have to create a project for each providers you need (for example: json, restapi, csv, mysql ef, sqlserver ef, sqllite ef, etc).

This project have reference to Domain project for import Interfaces.

### Dapper provider

Add this nuget packages:
- *Dapper*
- *Microsoft.Extensions.Configuration.Abstractions*
- *MySql.Data*
- *System.Data.SqlClient*

### EF providers

#### EF SqlServer provider (database first)

Install the follow nuget package:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools (for scaffolding)
- Microsoft.EntityFrameworkCore.SqlServer

Set this project as Startup project (in our case this is a library and not the primary project - webapi project)

Open *Package Manager Console* and set this project as "Default project", run this command:

```shell
Scaffold-DbContext <your_connection_string> Microsoft.EntityFrameworkCore.SqlServer -OutputDir <your_folder_ef> -Table <your_table> -f
```

- <your_connection_string> : is the connection string of your sql server db
- <your_folder_ef> : is the folder where you want put model created with scaffolding
- (optional) <your_table> : use param *-Table* if you want made scaffolding of specific table (without it will be created all the table in database)
- (optional) -f : use for override existing ef models and Context.

You can run the same command any time you want create or update the ef models.

#### EF MySQL provider (database first)

Install the follow nuget package:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools (for scaffolding)

Set this project as Startup project (in our case this is a library and not the primary project - webapi project)

Open *Package Manager Console* and set this project as "Default project", run this command:

```shell
Scaffold-DbContext <your_connection_string> MySql.EntityFrameworkCore -OutputDir <your_folder_ef> -Table <your_table> -f
```

- <your_connection_string> : is the connection string of your sql server db
- <your_folder_ef> : is the folder where you want put model created with scaffolding
- (optional) <your_table> : use param *-Table* if you want made scaffolding of specific table (without it will be created all the table in database)
- (optional) -f : use for override existing ef models and Context.

You can run the same command any time you want create or update the ef models.
#### EF Sqlite provider (database first)

Install the follow nuget package:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools (for scaffolding)


##### Install Sqlite in local (windows)

1. Download sqlite dll and tools from this website
https://sqlite.org/download.html

2. Extract file in a folder (for example c:\sqlite)

3. Add path in system variables

4. Install a client for query to db (for example https://dbeaver.io/)

5. Create database
open console, launch command

```cmd
sqlite3 <db_name>.db
```

and then, when sqlite promp is ready
```cmd
.databases
```

now you have a ready database to open with client


### Json file provider

Install the follow nuget package:
- Newtonsoft.Json



## Add BL project

Add a new project *Class library (for .NET Standard or .NET Core)*, call it (for example: *it.example.dotnetcore5.bl*) and select *Target Framework* as *.NET 5.0 (Current)*

### Add Unit test project for BL layer

Install the follow nuget package:
- NUnit
- NUnit3TestAdapter
- NSubstitute
- Microsoft.NET.Test.SDK (for using vs Test Explorer)




### Add Integration test project for WebApi layer

Install the follow nuget package:
- NUnit
- NUnit3TestAdapter
- NSubstitute
- Microsoft.NET.Test.SDK (for using vs Test Explorer)
- Microsoft.AspNetCore.MVC.Testing (for create a Test Server)

When use test, re-configure Startup file in WebApi project, for example using a FakeRepository