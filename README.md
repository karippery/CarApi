# CAR API

In this repo I would like  to give an example  how to build a WebAPI with ASP.NET Core.

This repo contains a controller which is dealing with Cars. You can POST/GET/GETById/PUT/and DELETE them.

## project,  pulgins and Packages 

- we use ASP.NET CORE Web API 3.1 version 
- swagger
- serilog
- Microsoft.EntityFrameworkCore 3.1.8
- Microsoft.EntityFrameworkCore tools 3.1.8
- Microsoft.EntityFrameworkCore design 3.1.8
- Microsoft.EntityFrameworkCore sqlite 3.1.8

## Setup database (sqlite)

Here I use sqlite for easy and simple 

Before run the command you need to delete car.db from repo  carApi/src/CarAPI.API/

create migrations, apply migrations, and generate code for a model based on an existing database. The commands are an extension to the cross-platform dotnet command, which is part of the .NET Core SDK. These tools work with .NET Core projects.dotnet ef can be installed as either a global or local tool.

`dotnet tool install --global dotnet-ef`

Updates the database to the last migration or to a specified migration.

`dotnet ef database update --startup-project CarAPI.API/CarAPI.API.csproj`

## Serilog

Serilog provides diagnostic logging to files, the console, and elsewhere. It is easy to set up, has a clean API, and is portable between recent .NET platforms.

## Entities

our CAR API have 4 properties

- id : int 
- Name : string
- Owner : string
- Model : int 

## controller

we have basic API controller 

- CreateCar 
   if name,model and owner are not equal to any elemets in tables then create new car otherwise run bad request 
   
- GetAllCars

- GetCarById 

   if Id is not found  run bad request 

- UpdateCar


  if Id is not found  run bad request 
- DeleteCar 




