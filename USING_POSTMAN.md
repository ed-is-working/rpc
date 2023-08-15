# Using Postman

## Introduction
This document explains how to test ASP.NET Core Web API endpoints using Postman

## Setup
It is assumed that you have done the following:

1. Cloned the project from the repository
1. Opened the project in Visual Studio or Visual Studio Code
1. Installed or configured any extensions required for the project
1. Have the current project running using `dotnet watch run` with the *dotnet cli*
2. Launched Postman
3. Import the Postman Settings Collection file provided with this repository ( in ./db/ folder)


## Testing the Web API

1. You will need to login first to create a JSON Web Token. You will then apply it to your settings for the Postman collection, using Bearer Token Authentication.
2. Once you have created a login and got a token, then perform the requests listed in the postman collection.

