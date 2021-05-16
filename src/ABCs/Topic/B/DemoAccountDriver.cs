using static System.Console;
namespace Topic.B
{
    public class DemoAccountDriver
    {
        public static void Main(string[] args)
        {
            Account myAccount; // declares a reference variable to an Account object
            myAccount = new Account(); // creates the Account object.

            myAccount.Balance = 500000.00;
            myAccount.OverdraftLimit = 1000000.00;
            myAccount.AccountNumber = 123456;

            WriteLine($"My new account number is {myAccount.AccountNumber}. I have a balance of {myAccount.Balance:C} with an overdraft limit of {myAccount.OverdraftLimit:C}.");
            WriteLine("... I wish.");

            myAccount.AccountType = "Chequing";
            myAccount.BankName = "Bank of Wishful Thinking";
            myAccount.BranchNumber = 112;
            myAccount.InstitutionNumber = 987243;

            WriteLine($"And it's a {myAccount.AccountType} at {myAccount.BankName} ({myAccount.BranchNumber}-{myAccount.InstitutionNumber})");
        }
    }
}