using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleDatabase.DAL;

namespace SimpleDatabase
{
    class Program
    {
        #region Main entry point
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Database!");
            var app = new Program();
            app.Run();
        }
        #endregion

        #region App Driver
        private void Run()
        {
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
            _container.Register<MySimpleDatabaseContext>(_CreateSimpleDatabaseContext);
        }

        private MySimpleDatabaseContext _CreateSimpleDatabaseContext()
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            // Setup my database connection options
            DbContextOptionsBuilder<MySimpleDatabaseContext> optionsBuilder;
            optionsBuilder = new(); // Instantiate a "builder"
            optionsBuilder.UseSqlServer<MySimpleDatabaseContext>(conn);
            var options = optionsBuilder.Options;

            return new MySimpleDatabaseContext(options);
        }
        #endregion
    }
}
