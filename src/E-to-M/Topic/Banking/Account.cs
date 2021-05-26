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
            private set { _Balance = value; }
        }

        public double OverdraftLimit
        {
            get { return _OverdraftLimit; }
            set { _OverdraftLimit = value; }
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
            if (amount <= Balance + OverdraftLimit)
                Balance = Balance - amount;
            else
                amount = 0;
            return amount;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
        #endregion
    }
}