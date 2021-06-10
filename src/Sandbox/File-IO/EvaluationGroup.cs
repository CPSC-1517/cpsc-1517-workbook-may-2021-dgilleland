using System;
using System.Collections.Generic;

namespace Sandbox.File_IO
{
    public class EvaluationGroup
    {
        public string Name { get; }
        public List<Assignment> Assignments {get;set;}
        public double GroupWeight
        {
            get
            {
                double total = 0;
                foreach(var item in Assignments)
                    total += item.Weight;
                return total;
            }
        }

        public bool IsMarked
        { get { return Assignments.TrueForAll(AssignmentIsMarked); } }

        private bool AssignmentIsMarked(Assignment assignment)
        { return assignment.Percent.HasValue; }

        public EvaluationGroup(string name)
        {
            Name = name;
            Assignments = new List<Assignment>(); // Create an empty list
        }

        public void Add(Assignment assignment)
        {
            if(assignment == null)
                throw new ArgumentNullException(nameof(assignment), "Cannot add a null assignment to the group");
            Assignments.Add(assignment);
        }
    }
}