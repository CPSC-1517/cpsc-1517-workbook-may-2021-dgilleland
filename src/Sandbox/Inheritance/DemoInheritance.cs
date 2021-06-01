using System;
using static System.Console;

namespace Sandbox.Inheritance
{
    public class DemoInheritance
    {
        public static void Main(string[] args)
        {
            BaseClass obj = new DerivedClass(1) { Number = 42, Title = "Bob" };
            
            foreach(var line in obj.CallHistory)
                WriteLine(line);
        }
    }
}