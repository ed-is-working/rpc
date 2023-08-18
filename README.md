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
