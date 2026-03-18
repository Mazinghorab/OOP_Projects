namespace OOP_Project;
class Program
{
    static void Main(string[] args)
    {
        Test();
    }

    public static void Test()
    {
        BankAccount acc1 = new BankAccount(11, 500, "123", 11);
        acc1.Login();
    }
}

class BankAccount
{
        private int _accountnumber;
        private decimal _balance;
        public string AccountHolder;
        public static int TotalAccounts;
        private readonly List<Transaction> _transactionhistory;
        
        // 1) Login Field and it's Properity 
        private bool _isLogged = false;
        
        // 2) Authentication
        private int _pinOriginal;
        public int PinUser = 0;
        
        // 3) Security Rules
        private int _loginAttempts = 0;
        
        public int AccountNumber
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
        
        public BankAccount(int accountNumber, decimal initialBalance, string accountHolder, int pin)
        {
            if(string.IsNullOrEmpty(Convert.ToString(accountNumber)))
                throw new Exception("Account Number Must not be Empty!");
            if(initialBalance <= 0)
                throw new Exception("Balance Must not be Zero or Negative!");
            if(AccountNumber < 0)
                throw new Exception("Account Number Must be Positive!");
            AccountNumber = accountNumber;
            PinUser = int.Parse(Console.ReadLine());
            _pinOriginal = pin;
            Balance = initialBalance;
            this.AccountHolder = accountHolder;
            _transactionhistory = new List<Transaction>();
            _isLogged = true;
            TotalAccounts++;
        }
        
        private void CheckActivity()
        {
            if (!_isLogged)
            {
                Console.WriteLine("Account is not Logged in!");
                return;
            }
            Console.WriteLine("Account is Logged in !");
        }
        
        public void Logout()
        {
            Console.WriteLine("Bye Bye..");
            _isLogged = false;
        }

        public void Login()
        {
            if (_loginAttempts >= 3)
            {
                Console.WriteLine("Come Back after 60 Seconds!!");
                Thread.Sleep(60000);
                _loginAttempts = 0;
            }
            if (CheckPIN())
            {
                Console.WriteLine("Welcome Back...!");
                _isLogged = true;
                _loginAttempts = 0;
            }
            else
            {
                _loginAttempts++;
                Console.WriteLine($"Wrong PIN! Remaining Attempts : {3 - _loginAttempts}");
            }
        }

        private bool CheckPIN()
        {
            if (_pinOriginal != PinUser)
            {
                Console.WriteLine("Incorrect PIN!");
                return false;
            }
            Console.WriteLine("Correct PIN");
            return true;
        }
        
        public void Deposit(decimal amount)
        {
            CheckActivity();
            CheckPIN();
            if(amount <= 0)
                throw new Exception("The Amount Must be Positive!");
            var DepositTransaction = new Transaction(+amount, DateTime.Now, "Deposit");
            _transactionhistory.Add(DepositTransaction);
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            CheckActivity();
            CheckPIN();
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
            CheckActivity();
            CheckPIN();
            return _transactionhistory.AsReadOnly();
        }
    }

class Transaction 
{
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
        return $"[{Date.ToString("yyyy-MM-dd")}] {Type}: ${Amount}";
    }
}
    