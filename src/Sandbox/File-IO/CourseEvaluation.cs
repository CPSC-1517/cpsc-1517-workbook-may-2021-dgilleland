using System.Collections.Generic;
using System.Linq;

namespace Sandbox.File_IO
{
    public class CourseEvaluation
    {
        public readonly string CourseNumber;
        public readonly string CourseName;

        public List<EvaluationGroup> EvaluationGroups { get; private set;}
        
        public double TotalWeight
        {
            get
            {
                return EvaluationGroups.Sum(x => x.GroupWeight);
            }
        }

        public CourseEvaluation(string courseNumber, string name)
        {
            CourseNumber = courseNumber;
            CourseName = name;
        }
    }
}