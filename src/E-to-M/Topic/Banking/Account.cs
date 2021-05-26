using System;
using System.Text.Json.Serialization;

namespace Topic.Banking
{
    public class Account
    {
        #region Fields
        public readonly int AccountNumber;
        private double _Balance;
        private double _OverdraftLimit;
        #endregion

        #region Properties
        public double Balance
        {
            get { return _Balance; }
            private set
            {
                if (value < -OverdraftLimit)
                    throw new Exception("Negative balances cannot exceed the Overdraft Limit");
                _Balance = value;
            }
        }

        public double OverdraftLimit
        {
            get { return _OverdraftLimit; }
            set
            {
                if (value < 0)
                    throw new Exception("Negative overdraft limits not allowed");
                _OverdraftLimit = value;
            }
        }

        public string AccountType { get; }
        public string BankName { get; }
        public int BranchNumber { get; }
        public int InstitutionNumber { get; }

        public bool IsOverdrawn
        {
            get
            {
                bool overdrawn;
                if (Balance < 0)
                    overdrawn = true;
                else
                    overdrawn = false;
                return overdrawn;
            }
        }
        #endregion

        #region Constructor
        public Account(string bankName, int branchNumber, int institutionNumber, int accountNumber, double balance, double overdraftLimit, string accountType)
        {
            // Ensuring a valid state
            if (string.IsNullOrEmpty(bankName) || string.IsNullOrEmpty(bankName.Trim()))
                throw new Exception("BankName is required");
            if (branchNumber < 10000 || branchNumber > 99999)
                throw new Exception("Branch number must be 5 digits");
            if (institutionNumber < 100 || institutionNumber > 999)
                throw new Exception("InstitutionNumber must be a three-digit value");
            if (balance <= 0)
                throw new Exception("Opening balance must be greater than zero");
            if (balance != Math.Round(balance, 2))
                throw new Exception("Opening balances cannot include a fraction of a penny");
            if (overdraftLimit != Math.Round(overdraftLimit, 2))
                throw new Exception("Overdraft limit amounts cannot include a fraction of a penny");
            if (string.IsNullOrEmpty(accountType) || string.IsNullOrEmpty(accountType.Trim()))
                throw new Exception("Account type cannot be empty");

            BankName = bankName;
            BranchNumber = branchNumber;
            InstitutionNumber = institutionNumber;
            AccountNumber = accountNumber;
            Balance = balance;
            OverdraftLimit = overdraftLimit;
            AccountType = accountType;
        }
        #endregion

        #region Methods
        public double Withdraw(double amount)
        {
            if (amount != Math.Round(amount, 2))
                throw new Exception("Withdrawal amounts cannot include fractions of a penny");
            if (amount > Balance + OverdraftLimit)
                throw new Exception("Insufficient Funds");

            if (amount <= Balance + OverdraftLimit)
                Balance = Balance - amount;
            else
                amount = 0;
            return amount;
        }

        public void Deposit(double amount)
        {
            if (amount != Math.Round(amount, 2))
                throw new Exception("Deposit amounts cannot include fractions of a penny");
            Balance = Math.Round(Balance + amount, 2);
        }
        #endregion
    }
}