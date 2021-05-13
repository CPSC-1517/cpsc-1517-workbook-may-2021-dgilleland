using static System.Console;
namespace HelloWorld
{
    public class DemoDrivers
    {
        public void RunSalutation()
        {
            Salutation app = new Salutation();

            WriteLine(app.Greeting());
            WriteLine(app.Greeting("Bob"));
        }

        public void DemoPerson()
        {
            Person someGuy; // Variable declaration statement
            someGuy = new Person(); // Instantiate my object
            someGuy.FirstName = "Harry";
            someGuy.LastName = "Burns";
            someGuy.Age = 25;

            Person someGirl;
            someGirl = new Person();
            someGirl.FirstName = "Sally";
            someGirl.LastName = "Albright";
            someGirl.Age = 25;

            WriteLine($"Hi. My name is {someGuy.FirstName} {someGuy.LastName}");
            WriteLine($"Hello {someGuy.FirstName}. My name is {someGirl.FirstName}");
        }
    }
}