using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static System.Console;

namespace Sandbox.File_IO
{
    public class DemoFileIO
    {
        private const string FileName = "MyMarks.dat";
        public static int Main(string[] args)
        {
            var app = new DemoFileIO();
            app.Run();
            return 0;
        }

        private Dictionary<string, EvaluationGroup> EvaluationGroups = new Dictionary<string, EvaluationGroup>();

        private void Run()
        {
            WriteLine("A) Create Course Data as JSON file after loading from CSV File");
            WriteLine("B) Load data from JSON file");
            Write("Select an option: ");
            string userInput = ReadLine();
            switch(userInput)
            {
                case "A":
                    CreateCourseDataFromFile();
                    break;
                case "B":
                    LoadCourseDataFromJson();
                    break;
                default:
                    WriteLine("Unknown input.");
                    break;
            }
        }

        private void LoadCourseDataFromJson()
        {
            Write("Enter the name of the .json file: ");
            string fileName = ReadLine();
            var result = ReadAsJson(fileName);

            var message = $"Loaded the {result.CourseName} evaluations.\nThe total weight is {result.TotalWeight}.";
            WriteLine(message);
        }

        private CourseEvaluation ReadAsJson(string fileName)
        {
            string json = File.ReadAllText(fileName);
            var result = JsonSerializer.Deserialize<CourseEvaluation>(json);
            return result;
        }

        private void CreateCourseDataFromFile()
        {
            int assignmentCount = ReadCSVFile();
            DisplayCSVFileResults(assignmentCount);

            CourseEvaluation course = BuildCourse();
            string jsonFilePath = SaveAsJson(course);
            WriteLine($"\nThe file has been saved to {jsonFilePath}");
        }

        private string SaveAsJson(CourseEvaluation course)
        {
            string fileName = $"{course.CourseNumber}.json";

            // Options give us more control over how the JSON will be formatted/processed
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };
            string jsonString = JsonSerializer.Serialize<CourseEvaluation>(course, options);

            File.WriteAllText(fileName, jsonString);

            return Path.GetFullPath(fileName);
        }

        private CourseEvaluation BuildCourse()
        {
            Write("\nEnter a course number: ");
            string courseNumber = ReadLine();
            Write("Enter a course name: ");
            string courseName = ReadLine();
            var course = new CourseEvaluation(courseNumber, courseName);
            foreach (var item in EvaluationGroups.Values)
                course.Add(item);
            return course;
        }

        private void DisplayCSVFileResults(int assignmentCount)
        {
            WriteLine();
            WriteLine($"{assignmentCount} assignments read from the CSV file.");
            WriteLine($"{EvaluationGroups.Count} evaluation groups detected.");
            foreach (var group in EvaluationGroups)
                WriteLine($"\t{group.Value.GroupWeight}% - {group.Key}");
        }

        private int ReadCSVFile()
        {
            Write("\nReading file data ");
            var data = File.ReadAllLines(FileName);
            int count = 0;
            foreach(var line in data)
            {
                Assignment assignment;
                if(Assignment.TryParse(line, out assignment))
                {
                    Write(".");
                    count++;
                    if(EvaluationGroups.ContainsKey(assignment.EvaluationGroupName))
                        // Just add the new assignment to that specific group
                        EvaluationGroups[assignment.EvaluationGroupName].Add(assignment);
                    else
                    {
                        // Make a new EvaluationGroup object
                        var group = new EvaluationGroup(assignment.EvaluationGroupName);
                        // Add the assignment
                        group.Add(assignment);
                        // Add it to the dictionary
                        EvaluationGroups.Add(assignment.EvaluationGroupName, group);
                    }
                }
                else
                    Write("x");
            }
            return count;
        }

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