# Agenda

<!--
## ~~Monday~~

- "Big Picture"
- Create a database from SQLCMD: `sqlcmd -Q "CREATE DATABASE Banking"`
  - https://www.sqlshack.com/working-sql-server-command-line-sqlcmd/
- EF Core Intro
- EF Core Demo
  - Setup and read `appsetting.json`

## ~~Wednesday~~

- EF Core Demo (cont.)
  - My Simple Database

## Friday

- Another Database Demo
- In-Class #1 and Exercise #2 Review
- In-Class #2 Announcement

## Monday

- Take-Home #3 - **Extension to June 25, 5:00 PM**
  - Class Status??
  - Issues/Questions
  - "Reboot" version - **Bonus Take-Home** - *some things I want to improve in the instructions*
    - Better setup instructions for the driver
      - esp. regarding "appsettings.json" and Dependency Injection (*which I hadn't expected you to apply to this take-home*)
    - Guidance on the "looping" inside the `DataMigrationServices.FileTransfer` method
      - How the CSV file is loaded (*remove the use of the `Registry` record and just use the `SerialNumber` entity*)
      - How looping should be procesed with regard to the call to `.SaveChanges()`
      - Have the method return a count of how many records were inserted
    - Clearer instructions on calculations to be done in the `DataMigrationServices.AddRegisteredOwner` method
- ASP.NET Core Web Applications
  - Empty Web Application
  - HTML Review
  - HTML Forms
  - Razor Page Introduction

## Wednesday

> In-Class #2

## Friday

- ASP.NET Core Web Application
  - Razor Pages Application Setup


----

## **Next** Monday

## **Next** Wednesday

## **Next** Friday

## Monday (June 28)

- Understand your **Web Host Environment**
- Finish Event Form sample
  - Use an `UpcomingEvent` class for binding
- Creating Razor Pages
  - `dotnet new page -n PageName -o Pages`

-->

## Wednesday (June 30)

- Homework
  - **CPSC-1517.github.io** Readings:
    - [HTML Articles](https://cpsc-1517.github.io/html/)
    - [Razor](https://cpsc-1517.github.io/razor/)
- LibMan and awsm.css
- HTML 5 Form Elements
  - Functional User Elements:
    - `<form>`, `<input>` (and `<datalist>`), `<select>`/`<option>`, `<textarea>`, `<button>`
  - Semantic (*the meaning of the content*) Form Elements:
    - `<label>`, `<output>` ,`<fieldset>`, `<legend>`
  - Common attributes: `name`, `value`
  - Validation attributes: `required`, *etc.*
- Peeking at Form Request Values
  - The first **`T`** in *HTTP*
  - The `name` and `value` attributes
  - Sending via **`GET`** vs **`POST`**

## Friday

- **Client-Server**
  - [Tiers and Layers](https://cpsc-1517.github.io/clientserver/)
  - Create a) web application, b) class library and c) solution - [*(see demo)*](#client-server-setup-demo)
  - Understanding the "App" as the "domain"
    - BLL, DAL, Entities
  - Understanding the "Web" as the "UI"
- **Registering Services** in `Startup.cs`


## Next Week...

- Uploading Files
- Displaying Tabular Data
  - From Database
  - Searching/Filtering
- CRUD Applications
  - Page Handlers for Posting

## Next Week...

- Validating User Input

----

## Appendix

### Client-Server Setup Demo

In this demo, there will be two projects. A Web project (`WebApp.csproj`) and a Class Library (`WestWind.csproj`).

Additionally, there will be a solution file (`WestWindDemo.sln`) referencing both projects (*not entirely needed when working in VS-Code, but required for working in VS-2019*).
    
```ps
# Switch to src/ folder
cd src
# Create a Razor Pages Web Application
dotnet new webapp -n WebApp -o WestWind.Web
# Create a Class Library
dotnet new classlib -n WestWind -o WestWind.App
# Create a Solution (solutions can hold multiple projects)
dotnet new sln -n WestWindDemo
# Add the two projects to the solution (starting with the Web App)
dotnet sln add WestWind.Web/WebApp.csproj
dotnet sln add WestWind.App/WestWind.csproj
# Allow the WebApp to use the WestWind project
dotnet add WestWind.Web/WebApp.csproj reference WestWind.App/WestWind.csproj
```
