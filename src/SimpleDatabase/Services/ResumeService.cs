using System;
using System.Linq;
using SimpleDatabase.DAL;
using SimpleDatabase.Entities;

namespace SimpleDatabase.Services
{
    public class ResumeService
    {
        private readonly MySimpleDatabaseContext _context;
        public ResumeService(MySimpleDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "A database context is required for this service");
        }

        public System.Collections.Generic.List<Resume> ListAllResumes()
        {
            var result = _context.Resumes;
            return result.ToList();
        }

        public void Add(Resume resume)
        {
            _context.Resumes.Add(resume);
            _context.SaveChanges();
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