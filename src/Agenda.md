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

## Monday (July 5)

- Follow-up of Friday's class (Database and Services Hookups)
  - **Registering Services** in `Startup.cs`
  - Adjusting `appsettings.json`
- Uploading Files
  - Deciding what kinds of files you want to upload (csv, images, etc)
    - [CSV File Generator](https://extendsclass.com/csv-generator.html)
    - [AI Generated Photos](https://generated.photos)
  - Deciding what to do with the uploaded file(s)
    - Save to disk (`Directory` and `File` classes)
  - HTML Side
    - `<form method="post" enctype="multipart/form-data">`
    - `<input type="file" accept=".csv">` + `asp-for="PropertyName"`
  - C# Side
    - `[BindProperty] public IFormFile PropertyName { get; set; }`
    - Processing: Save to a location within the web application

## Wednesday (July 7)

> ### View Products
>
> <input placeholder="Partial Name" /> <button>Filter Results</button>
>
> | Name ▲ | Quantity Per Unit | Unit Price |
> |------|-------------------|------------|
> | Alice Mutton | 20 - 1 kg tins | $ 39.00 |
> | Aniseed Syrup | 12 - 550 ml bottles | $ 10.00 |
> | Boston Crab Meat | 24 - 4 oz tins | $ 18.40 |
> | ... | ... | ... |

- Displaying Tabular Data
  - From Database
    - `Product` entity for *Products* table
    - `WestWindContext.Products` property
  - New Razor Page - `ViewProductCatalog`
    - Start with listing all products
    - Pagination - 10 per page
      - **Q)** - What logic do we need for tracking pagination?
      - **I)** - How do other sites do it? (like [**Memory Express**](https://memoryexpress.com))
      > **Side-Note**
      >
      > - You don't need a list to play with pagination
      > - Distinguishing between `GET` and `POST` requests: Hyperlinks and Form Submissions
      > - Learning about [Tag Helpers](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-5.0)

## Friday (July 9)

- Displaying Tabular Data
  - New Razor Page - `ViewProductCatalog`
    - **Questions** from last class...
    - Pagination - *cont*
      - Total number of search results
      - Total number of pages
      - Max Page Links (5, 7, 10)
      - Next/Previous
        - [&lsaquo;](https://www.toptal.com/designers/htmlarrows/punctuation/single-left-pointing-angle-quotation-mark/) `&lsaquo;`
        - [&rsaquo;](https://www.toptal.com/designers/htmlarrows/punctuation/single-right-pointing-angle-quotation-mark/) `&rsaquo;`
        - [&laquo;](https://www.toptal.com/designers/htmlarrows/punctuation/double-left-pointing-angle-quotation-mark/) `&laquo;`
        - [&raquo;](https://www.toptal.com/designers/htmlarrows/punctuation/double-right-pointing-angle-quotation-mark/) `&raquo;`
      - **Object**ifying Pagination

## Monday (July 12)

- Displaying Tabular Data
  - New Razor Page - `ViewProductCatalog`
    - **Questions** from last class...
      - Understanding the `Directory` and `Path` classes in `System.IO`
      - Programmatically renaming files
      - Review `IFormFile`
    - Pagination - *cont*
      - **Why** pagination on the **database side** is the **better way**

## Friday (July 16)
- Displaying Tabular Data
    - Searching/Filtering (by partial product name)
  - Practice: `ViewCustomers`
    - Display `CompanyName`, `ContactName`, `ContactTitle`, `ContactEmail`
- CRUD Applications
  - Edit Page for `Product` (`ProductEditor.cshtml`)

-->

## Monday (July 19)

- In-Class 3 - *Moved to Friday **July 23***
  - Multiple Choice Questions
  - Coding Questions
    - Razor Pages - User I/O
- **Tips on SQL Exceptions**
- Logic error in Product Catalog search results ([Issue 7](https://github.com/CPSC-1517/cpsc-1517-workbook-may-2021-dgilleland/issues/7))
- CRUD Applications
    - Setup page
    - `Supplier` and `Category` Entities for drop-downs
  - **Add** and **Edit** Links from tabular page
  - BLL Methods to Add/Update/Delete per-table
  - Page Handlers for Add/Update/Delete
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

### Configuring Services

The **database context** service is configured in the [**`ConfigureServices`**](https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#dbcontext-in-dependency-injection-for-aspnet-core) method of the `Startup.cs` class.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
}
```

Other BLL services can be added as *Transient* services (these are created each time they are requested).

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<TService>();
}
```
