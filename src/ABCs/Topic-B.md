# Starting with Classes - Part B

> As you move through each of the code examples and practice problems, be sure to **commit** your edits **frequently**.

## Demos

In these demos, the code is given to you. Integrate this code into the Topic project of the ABCs solution under the `B` folder. Be sure to wrap each class under the `Topic.B` namespace.

### `Person` Class

> This simple class illustrates and introduces the idea of fields (member variables) of a class. This example includes and introduces the idea of a driver. The driver also illustrates how a single class can be used to instantiate multiple, distinct objects.

* Data Attributes of the Person class:
  * FirstName : String
  * LastName : String
  * Age : Integer

```csharp
namespace Topic.B.Examples
{
    public class Person
    {
        /// <summary>This is the first name of the person</summary>
        public string FirstName;
        /// <summary>This is the last name of the person</summary>
        public string LastName;
        /// <summary>This is the person's age</summary>
        public int Age;
    }
}
```

```csharp
namespace Topic.B.Examples
{
    public class DemoPerson
    {
        public static void Main(string[] args)
        {
            Person someGuy;
            someGuy = new Person();
            someGuy.FirstName = "Harry";
            someGuy.LastName = "Burns";
            someGuy.Age = 25;

            Person someGirl;
            someGirl = new Person();
            someGirl.FirstName = "Sally";
            someGirl.LastName = "Albright";
            someGirl.Age = 25;

            string fullName;

            fullName = someGuy.FirstName + " " + someGuy.LastName;
            System.Console.WriteLine("Hi. My name is " + fullName);

            fullName = someGirl.FirstName + " " + someGirl.LastName;
            System.Console.WriteLine("Hi" + someGuy.FirstName +
                               ". My name is " + fullName);
        }
    }
}
```

----

### `Account` Class

> This simple class also illustrates fields. This example includes a driver.

* Data Attributes of the Account class:
  * AccountNumber : Integer
  * Balance : Real
  * OverdraftLimit : Double

```csharp
namespace Topic.B.Examples
{
    public class Account
    {
        public int AccountNumber;
        public double Balance;
        public double OverdraftLimit;
    }
}
```

```csharp
namespace Topic.B.Examples
{
    public class DemoAccountDriver
    {
        public static void Main(string[] args)
        {
            Account myAccount; // declares a reference variable to an Account object
            myAccount = new Account(); // creates the Account object.

            myAccount.Balance = 500000.00;
            myAccount.OverdraftLimit = 1000000.00;
            myAccount.AccountNumber = 123456;
        }
    }
}
```

----

### `Student` Class

> This class introduces a slightly more complex class by offering more fields. This example includes a driver illustrating how a single class can be used to instantiate multiple, distinct objects.

* Data Attributes of the Student class:
  * Name : String
  * Status : Character
  * StudentId : Integer
  * Program : String
  * GradePointAverage : Double
  * FullTime : Boolean

This example also includes two drivers. By using two drivers, this illustrates that separate "programs" can share/use the same class definition.
The first driver is a simple "test driver" to ensure that the class is "working". This introduces the student to the idea that it is necessary to "test" or prove that the code we are creating is valid.

The second driver illustrates how the a single class can act as the basis for creating many distinct objects.

```csharp
/**
 * Purpose: To illustrate
 *          Highlights:
 *          - Keywords: char, int, double
 *          - Grammar: variable declaration (fields)
 *          - Other:
 *              - Instance members
 */
namespace Topic.B.Examples
{
    public class Student
    {
        public string Name;                 // The full name of the student
        public char Status;                 // Status can be 'C' for Current, 'G' for Graduate or 'W' for Withdrawn
        public int StudentId;               // The school-provided student ID
        public string Program;              // The course program; e.g.: "COMP"
        public double GradePointAverage;    // GPA is from 1.0 to 9.0
        public bool FullTime;               // If the student is enrolled full-time
    }
}
```

```csharp
/**
 * Purpose: To illustrate
 *          Highlights:
 *          - Keywords: public, class, static, void, new
 *          - Grammar:
 */
namespace Topic.B.Examples
{
    public class DemoStudentDriver
    {
        public static void Main(string[] args)
        {
            Student bob, mary, joe, susan, frank;
            bob = new Student();
            mary = new Student();
            joe = new Student();
            susan = new Student();
            frank = new Student();

            bob.Name = "Bob McNalley";
            bob.Status = 'C'; // Current
            bob.Program = "COMP";
            bob.StudentId = 200765789;
            bob.GradePointAverage = 6.76;

            mary.Name = "Mary McTavishski";
            mary.Status = 'C'; //Current
            mary.Program = "COMP";
            mary.StudentId = 200765790;
            mary.GradePointAverage = 5.76;

            joe.Name = "Joe Jetson";
            joe.Status = 'C'; // Current
            joe.Program = "COMP";
            joe.StudentId = 200765792;
            joe.GradePointAverage = 4.66;

            susan.Name = "Susan Orlando";
            susan.Status = 'C'; // Current
            susan.Program = "COMP";
            susan.StudentId = 200765795;
            susan.GradePointAverage = 8.54;

            frank.Name = "Frank Smith";
            frank.Status = 'C'; // Current
            frank.Program = "COMP";
            frank.StudentId = 200765797;
            frank.GradePointAverage = 8.52;

            displayStudentInformation(bob);
        }

        public static void displayStudentInformation(Student someStudent)
        {
            System.Console.WriteLine(someStudent.Name);
            System.Console.WriteLine(someStudent.Status);
            System.Console.WriteLine(someStudent.Program);
            System.Console.WriteLine(someStudent.StudentId);
            System.Console.WriteLine(someStudent.GradePointAverage);
        }
    }
}
```

----

### `Employee` and `Company` Classes

> These are other classes similar to the Person and Student classes. These classes, however, "share" a driver, illustrating the fact that any given "program" typically uses more than one class. In addition, this driver introduces the ToString() and Parse() methods of the DateTime class.

* Data Attributes of the Employee class:
  * FirstName : String
  * LastName : String
  * SocialInsuranceNumber : Integer
  * YearlySalary : Real
  * EmploymentStartDate : Date
  * Gender : Character

```csharp
using System;
namespace Topic.B.Examples
{
    public class Employee
    {
        public string FirstName;
        public string LastName;
        public int SocialInsuranceNumber;
        public double YearlySalary;
        public DateTime EmploymentStartDate;
        public char Gender;
    }
}
```

* Data Attributes of the Company class:
  * Name : String
  * City : String
  * IsIncorporated : Boolean
  * BusinessStartDate : Date
  * NumberOfEmployees : Integer
  * GrossIncomeToDate : Real

```csharp
using System;
namespace Topic.B.Examples
{
    public class Company
    {
        public string Name;
        public string City;
        public bool IsIncorporated;
        public DateTime BusinessStartDate;
        public int NumberOfEmployess;
        public double GrossIncomeToDate;
    }
}
```

In the following driver, the Employee and Company classes are both being used, illustrating the fact that any given "program" typically uses more than one class. In addition, this driver introduces the overloaded ToString() method in the DateTime class to improve the output of displaying dates and the Parse() method to convert a string representation of a date to an actual DateTime instance.

```csharp
using System;
namespace Topic.B.Examples
{
    public class DemoCompanyAndEmployee
    {
        public static void Main(string[] args)
        {
            Company Acme = new Company();
            Employee Salesman = new Employee();
            Employee Shipper = new Employee();

            // Set the company's information
            Acme.Name = "Acme International";
            Acme.City = "Edmonton";
            Acme.BusinessStartDate = new DateTime(); // new Date() defaults to the current date
            Acme.IsIncorporated = false;
            Acme.NumberOfEmployess = 2;
            Acme.GrossIncomeToDate = 2152368.52; // $ 2 million, plus change

            // Set the salesman's information
            Salesman.FirstName = "Wiley";
            Salesman.LastName = "Coyote";
            Salesman.Gender = 'M';
            Salesman.SocialInsuranceNumber = 123456789;
            Salesman.EmploymentStartDate = DateTime.Today;
            Salesman.YearlySalary = 45250.00;

            // Set the shipper's information
            Shipper.FirstName = "Road";
            Shipper.LastName = "Runner";
            Shipper.Gender = 'F';
            Shipper.SocialInsuranceNumber = 7777777;
            Shipper.EmploymentStartDate = DateTime.Parse("June 1, 2008");
            Shipper.YearlySalary = 54520.00;


            // Show the information
            System.Console.WriteLine("The information for the company:");
            System.Console.WriteLine(Acme.Name);
            System.Console.WriteLine(Acme.City);
            System.Console.WriteLine(Acme.BusinessStartDate);
            System.Console.WriteLine(Acme.IsIncorporated);
            System.Console.WriteLine(Acme.NumberOfEmployess);
            System.Console.WriteLine(Acme.GrossIncomeToDate);

            System.Console.WriteLine("The employee information: Salesman");
            System.Console.WriteLine(Salesman.FirstName);
            System.Console.WriteLine(Salesman.LastName);
            System.Console.WriteLine(Salesman.Gender);
            System.Console.WriteLine(Salesman.SocialInsuranceNumber);
            System.Console.WriteLine(Salesman.EmploymentStartDate);
            System.Console.WriteLine(Salesman.YearlySalary);

            System.Console.WriteLine("The employee information: Shipper");
            System.Console.WriteLine(Shipper.FirstName);
            System.Console.WriteLine(Shipper.LastName);
            System.Console.WriteLine(Shipper.Gender);
            System.Console.WriteLine(Shipper.SocialInsuranceNumber);
            System.Console.WriteLine(Shipper.EmploymentStartDate.ToString("MMMM d, yyyy"));
            System.Console.WriteLine(Shipper.YearlySalary);
        }
    }
}
```

----
----

## Practice

Integrate these practice problems into the code under the `B` folder. Some of these problems introduce changes to code you've already written while others represent new classes.

### `Account` Modifications

Extend the Account class from the example to include more information.

**Problem Statement:**

Extend the Account class from the example to include more information. Specifically, include an AccountType:String, BankName:String, BranchNumber:Integer, and InstitutionNumber:Integer.

Also modify the driver to make use of the added information.

> *Background Notes*
>
> The branch number and the institution number together make up the Transit Number for a bank. "The bank transit number is 8 digits long. This is divided into a 5 digit branch number and 3 digit institution code, for example 10000-200." (Quoted from **en.wikipedia.org/wikiSort_code** - No longer active)
>
> For more information on bank accounts and transit numbers in Canada, see [Wikipedia](http://en.wikipedia.org/wiki/Routing_transit_number#Canadian_transit_number).

----

### CanadianAddress

This class represents an address for some place in Canada.

**Problem Statement:**

Create the CanadianAddress class so that it can represent the majority of possible addresses that some place may have in Canada. Design the class to have only public fields, as specified in this document.

* Data Attributes of the CanadianAddress class:
  * Street : String
  * Unit : String
  * City : String
  * Province : String
  * PostalCode : String
  * RuralRoute : String
  * BoxNumber : String

Also create a driver for testing this class; you may use any name for the driver as long as it is not already mentioned in this topic (we need it unique to avoid *naming collisions* in our namespace). In the driver, create instances of the CanadianAddress class that represents a fictional home address as well as the address of your school (use hard-coded data).

----

### Course

This class represents a post-secondary course with a theory (exam) and a lab portion.

**Problem Statement:**

Create the Course class so that it represents a post-secondary course. Design the class to have only public fields, as specified in this document.

* Data Attributes of the Course class:
  * CourseName : String
  * CourseNumber : String
  * ExamCount : Integer
  * LabCount : Integer
  * ClassHours : Integer

Also create a driver for testing this class; you may use any name for your driver as long as it is not already mentioned in this package. In the driver, instantiate all of the first term classes you are taking and populate those objects with data (use hard-coded data).

----

### ExamResult

This class represents the results of an exam for a student.

**Problem Statement:**

Create the ExamResult class so that it represents the results of an exam written by a student. Design the class to have only public fields, as specified in this document.

* Data Attributes of the ExamResult class:
  * Name : String
  * TotalMarks : Integer
  * MarksEarned : Real
  * ExamWeight : Integer
  * StudentId : Integer

Also create a driver for testing this class; you may use any name for the driver as long as it is not already mentioned in this package. In the driver, instantiate all of the exams you have taken to date in this course and populate those objects with data (use hard-coded data).

----

### LabResult

This class represents the results of an lab for a student.

**Problem Statement:**

Create the labResult class so that it represents the results of a lab submitted by a student. Design the class to have only public fields, as specified in this document.

* Data Attributes of the LabResult class:
  * LabNumber : Integer
  * TotalMarks : Integer
  * MarksEarned : Real
  * LabWeight : Integer
  * StudentId : Integer

Also create a driver for testing this class; you may use any name for the driver as long as it is not already mentioned in this package. In the driver, instantiate all of the labs you have submitted to date in this course and populate those objects with data (use hard-coded data).
