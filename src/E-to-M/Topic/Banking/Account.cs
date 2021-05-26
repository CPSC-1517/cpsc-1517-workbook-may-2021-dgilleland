using System;
using System.Text.Json.Serialization;

namespace Topic.Banking
{
    public class Account
    {
        public readonly int AccountNumber;
        private double _Balance;
        private double _OverdraftLimit;

        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
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
    }
}