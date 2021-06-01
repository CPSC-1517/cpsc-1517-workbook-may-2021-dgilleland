using System;
using static System.Console;

namespace Sandbox.WhyTryParse
{
    public class DemoTryParse
    {
        public static void Main(string[] args)
        {
            Write("Enter a number: ");
            string userInput = ReadLine();

            int value = -9; // Either way, when I call .TryParse(), this value will be overwritten
            if(int.TryParse(userInput, out value))
                WriteLine($"You input a whole number: {value}");
            else
                WriteLine($"\"{userInput}\" was not a whole number. My value is {value}.");

            // Parse some text input as an enumeration
            Write("Type either Poor, Neutral, or Good: ");
            userInput = ReadLine();
            Rating result;
            if(Enum.TryParse<Rating>(userInput, out result))
                WriteLine("I see you can follow typing instructions.");
            else
                WriteLine("D'oh!");

            // Parse some text input as a Fraction
            Write("Enter a fraction: ");
            userInput = ReadLine();
            Fraction myNum;
            if(Fraction.TryParse(userInput, out myNum))
                WriteLine($"You entered a valid fraction: {myNum}");
            else
                WriteLine("That's not a fraction");
        }
    }
}
