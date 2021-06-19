// Credits for this class go to:
//  https://stackoverflow.com/a/15717047

using System;
using static System.Console;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleDatabase.DAL;
using SimpleDatabase.Entities;
using SimpleDatabase.Services;
using System.Collections.Generic;

namespace SimpleDatabase
{
    class Program
    {
        #region Main entry point
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello Database!");
                var app = new Program();
                app.Run();
            }
            finally
            {
                ResetColor();
            }
        }
        #endregion

        #region App Driver
        private void Run()
        {
            AdHoc();
            // using a dependency injection container to get the service object
            var myService = _container.GetInstance<ResumeService>();
            // Get the data from the database
            var existingResumes = myService.ListAllResumes(); // get it from whereever
            Display(existingResumes);

            var myResume = CreateNewResume();
            myService.Add(myResume); // put it whereever
        }

        private void AdHoc()
        {
            using(var context = _container.GetInstance<WestWindContext>())
            {
                var items = context.Items;
                foreach(var row in items)
                    WriteLine(row.Name);
            }
        }


        private void Display(List<Resume> data)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine($"There are {data.Count} resumes:");
            ForegroundColor = ConsoleColor.Yellow;
            foreach(var item in data)
                WriteLine($"\t{item.FirstName} {item.LastName}");
            ResetColor();
        }

        private Resume CreateNewResume()
        {
            string first, last, temp;
            DateTime dob;
            do
                first = Prompt("Enter your first name");
            while(string.IsNullOrWhiteSpace(first));

            do
                last = Prompt("Enter your last name");
            while(string.IsNullOrWhiteSpace(last));

            do
                temp = Prompt("Enter your birthdate");
            while(!DateTime.TryParse(temp, out dob));

            var result = new Resume
            {
                FirstName = first,
                LastName = last,
                DateOfBirth = dob
            };

            return result;
        }

        private string Prompt(string message)
        {
            ForegroundColor = ConsoleColor.Cyan;
            Write($"{message}: ");
            ForegroundColor = ConsoleColor.Yellow;
            string response = ReadLine();
            ResetColor();
            return response;
        }
        #endregion

        #region Constructor and Properties
        private readonly IConfiguration _configuration; // this will allow access to appsettings
        private readonly Container _container = new Container();
        public Program()
        {
            // Get access to the appsettings
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", true, true);
            _configuration = builder.Build();

            // Register different services
            // Registering my database objects for DI Container
            _container.Register<MySimpleDatabaseContext>(_CreateSimpleDatabaseContext);
            _container.Register<WestWindContext>(_CreateWestWindContext);
        }

        private WestWindContext _CreateWestWindContext()
        {
            string conn = _configuration.GetConnectionString("WWDb");
            // Setup my database connection options
            DbContextOptionsBuilder<WestWindContext> optionsBuilder;
            optionsBuilder = new(); // Instantiate a "builder"
            optionsBuilder.UseSqlServer<WestWindContext>(conn);
            var options = optionsBuilder.Options;

            return new WestWindContext(options); // creates my DAL class
        }

        private MySimpleDatabaseContext _CreateSimpleDatabaseContext()
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            // Setup my database connection options
            DbContextOptionsBuilder<MySimpleDatabaseContext> optionsBuilder;
            optionsBuilder = new(); // Instantiate a "builder"
            optionsBuilder.UseSqlServer<MySimpleDatabaseContext>(conn);
            var options = optionsBuilder.Options;

            return new MySimpleDatabaseContext(options); // creates my DAL class
        }
        #endregion
    }
}
