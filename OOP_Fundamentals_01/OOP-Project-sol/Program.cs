namespace OOP_Project;
class Program
{
    static void Main(string[] args)
    {
        // Taking some instances from our BluePrint
        BankAccount Acc1 = new BankAccount("01", 3000, "11");
        BankAccount Acc2 = new BankAccount("02", 6000, "12");
        BankAccount Acc3 = new BankAccount("03", 1000, "13");
        Acc1.DisplayInfo();
        Acc2.DisplayInfo();
        Acc3.DisplayInfo();
        Console.Write($"Totla BankAccounts : {BankAccount.GetTotalAccounts()} \n");
        
        // Making some Actions
        Acc1.Deposit(1000);
        Console.WriteLine($"The Balance of The Account after Deposit is {Acc1.GetBalance()}");
        Acc2.Deposit(500);
        Console.WriteLine($"The Balance of The Account after Deposit is {Acc2.GetBalance()}");
        Acc3.Deposit(90);
        Console.WriteLine($"The Balance of The Account after Deposit is {Acc3.GetBalance()}");
        Console.WriteLine();
        
        Acc1.Withdraw(900);
        Acc1.Withdraw(1000);
        Console.WriteLine($"Log : ");
        var history1 = Acc1.TransactionHistory();
        foreach (var it in history1)
        {
            Console.WriteLine($"{it} ");
        }
        Console.WriteLine($"The Total Balance of The Account is {Acc1.GetBalance()}");
        Console.WriteLine();

        Acc2.Withdraw(200);
        Acc2.Withdraw(300);
        Console.WriteLine($"Log : ");
        var history2 = Acc2.TransactionHistory();
        foreach (var it in history2)
        {
            Console.WriteLine($"{it} ");
        }
        Console.WriteLine($"The Total Balance of The Account is {Acc2.GetBalance()}");
        Console.WriteLine();
        
        Acc3.Withdraw(60);
        Console.WriteLine($"Log : ");
        var history3 = Acc3.TransactionHistory();
        foreach (var it in history3)
        {
            Console.WriteLine($"{it} ");
        }
        Console.WriteLine($"The Total Balance of The Account is {Acc3.GetBalance()}");
    }
}

// Creating the BankAccount Class
class BankAccount
    {
        // Creating the main Fields(Private)
        private string _accountnumber;
        private decimal _balance;
        public string AccountHolder;
        public static int TotalAccounts;
        private readonly List<Transaction> _transactionhistory;
        
        // Making some Properties for Fields Manipulation
        public string AccountNumber
        {
            get
            {
                return _accountnumber;
            }
            private set
            {
                _accountnumber = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return _balance;
            }
            private set
            {
                _balance = value;
            }
        }
        
        // Parameterized Constructor with Validation 
        public BankAccount(string accountNumber, decimal initialBalance, string accountHolder)
        {
            if(string.IsNullOrEmpty(accountNumber))
                throw new Exception("Account Number Must not be Empty!");
            if(string.IsNullOrEmpty(accountHolder))
                throw new Exception("Account Holder Must not be Empty!");
            if(initialBalance <= 0)
                throw new Exception("Balance Must not be Zero or Negative!");
            
            AccountNumber = accountNumber;
            Balance = initialBalance;
            this.AccountHolder = accountHolder;
            TotalAccounts++;
            _transactionhistory = new List<Transaction>();
        }
        
        // Methods of Our Class
        public void Deposit(decimal amount)
        {
            if(amount <= 0)
                throw new Exception("The Amount Must be Positive!");
            var DepositTransaction = new Transaction(+amount, DateTime.Now, "Deposit");
            _transactionhistory.Add(DepositTransaction);
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if(amount <= 0)
                throw new Exception("The Amount Must be Positive!");
            if(amount > Balance)
                throw new Exception("Insufficient Funds");
            
            Balance -= amount;
            var withdrawalTransaction = new Transaction(-amount, DateTime.Now, "Withdrawal");
            _transactionhistory.Add(withdrawalTransaction);
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Account Number : {AccountNumber} \nTotal Balance : {Balance} \nAccount Holder : {AccountHolder} \n");
        }

        public static int GetTotalAccounts()
        {
            return TotalAccounts;
        }

        public IReadOnlyList<Transaction> TransactionHistory()
        {
            return _transactionhistory.AsReadOnly();
        }
    }

// Transaction Class
class Transaction 
{
    // Fields of our Transaction CLass
    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Type { get; }

    // Assigning some Attributes to our Transaction's Data
    public Transaction(decimal Amount, DateTime Date, string Type)
    {
        this.Amount = Amount;
        this.Date = Date;
        this.Type = Type;
    }
    public override string ToString()
    {
        // Using the Concept of Polymorphism to Edit the ToString() Method
        return $"[{Date.ToString("yyyy-MM-dd")}] {Type}: ${Amount}";
    }
}
    