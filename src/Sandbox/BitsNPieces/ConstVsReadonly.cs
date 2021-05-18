using System;
using static System.Console;

namespace Sandbox.BitsNPieces
{
    public class ConstVsReadonly
    {
        public static void Main(string[] args)
        {
            const int min = 10000;
            const int max = 99999;
            Write($"Enter an account number (between {min} and {max}): ");
            int number = int.Parse(ReadLine());
            SimpleAccount myAccount = new SimpleAccount(number, 500);
            WriteLine($"My bank account {myAccount.AccountNumber} has {myAccount.Balance :C}.");
            myAccount.Deposit(500);
            WriteLine($"Now my balance is {myAccount.Balance :C}");
        }
    }

    public class SimpleAccount
    {
        public readonly int AccountNumber;
        public double Balance{ get; private set; }
        public SimpleAccount(int accountNumber, double openingBalance)
        {
            AccountNumber = accountNumber;
            Balance = openingBalance;
        }
        public void Deposit(double amount)
        {
            Balance += amount; // increase the balance by the amount supplied
        }
    }
}