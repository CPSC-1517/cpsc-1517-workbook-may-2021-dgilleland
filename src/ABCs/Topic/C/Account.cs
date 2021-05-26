namespace Topic.C
{
    public class Account
    {
        public readonly int AccountNumber;
        private double _Balance;
        private double _OverdraftLimit;
        private string _AccountType;
        private string _BankName;
        private int _BranchNumber;
        private int _InstitutionNumber;

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

        public string AccountType
        {
            get { return _AccountType;}
            set { _AccountType = value; }
        }

        public string BankName
        {
            get { return _BankName;}
            set { _BankName = value; }
        }

        public int BranchNumber
        {
            get { return _BranchNumber;}
            set { _BranchNumber = value; }
        }

        public int InstitutionNumber
        {
            get { return _InstitutionNumber;}
            set { _InstitutionNumber = value; }
        }

        public Account(string bankName, int branchNumber, int institutionNumber, int accountNumber, double balance, double overdraftLimit, string accountType)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            OverdraftLimit = overdraftLimit;

            BankName = bankName;
            BranchNumber = branchNumber;
            InstitutionNumber = institutionNumber;
            AccountType = accountType;
        }
    }
}