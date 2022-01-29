# CAR API

In this repo I would like  to give an example  how to build a WebAPI with ASP.NET Core.

This repo contains a controller which is dealing with Cars. You can POST/GET/GETById/PUT/and DELETE them.

## project,  pulgins and Packages 

- we use ASP.NET CORE Web API 3.1 version 
- swagger
- serilog
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore tools
- Microsoft.EntityFrameworkCore design
- Microsoft.EntityFrameworkCore sqlite

## Setup database (sqlite)

Here I use sqlite for easy and simple 

Before run the command you need to delete car.db from repo  carApi/src/CarAPI.API/

create migrations, apply migrations, and generate code for a model based on an existing database. The commands are an extension to the cross-platform dotnet command, which is part of the .NET Core SDK. These tools work with .NET Core projects.dotnet ef can be installed as either a global or local tool.

`dotnet tool install --global dotnet-ef´
