# Exploring .NET 7, Web APIs, and the Entity Framework

## Description

The objective is to create a service that will serve to manage characters / users and add login/logout (auth)
functionality using JSONWeb Tokens

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


## TODOs

* map out implementation for testing with Insomnia or Postman
* create a simple webpage with fetch() methods to test login/logout
* update documentation
* code cleanup
* repo cleanup 
  
## Requirements

* ASP.NET 7.x
* MS SQL Server Express or Developer Edition (currently using 2022)
* (Windows Only) SQL Server Management Studio
* (Mac Only) Docker Container to setup MS SQL Server
* (Mac Only) Azure Data Studio

## Setup
