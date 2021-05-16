using static System.Console;

namespace Topic.B
{
    public class DemoCanadianAddress
    {
        public static void Main(string[] args)
        {
            CanadianAddress home = new CanadianAddress();
            home.BoxNumber = "24";
            home.RuralRoute = "RR#42";
            home.City = "Ferintosh";
            home.Province = "AB";

            // Set the values as part of an initializer list
            CanadianAddress nait = new()
            {
                Street = "11762 - 106 Street NW",
                City = "Edmonton",
                Province = "AB",
                PostalCode = "T5G 2R1"
            };
            WriteLine($"My school is at {nait.Street} in {nait.City}. That's a ways away from my (fictional) home in {home.City}.");
        }
    }
}