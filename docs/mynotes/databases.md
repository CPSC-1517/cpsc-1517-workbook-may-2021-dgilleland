# Using Databases

![](../images/stick_figure_working_on_database_400_clr_8845.png)

- What is Entity Framework?
  - A NuGet package (add to your project whenever it needs to work with a database)

  ```ps
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  ```

  - There's also a CLI Tool for this (a one-time install)

  ```ps
  dotnet tool install --global dotnet-ef
  ```

- What is a "Database Model"?
  - A set of classes that represent the tables and the database as a whole
  - **"Entity"** classes for tables
  - **"Database Context"** class for the database
- What's different between a database model and an ERD?
  - An ERD is a picture of what's in the database (tables/relations)
  - A database model is the code that "reflects" the structure of the database tables and presents a way to "hold" information that we read from/write to the database
- How do we connect to the database from our program?
  - Connection informaiton can be summarized in something called a **Connection String**
  - Connection Strings are used for any kind of database
  - https://www.connectionstrings.com/

| How to go from this | To this |
|-|-|
| ![](../images/hard_working_on_computer_anim_150_clr_7364.gif) | ![](../images/student_working_on_laptop_anim_150_clr_1849.gif) |

