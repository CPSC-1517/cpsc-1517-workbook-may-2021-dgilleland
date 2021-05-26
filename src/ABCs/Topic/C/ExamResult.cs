namespace Topic.C
{
    public class ExamResult
    {
        public string Name { get; private set; }
        public int TotalMarks { get; private set; }
        public double MarksEarned { get; private set; }
        public int ExamWeight { get; private set; }
        public int StudentId { get; private set; }

        public ExamResult(string name, int totalMarks, double marksEarned, int examWeight, int studentId)
        {
            Name = name;
            TotalMarks = totalMarks;
            MarksEarned = marksEarned;
            ExamWeight = examWeight;
            StudentId = studentId;
        }

        public override string ToString()
        {
            return $"{Name} is worth {ExamWeight}% and Student {StudentId} earned {MarksEarned}/{TotalMarks}";
        }
    }
}