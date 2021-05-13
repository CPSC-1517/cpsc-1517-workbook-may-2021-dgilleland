using System;
using static System.Console; // Direct access to all the static members of the Console class

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
                WriteLine("Pass in the name of the demo");
            else
            {
                DemoDrivers app = new();
                switch(args[0])
                {
                    case "Hello":
                        app.RunSalutation();
                        break;
                    case "Person":
                        app.DemoPerson();
                        break;
                    default:
                        WriteLine("-- Unknown Demo --");
                        break;
                }
            }
        }


    }
}
