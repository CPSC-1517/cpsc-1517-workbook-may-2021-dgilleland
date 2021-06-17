using Microsoft.EntityFrameworkCore;
using SimpleDatabase.Entities;

namespace SimpleDatabase.DAL // DAL is short for Data Access Layer
{
    public class MySimpleDatabaseContext : DbContext
    {
        // Properties that associate our entity classes with the database tables
        // Each table is represented as a DbSet<T>
        public DbSet<School> Schools { get; set; }
        public DbSet<EducationalAchievement> EducationalAchievements { get; set; }
        public DbSet<Resume> Resumes { get; set; }

        // Constructor
        // I will "inject" the "options" which will tell my database context class
        // all about where to get/access the database
        public MySimpleDatabaseContext(DbContextOptions<MySimpleDatabaseContext> options)
            : base(options)
        {
        }
    }
}