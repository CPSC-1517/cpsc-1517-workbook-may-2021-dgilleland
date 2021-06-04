using System;
using static System.Console;

namespace Sandbox.BitsNPieces
{
    public class FunWithStrings
    {
        public static void Main(string[] args)
        {
            Write("Run the erratta on strings? (y/N) ");
            if(ReadLine().ToLower().Equals("y"))            
                Errata();
            string message = "Hello world!";
            WriteLine(message.Quack());
        }

        private const string DIGITS = "0123456789";
        
        public static void Errata()
        {
            string password = "s3cr3t!"; // clever of me :)
            foreach(var character in DIGITS)
                if(password.Contains(character))
                    WriteLine($"Found the digit {character} in the password");


            string nothing = null;
            if(string.IsNullOrWhiteSpace(nothing))
                WriteLine("Just as I expected!");
            nothing = "";
            WriteLine($"My empty string has a length of {nothing.Length}");

            foreach(var digit in DIGITS)
                WriteLine(digit);
            
            if(5.Equals(2 + 3))
                WriteLine("That's just a weird way to code");
        }
    }

    public static class FunWithMyStringExtensions
    {
        public static string Quack(this string self)
        {
            return self + " (quack)";
        }
    }
}