using System; // because of needing DateTime

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
    }
}