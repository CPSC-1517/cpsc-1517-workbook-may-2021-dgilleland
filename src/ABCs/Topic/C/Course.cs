namespace Topic.C
{
    public class Course
    {
        public string CourseName { get; private set; }
        public string CourseNumber { get; private set; }
        public int ExamCount { get; private set; }
        public int LabCount { get; private set; }
        public int ClassHours { get; private set; }

        public Course(string courseName, string courseNumber, int examCount, int labCount, int classHours)
        {
            CourseName = courseName;
            CourseNumber = courseNumber;
            ExamCount = examCount;
            LabCount = labCount;
            ClassHours = classHours;
        }
    }
}