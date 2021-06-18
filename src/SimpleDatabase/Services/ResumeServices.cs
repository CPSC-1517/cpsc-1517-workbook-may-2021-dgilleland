using System;
using SimpleDatabase.DAL;

namespace SimpleDatabase.Services
{
    public class ResumeService
    {
        private readonly MySimpleDatabaseContext _context;
        public ResumeService(MySimpleDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "A database context is required for this service");
        }

        #region Not what we typically will use....
        public void CreateDatabaseIfNotExists()
        {
            // Do NOT do this if you have been given an
            // existing database. Use this only if
            // you don't have a database and you plan
            // on generating one using Code First.
            _context.Database.EnsureCreated();

            // Even if you plan on using Code First,
            // you should consider using Migrations
            // instead of .Database.EnsureCreated()
        }
        #endregion
    }
}