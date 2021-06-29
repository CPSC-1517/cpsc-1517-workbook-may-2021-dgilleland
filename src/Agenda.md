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
-->

## Monday (June 28)

- Understand your **Web Host Environment**
- Finish Event Form sample
  - Use an `UpcomingEvent` class for binding
- Creating Razor Pages
  - `dotnet new page -n PageName -o Pages`
- HTML 5 Form Elements
  - Functional User Elements:
    - `<form>`, `<input>` (and `<datalist>`), `<select>`/`<option>`, `<textarea>`, `<button>`
  - Semantic (*the meaning of the content*) Form Elements:
    - `<label>`, `<output>` ,`<fieldset>`, `<legend>`
  - Common attributes: `name`, `value`
  - Validation attributes: `required`, *etc.*
- LibMan and awsm.css

