using System; // because of needing DateTime
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleDatabase.Entities
{
    public class Resume
    {
        // One property per column that I am "mapping" to
        // We only need auto-implemented properties
        public int ResumeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [NotMapped] // Tells EF NOT to expect a column called FullName on the table
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}