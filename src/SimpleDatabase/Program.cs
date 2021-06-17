using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleDatabase.DAL;

namespace SimpleDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Database!");
            var app = new Program();
            app.Run();
        }

        private readonly IConfiguration _configuration; // this will allow access to appsettings

        public Program()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", true, true);
            _configuration = builder.Build();
        }

        private void Run()
        {
            // Just to show that it works....
            string conn = _configuration.GetConnectionString("DefaultConnection");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"'{conn}'");
            Console.ResetColor();
            ShowRowCounts(conn);
        }

        private void ShowRowCounts(string connectionString)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("About to show the row counts of the tables");
            Console.ResetColor();
            // Setup my database connection options
            DbContextOptionsBuilder<MySimpleDatabaseContext> optionsBuilder;
            optionsBuilder = new(); // Instantiate a "builder"
            optionsBuilder.UseSqlServer<MySimpleDatabaseContext>(connectionString);
            var options = optionsBuilder.Options;

            // Use my database context and list out how many rows of data I have
            // in the database
            // I'll be coding a using clause that will make sure the database context
            // object is properly "disposed of"
            using(MySimpleDatabaseContext context = new(options))
            {
                // Hacky Thing - Code-First approach
                context.Database.EnsureCreated(); // Make sure the database is created if it does not exist.

                int resumeCount = context.Resumes.Count(); // .Count() is an extension method
                Console.WriteLine($"I have {resumeCount} rows in the Resumes table.");
            } // When I hit this point, the context object will be "disposed of"
            // That means, when I hit this point, my connection to the database will
            // be cleanly closed.
        }
    }
}
