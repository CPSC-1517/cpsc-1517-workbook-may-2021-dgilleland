using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            Console.WriteLine($"'{conn}'");
        }
    }
}
