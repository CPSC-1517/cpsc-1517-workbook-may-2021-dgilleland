using System;
using static System.Console;
using Sandbox.File_IO;

namespace Sandbox.BitsNPieces
{
    public class AboutDelegates
    {
        public static void Main(string[] args)
        {
            Assignment theQuiz = new Assignment("Quiz 1", "Quizzes", 15);
            DisplayMark(theQuiz, TalentPool.TeachersAssistant);
            DisplayMark(theQuiz, TalentPool.Friend);
        }

        private static void DisplayMark(Assignment quiz, Marker underling)
        {
            double result = underling(quiz, 20);
            WriteLine($"A mark of {result} on {quiz.Name}");
        }
    }

    // Define a delegate
    public delegate double Marker(Assignment item, double possibleMarks);

    public class TalentPool
    {
        public static double TeachersAssistant(Assignment item, double possibleMarks)
        {
            // Marks very hard
            item.RecordGrade(possibleMarks / 2, possibleMarks);
            return item.Percent.Value;
        }

        public static double Friend(Assignment item, double possibleMarks)
        {
            item.RecordGrade(possibleMarks, possibleMarks);
            return item.Percent.Value;
        }
    }

}