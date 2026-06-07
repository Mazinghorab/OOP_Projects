using System.Runtime.InteropServices.JavaScript;

namespace OOP_Project;
class Program
{
    static void Main(string[] args)
    {
        Test();
    }

    public static void Test()
    {
        Vehicle car1 = new Car("v8 Engine", 0, 530, "CA", "Policy123", 2000, "BMW", "BMW M3", 2020, 9000, 5);
        Vehicle truck1 = new Truck("v6 Engine", 0, 320, "CA", "Policy456", 1000, "Toyota", "Bremach T-Rex", 2019, 6000, 2000);
        Vehicle cycle1 = new Motorcycle("v5 Engine", 0, 220, "Ge", "999", 500, "DKW", "RT125", 2015, 600, 300);
        Vehicle[] vehArray = {car1, truck1, cycle1};
        double  TotalPrice = 0;
        foreach (Vehicle veh in vehArray)
        {
            veh.DisplayInfo();
            TotalPrice += veh.CalculateDepreciation();
            Console.WriteLine(veh.ToString());
            if (veh is Car)
            {
                Console.WriteLine($"YES, {veh.GetType()} is an Object of Car Class");
            }
            else
            {
                Console.WriteLine("Incorrect!!");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Total Price is : {TotalPrice}");
    }
}

class Vehicle
{
    // Fields
    protected string engineType;
    protected decimal minSpeed;
    protected decimal maxSpeed;
    protected string vehicleinsurance;
    public string policyName;
    protected int vehicleTax;
    protected string brand;
    protected string model;
    protected int year;
    protected double price;
    
    // Properties
    public string EngineType
    {
        get { return engineType; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Engine Type cannot be Empty!");
            engineType = value;
        }
    }
    public decimal MinSpeed
    {
        get { return minSpeed; }
        private set
        {
            if (value < 0)
                throw new Exception("min Speed Cannot be Negative!");
            minSpeed = value;
        }
    }
    public decimal MaxSpeed
    {
        get { return maxSpeed; }
        private set
        {
            if (value >= 600)
                throw new Exception("Max Speed cannot be Greater than 600");
            maxSpeed = value;
        }
    }

    public string Vehicleinsurance
    {
        get { return vehicleinsurance; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Please, Set the Vehicle Insurance Company!");
            vehicleinsurance = value;
        }
    }

    public string PolicyName
    {
        get { return policyName; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Please, Set the Police Name!");
            policyName = value;
        }
    }

    public int VehicleTax
    {
        get { return vehicleTax; }
        private set
        {
            if (value < 0)
                throw new Exception("Tax cannot be Negative!!");
            vehicleTax = value;
        }
    }

    public string Brand
    {
        get { return brand; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Please, Enter the Brand of your Vehicle!!");
            brand = value;
        }
    }

    public string Model
    {
        get { return model; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Please, Enter the Model of your Vehicle!!");
            model = value;
        }
    }

    public int Year
    {
        get { return year; }
        private set
        {
            if (value < 0)
                throw new Exception("Year cannot be Negative!!");
            year = value;
        }
    }
    public double Price
    {
        get { return price; }
        private set
        {
            if (value < 0)
                throw new Exception("Price cannot be Negative!!");
            price = value;
        }
    }

    public Vehicle(string engType, decimal mn, decimal mx, string vehins, string policy, int tax, string br, string mod, int yeaar, double pricee)
    {
        EngineType = engType;
        MinSpeed = mn;
        MaxSpeed = mx;
        Vehicleinsurance = vehins;
        PolicyName = policy;
        VehicleTax = tax;
        Brand = br;
        Model = mod;
        Year = yeaar;
        Price = pricee;
    }
    
    //  Methods
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Engine Type is : {EngineType}, and it's Minimum and Maximum Speed are [{MinSpeed}:{maxSpeed}]");
        Console.WriteLine($"Vehicle Insurance is : {Vehicleinsurance}, Policy Name : {PolicyName}, and it's Tax : {VehicleTax}");
        Console.WriteLine($"Barnd : {Brand}, Model : {Model}, Year : {Year}, and Price : {Price}");
    }

    public decimal AverageSpeed()
    {
        return (MinSpeed + MaxSpeed) / 2;
    }

    public virtual double CalculateDepreciation()
    {
        return Price;
    }

    public override string ToString()
    {
        return $"Time is : {DateTime.Now.Hour}";
    }
}

class Car : Vehicle
{
    private int _numberOfDoors;

    public int NumberOfDoors
    {
        get { return _numberOfDoors; }
        private set
        {
            if (value < 0)
                throw new Exception("Number of Doors cannot be Zero or Negative!!");
            _numberOfDoors = value;
        }
    }

    public Car(string engType, decimal mn, decimal mx, string vehins, string policy, int tax, string br, string mod, int yeaar, int pricee, int noDoors)
        : base(engType,  mn, mx,  vehins,  policy, tax, br, mod, yeaar, pricee)
    {
        NumberOfDoors = noDoors;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Number of Car's Door are : {NumberOfDoors}");
    }

    public override double CalculateDepreciation()
    {
        return Price * 0.90;
    }
    public override string ToString()
    {
        return $"Time is : {DateTime.Now.Hour}";
    }
}

class Truck : Vehicle
{
    private decimal _cargoCapacity;

    public decimal CargoCapacity
    {
        get { return _cargoCapacity; }
        private set
        {
            if (value < 0)
                throw new Exception("Cargo Capacity cannot be Negative!");
            _cargoCapacity = value;
        }
    }

    public Truck(string engType, decimal mn, decimal mx, string vehins, string policy, int tax, string br, string mod,
        int yeaar, int pricee, int carg)
        : base(engType, mn, mx, vehins, policy, tax, br, mod, yeaar, pricee)
    {
        CargoCapacity = carg;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Cargo Capacity is : {CargoCapacity}");
    }

    public override double CalculateDepreciation()
    {
        return Price * 0.85;
    }
    public override string ToString()
    {
        return $"Time is : {DateTime.Now.Hour}";
    }
}

class Motorcycle : Vehicle
{
    private int _engineSize;

    public int EngineSize
    {
        get { return _engineSize; }
        private set
        {
            if (value < 0)
                throw new Exception("Engine Size cannot be Negative!");
            _engineSize = value;
        }
    }

    public Motorcycle(string engType, decimal mn, decimal mx, string vehins, string policy, int tax, string br, string mod,
        int yeaar, int pricee, int engsi)
        : base(engType, mn, mx, vehins, policy, tax, br, mod, yeaar, pricee)
    {
        EngineSize = engsi;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Engine Size is : {EngineSize}");
    }

    public override double CalculateDepreciation()
    {
        return Price * 0.88;
    }
    public override string ToString()
    {
        return $"Time is : {DateTime.Now.Hour}";
    }
}