using System;

namespace Topic.A
{
    public class AnsweringMachine
    {
        public static string Answer()
        {
            return "Please leave a message after the beep.";
        }

        public static string Answer(string name)
        {
            return $"Hi, this is {name}. Please leave a message after the beep.";
        }
        
    }
}