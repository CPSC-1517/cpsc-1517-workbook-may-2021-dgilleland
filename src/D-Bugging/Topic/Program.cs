using System;
using static System.Console;

namespace Topic
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new();
            app.Run();
        }

        private void Run()
        {
            WriteLine("Simple Fractions");

            int num = Prompt("Enter a numerator");
            int denom = Prompt("Enter a denominator");
            Fraction fraction = new(num, denom);

            WriteLine($"The resulting fraction is {fraction}");
            WriteLine($"The reciprocal is {fraction.Reciprocal}");
        }

        private int Prompt(string v)
        {
            Write($"{v}: ");
            ForegroundColor = ConsoleColor.Cyan;
            string input = ReadLine();
            ResetColor();
            return int.Parse(input);
        }
    }
}
