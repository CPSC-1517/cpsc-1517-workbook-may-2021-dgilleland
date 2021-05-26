namespace Topic.B
{
    public class DemoExamAndLab
    {
        public static void Main(string[] args)
        {
            DemoExamAndLab app = new();

            app.Run();
        }

        private void Run()
        {
            ExamResult[] exams = new ExamResult[4];
            LabResult[] labs = new LabResult[2];

            exams[0] = new ExamResult{ Name = "Quiz 1", ExamWeight = 10, MarksEarned = 15, TotalMarks = 20, StudentId = 202112345 };
            // TODO: Finish demo drivers for Topic B
        }
    }
}