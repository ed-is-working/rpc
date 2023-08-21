# JSON Web Token Authentication Exploration

## Description

The objective is to create a service that will serve to manage characters / users and add login/logout (auth)
functionality using JSONWeb Tokens with .NET 7,Exploring Web APIs, and the Entity Framework as the backend

## Updates

* Added initial Character / User Model + Enum, Character / User Class
* Added API calls to get list of Characters / Users, and get single Character / User (R in CRUD)
* Added remaining method calls to the service for Create (Insert), Update and Delete operations (CUD in CRUD)
* Added Core Entity Framework, Core Entity Framework Design, Core Entity Framework - MS SQL Server Support
* Added MS SQL (Mac, Docker) and Azure Data Studio (instead of SQL Server Management Studio)
* Added correct(!) connection string for MS SQL in Docker for Mac (TODO: add for windows)
* Added Data Context to map models to MS SQL Tables; setup migrations
* Added Login Functionality
* Added JSON Web Tokens for secure auth
* Added secured method testing for Swagger
* Added basic ID filter with JSON Auth to get claimed data
* Added MS SQl Server backup file to repository
* Exported Sample Postman Collection to repository
* Created Simple Web Pages to illustrate access to API

## TODOs

* update documentation
* code cleanup
* repo cleanup
  
## Requirements

* ASP.NET 7.x
* MS SQL Server Express or Developer Edition (currently using 2022)
* (Windows Only) SQL Server Management Studio
* (Mac Only) Docker Container to setup MS SQL Server
* (Mac Only) Azure Data Studio

## (WIP) Setup

1. Install MS SQL Server.
   1. Windows Users can use Express or Developer Editions
   2. Mac Users can set up MS SQL Server in a docker container.

useful resources:

* [Development with MS SQL Server 2022 inside Docker containers - Mac](https://devblogs.microsoft.com/azure-sql/development-with-sql-in-containers-on-macos/)
* [How to connect MS SQL Server Docker Container and Azure Data Studio - Mac](https://www.freecodecamp.org/news/cjn-how-to-connect-your-microsoft-sql-server-docker-container-with-azure-data-studio/)
* [QuickStart: Run SQL Server Linux Container Images with Docker](https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&pivots=cs1-bash)
* [SQL Server Installation Guide - Windows](https://learn.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server?view=sql-server-ver16)

2. Install a GUI to manage your MS SQL Server
   1. Windows Users can use SQL Server Management Studio
   2. Mac Users can use Azure Data Studio

useful resources

* [Download SQL Server Management Studio - Windows](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
* [Download Azure Data Studio - Mac](https://learn.microsoft.com/en-us/sql/azure-data-studio/?view)

3. Install the Microsoft .NET CLI that is appropriate for your OS
   1. The [.NET CLI](https://dotnet.microsoft.com/en-us/download) comes with the .NET SDK

4. Once the .NET CLI is installed, you can proceed to install the following NuGET packages from <https://www.nuget.org>
   1. [DependencyInjection Support](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection)
   2. [Bearer Token Support](Microsoft.AspNetCore.Authentication.JwtBearer)
   3. [MS Open API](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi)
   4. [MS Static API](https://www.nuget.org/packages/Microsoft.AspNetCore.StaticFiles)
   5. [MS Entity Framework Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
   6. [MS Shared Design Time Components for Entity Framework Core Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design)
   7. [Microsoft SQL Server database provider for Entity Framework Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)
   8. [Swagger Tools for documenting APIs built on ASP.NET Core](https://www.nuget.org/packages/Swashbuckle.AspNetCore)
   9. [Additional Filters for Swashbuckle](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Filters)

5. Restore the copy of the MS SQL database found as a zip file in the db folder of this repo. (or recreate it using the attached schema image found with this README)
6. Once the DB has been restored, open the project workspace containing all the files and folders in this repo in an IDE such as JetBrains Rider, Visual Studio or Visual Studio Code.
7. Make sure to adjust the connection string found in appsettings.json to appropriately connect to your application from within the project. 

## Schema

![Simple DB Schema](./db/Users-Characters-Schema.png "Simple DB Schema")

## Notes

Each feature that was built-out has its own branch and is functionally complete in each branch.
You can view the specific commits in the log for each branch to see the changes performed there.

## Nice-To-Haves

* add an intermediate node middleware to act as a bastion to API access
* refactor characters to employees
* Add CRUD functionality to manage characters
* Create seeders (instead of MS SQL backup)
