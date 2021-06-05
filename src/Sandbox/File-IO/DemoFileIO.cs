using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace Sandbox.File_IO
{
    public class DemoFileIO
    {
        private const string FileName = "MyMarks.dat";
        public static int Main(string[] args)
        {
            var app = new DemoFileIO();
            app.TempDemo();
            return 0;
        }

        private List<EvaluationGroup> EvaluationGroups = new List<EvaluationGroup>();

        private void TempDemo()
        {
            List<Assignment> assignments = new();
            assignments.Add(new Assignment("Exercise 01", "Take-Home Exercises", 2, 9));
            assignments.Add(new Assignment("Exercise 02", "Take-Home Exercises", 2));
            assignments.Add(new Assignment("Exercise 03", "Take-Home Exercises", 2));

            List<string> csvLines = new();
            foreach(var item in assignments)
                csvLines.Add( item.ToString());
            
            File.WriteAllLines(FileName, csvLines);
        }
    }
}