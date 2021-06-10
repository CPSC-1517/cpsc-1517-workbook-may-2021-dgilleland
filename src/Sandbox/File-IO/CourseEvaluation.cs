using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Sandbox.File_IO
{
    public class CourseEvaluation
    {
        [JsonInclude]
        public readonly string CourseNumber;
        [JsonInclude]
        public readonly string CourseName;

        public List<EvaluationGroup> EvaluationGroups { get; set;}
        
        public double TotalWeight
        {
            get
            {
                return EvaluationGroups.Sum(x => x.GroupWeight);
            }
        }

        public CourseEvaluation(string courseNumber, string courseName)
        {
            CourseNumber = courseNumber;
            CourseName = courseName;
            EvaluationGroups = new();
        }
        public void Add(EvaluationGroup group)
        {
            if(TotalWeight + group.GroupWeight > 100)
                throw new ArgumentException("The group will cause the total weight to exceed 100%", nameof(group));
            EvaluationGroups.Add(group);
        }
    }
}