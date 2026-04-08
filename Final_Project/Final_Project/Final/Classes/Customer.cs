using Final.Interfaces;
namespace Final.Classes;

public class Customer : ICustomer
{
    // Fields
    protected string customerId;
    protected string name;
    protected string email;
    protected string shippingAddress;
    protected ShoppingCart cart;
    public List<Order> OrderHistory { get; private set; }
    
    // Properties
    public string CustomerId
    {
        get { return customerId; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid ID!!");
            customerId = value;
        }
    }
    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid Name!!");
            name = value;
        }
    }
    public string ShippingAddress
    {
        get { return shippingAddress; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid Shipping Address!!");
            shippingAddress = value;
        }
    }
    public string Email
    {
        get { return email; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid Shipping Email!!");
            email = value;
        }
    }
    
    // Constructor
    public Customer(string cusid, string n, string em, string ShA, ShoppingCart c)
    {
        CustomerId = cusid;
        Name = n;
        ShippingAddress = ShA;
        Email = em;
        cart = c;
    }
    // Methods
    public void checkout()
    {
        Console.WriteLine($"Name : {Name}, Customer ID : {CustomerId}, Email : {Email}");
        Console.WriteLine($"Shipping Address : {ShippingAddress}");
        Console.WriteLine($"Cart Description : {cart}");
    }

    public void viewOrderHistory()
    {
        foreach (var item in OrderHistory)
        {
            Console.WriteLine(item);
        }
    }
}