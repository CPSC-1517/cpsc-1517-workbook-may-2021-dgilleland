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

## Monday (July 19)

- In-Class 3 - *Moved to Friday **July 23***
  - Multiple Choice Questions
  - Coding Questions
    - Razor Pages - User I/O - POST/GET Requests
- **Tips on SQL Exceptions**
- Logic error in Product Catalog search results ([Issue 7](https://github.com/CPSC-1517/cpsc-1517-workbook-may-2021-dgilleland/issues/7))
- CRUD Applications
    - Setup page
    - `Supplier` and `Category` Entities for drop-downs

## Wednesday (July 21)

- CRUD Applications per-table
  - **Add** and **Edit** Links from tabular page
  - BLL Methods to Add
  - Page Handlers for Add
- Validating User Input

## Friday (July 23)

- **In-Class 3**


## Monday (July 26)

- CRUD Applications per-table
  - BLL Methods to Update/Delete
  - Page Handlers for Update/Delete

## Wednesday (July 28)

- Project Introduction
  - Deliverable #1 Walk-through
- UX Improvements
  - Client-side confirmation of delete: `onclick="return confirm('Are you sure you want to delete this record?');"`
  - Enable/Disable Update/Delete buttons: `@(Model.ProductItem == null ? "" : "disable")`

-->

## Friday (July 30)

- [Reverse Engineering Databases](#reverse-engineering)
- Validating User Input
  - Types of Validation
    - **Browser**
      - *Client-Side* - Provides User Guidance
      - *Web-Server-Side* - `try/catch`
    - **Database** - Ensure Data Integrity
    - **Business Processing** - Enforce business rules
  - Try/Catch
  - Data Annotations
  - `asp-validation-for`
    - `libman install jquery -p unpkg`
    - `libman install jquery-validation -p unpkg`
    - `libman install jquery-validation-unobtrusive -p unpkg`
  - Read [https://www.learnrazorpages.com/razor-pages/validation](https://www.learnrazorpages.com/razor-pages/validation)

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

----

### Reverse Engineering

> More information on [Reverse Engineering can be found here](https://docs.microsoft.com/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli).

First of all, your project will need the package `Microsoft.EntityFrameworkCore.Design`.

```shell
dotnet add package Microsoft.EntityFrameworkCore.Design
```

A simple run to reverse engineer an entire database would look like the following. Check the [usage](#dbcontext-scaffold-usage) section below for the help information generated by running `dotnet ef dbcontext scaffold --help`.

```shell
dotnet ef dbcontext scaffold "Server=.;Database=WestWind;Trusted_Connection=true;" Microsoft.EntityFrameworkCore.SqlServer
```

For the current state of the application where the focus is on the `Products`, `Suppliers`, `Categories`, and `Shippers` tables, the following is the complete command to generate the C# code for the DAL and Entity classes.

```shell
dotnet ef dbcontext scaffold "Server=.;Database=WestWind;Trusted_Connection=true;" Microsoft.EntityFrameworkCore.SqlServer --no-build --verbose --context WestWindContext --context-dir DAL --output-dir Entities --table Products --table Suppliers --table Categories --table Shippers --data-annotations --namespace WestWind.App.Entities --context-namespace WestWind.App.DAL --force
```

After running this on our existing system, there may be some compiler errors (typically in relationship to Entity properties that have been named slightly differently than what we used - e.g.: `ProductId` instead of `ProductID`).

#### `dbcontext scaffold` Usage

```
Usage: dotnet ef dbcontext scaffold [arguments] [options]

Arguments:
  <CONNECTION>  The connection string to the database.
  <PROVIDER>    The provider to use. (E.g. Microsoft.EntityFrameworkCore.SqlServer)

Options:
  -d|--data-annotations                  Use attributes to configure the model (where possible). If omitted, only the fluent API is used.
  -c|--context <NAME>                    The name of the DbContext. Defaults to the database name.
  --context-dir <PATH>                   The directory to put the DbContext file in. Paths are relative to the project directory.
  -f|--force                             Overwrite existing files.
  -o|--output-dir <PATH>                 The directory to put files in. Paths are relative to the project directory.
  --schema <SCHEMA_NAME>...              The schemas of tables to generate entity types for.
  -t|--table <TABLE_NAME>...             The tables to generate entity types for.
  --use-database-names                   Use table and column names directly from the database.
  --json                                 Show JSON output. Use with --prefix-output to parse programatically.
  -n|--namespace <NAMESPACE>             The namespace to use. Matches the directory by default.
  --context-namespace <NAMESPACE>        The namespace of the DbContext class. Matches the directory by default.
  --no-onconfiguring                     Don't generate DbContext.OnConfiguring.
  --no-pluralize                         Don't use the pluralizer.
  -p|--project <PROJECT>                 The project to use. Defaults to the current working directory.
  -s|--startup-project <PROJECT>         The startup project to use. Defaults to the current working directory.
  --framework <FRAMEWORK>                The target framework. Defaults to the first one in the project.
  --configuration <CONFIGURATION>        The configuration to use.
  --runtime <RUNTIME_IDENTIFIER>         The runtime to use.
  --msbuildprojectextensionspath <PATH>  The MSBuild project extensions path. Defaults to "obj".
  --no-build                             Don't build the project. Intended to be used when the build is up-to-date.
  -h|--help                              Show help information
  -v|--verbose                           Show verbose output.
  --no-color                             Don't colorize output.
  --prefix-output                        Prefix output with level.
  ```


#### Improved `site.css`

Here's an improved `site.css` for use with the awsm.css library.

```css
body {
    max-width: 100%;
    margin: 0;
    padding: 0;
}

    body header, body main, body footer, body article {
        position: relative;
        max-width: 100%;
        margin: 0 10rem;
    }

    body > header {
        max-width: 100%;
        margin: 0;
    }

        body > header > nav {
            /* Include if you have multiple <ul> children 
            display: grid;
            grid-template-columns: auto 80rem auto; 
            */
            background-color: black;
            color: white;
            margin-top: 0;
            margin-bottom: 0;
        }

            body > header > nav > ul {
              max-width: 100%;
              margin: 0 10rem 1rem 10rem;
              padding-top: 1rem;
              min-height: 3rem;
            }

nav > ul > li {
    margin-top: 0.25em;
}

body > header a, body > header a:visited {
    color: whitesmoke;
    font-weight: bold;
    text-decoration: none;
}

header > figure {
    height: 200px;
    overflow: hidden;
    margin-top: 0;
}

footer a {
    text-decoration: none;
}

header > nav > ul:last-child {
    text-align: right;
}

header > nav > ul:last-child {
  text-align: left;
}

main > *:first-child {
    margin-top: 1rem;
}

form {
    margin-left: 0;
}
form label > select {
    display: inline-block;
}
```
