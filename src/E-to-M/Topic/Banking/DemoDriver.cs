using static System.Console;
using System;

namespace Topic.Banking
{
    public class DemoDriver
    {
        public static void Main(string[] args)
        {
            Account savings = new Account("Bank of Mom & Dad", 123, 1234567 ,7654321, 100, 200, "Savings");
            Console.WriteLine($"Account # {savings.AccountNumber} has a balance of ${savings.Balance}");
        }
    }
}