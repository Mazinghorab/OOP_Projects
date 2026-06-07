namespace OOP_Project;
class Program
{
    static void Main(string[] args)
    {
        DemonstrateEmployeeClass();
    }

    public static void DemonstrateEmployeeClass()
    {
        Employee emp1 = new Employee("Ahmed", 1, 2000, "IT");
        Employee emp2 = new Employee("Muhammed", 2, 2500, "SWE");
        Employee emp3 = new Employee("Mahmoud", 3, 30000, "IT");
        
        Console.WriteLine(Employee.GetTotalEmployees());
    }
}

class Employee
{
    // 1) Fields
    private string _name;
    private int _id;
    private decimal _salary;
    private string _department;
    private DateTime _hireDate;
    private readonly List<EmploymentHistory> _history;

    
    // 5) Static and it's Method
    private static int _totalEmployees;

    // 2) Properties
    public string Name
    {
        get { return _name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Name Must be Set!");
            if (value.Length < 3)
                throw new Exception("Name Must be at least 3!");
            _name = value;
        }
    }

    public int ID
    {
        get { return _id; }
        private set
        {
            if (value <= 0)
                throw new Exception("ID Must be Set!");
            _id = value;
        }
    }

    public decimal Salary
    {
        get { return _salary; }
        private set
        {
            if (value < 0)
                throw new Exception("Salary must be Positive!");
            if(string.IsNullOrEmpty(value.ToString()))
                throw new Exception("Salary Must be Set!");
            _salary = value;
        }
    }

    public string Department
    {
        get { return _department; }
        private set
        {
            if(string.IsNullOrEmpty(value))
                throw new Exception("Department must be Set!");
            _department = value;
        } 
    }

    public DateTime HireDate
    {
        get { return _hireDate; }
        private set
        {
            if (string.IsNullOrEmpty(value.ToString()))
                throw new Exception("Date Must be Set!");
            _hireDate = value;
        }
    }
    
    // 3) Constructor
    public Employee(string Name, int ID, decimal Salary, string Department)
    {
        this.Name = Name;
        this.ID = ID;
        this.Department = Department;
        this.Salary = Salary;
        this.HireDate = DateTime.Now;
        _totalEmployees++;
        _history = new List<EmploymentHistory>();
    }
    
    // 4) Methods
    public void GiveSalaryRaise(decimal Percentage, string ManagerPassword)
    {
        if (ManagerPassword != "mgr123")
        {
            Console.WriteLine("Password is Incorrect");
            return;
        }
        if (Percentage < 0 || Percentage > 100)
        {
            Console.WriteLine("Percentage Must be (0 - 100)");
            return;
        }
        _salary = _salary * (1 + Convert.ToDecimal(Percentage / 100));
    }

    public void ChangeDepartment(string newDept, string HrPassword)
    {
        if (HrPassword != "hr456")
        {
            Console.WriteLine("Icorrect Password!");
            return;
        }

        if (string.IsNullOrEmpty(newDept))
        {
            Console.WriteLine("Department Must be Set!");
            return;
        }

        _department = newDept;
    }

    public void DesplayEmploymentHisroy()
    {
        if (_history.Count == 0)
        {
            Console.WriteLine("No Employment Records");
            return;
        }

        foreach (EmploymentHistory it in _history)
        {
            Console.WriteLine(it);
        }
    }
    
    public static int GetTotalEmployees()
    {
        return _totalEmployees;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Name : {Name}, ID : {ID}, Salary : {Salary}, Department : {Department}, Hiring Date : {HireDate}");
    }
}

class EmploymentHistory
{
    private int _id;
    private string _department;
    private DateTime _hireDate;
    private decimal _salary;
    
    public EmploymentHistory(int ID, string Department, decimal Salary, DateTime HireDate)
    {
        _id = ID;
        _department = Department;
        _hireDate = HireDate;
        _salary = Salary;
    }
    public override string ToString()
    {
        return $"[{_hireDate.ToString("yyyy-MM-dd")}], Salary : ${_salary}";
    }
}