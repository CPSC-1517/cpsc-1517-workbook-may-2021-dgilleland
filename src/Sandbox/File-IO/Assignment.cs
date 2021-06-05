namespace Sandbox.File_IO
{
    public class Assignment
    {
        public string Name { get; }
        public string EvaluationGroupName { get; }
        public double Weight { get; }
        public double PossibleMarks { get; set; }
        public double EarnedMarks { get; set; }

        public double? Percent
        {
            get
            {
                double? result = null;
                if(PossibleMarks > 0)
                    result = EarnedMarks / PossibleMarks;
                return result;
            }
        }

        public Assignment(string name, string evaluationGroupName, double weight, double possibleMarks = 0, double earnedMarks = 0)
        {
            Name = name;
            EvaluationGroupName = evaluationGroupName;
            Weight = weight;
            PossibleMarks = possibleMarks;
            EarnedMarks = earnedMarks;
        }

        public void RecordGrade(double earned, double possible)
        {
            PossibleMarks = possible;
            EarnedMarks = earned;
        }

        public override string ToString()
        {
            return $"{Name},{EvaluationGroupName},{Weight},{PossibleMarks},{EarnedMarks}";
        }

        public static Assignment Parse(string text)
        {
            string[] parts = text.Split(",");
            if(parts.Length != 5) throw new System.FormatException("Input string is not in the correct CSV format for an Assignment object");
            double weight = double.Parse(parts[2]);
            double possible = double.Parse(parts[3]);
            double earned = double.Parse(parts[4]);
            return new Assignment(parts[0], parts[1], weight, possible, earned);
        }

        public static bool TryParse(string text, out Assignment result)
        {
            try
            {
                result = Parse(text);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}