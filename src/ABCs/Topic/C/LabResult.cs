namespace Topic.C
{
    public class LabResult
    {
        public int LabNumber { get; private set; }
        public int TotalMarks { get; private set; }
        public double MarksEarned { get; private set; }
        public int LabWeight { get; private set; }
        public int StudentId { get; private set; }

        public LabResult(int labNumber, int totalMarks, double marksEarned, int labWeight, int studentId)
        {
            LabNumber = labNumber;
            TotalMarks = totalMarks;
            MarksEarned = marksEarned;
            LabWeight = labWeight;
            StudentId = studentId;
        }

        /// <summary>
        /// This method overrides the default ToString() method to display
        /// more meaningful information about this object.
        /// </summary>
        /// <returns>A string displaying the StudentId, MarksEarned, and
        /// TotalMarks.</returns>
        /// <remarks>
        /// A call to this method (such as <c>Lab4.ToString()</c>)
        /// would produce the following result:
        /// <code>The student (200702694) received 24.5/35 for this lab.</code>
        /// </remarks>
        public override string ToString()
        {
            return $"The student ({StudentId}) received {MarksEarned}/{TotalMarks} for this lab.";
        }
    }
}