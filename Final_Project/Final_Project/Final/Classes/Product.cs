using Final.Interfaces;
namespace Final.Classes;

public class Product : IProduct
{
    // Fields
    protected string productId;
    protected string name;
    protected decimal price;
    protected string description;
    protected int stockQuantity;
    
    // Properties
    public string ProductId
    {
        get { return productId; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid Product ID!");
            productId = value;
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid Name!");
            name = value;
        }
    }

    public decimal Price
    {
        get { return price; }
        private set
        {
            if (value <= 0)
                throw new Exception("Invalid Price Enterd!");
            price = value;
        }
    }

    public string Description
    {
        get { return description; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid Description");
            description = value;
        }
    }

    public int StockQuantity
    {
        get { return stockQuantity; }
        private set
        {
            if (value <= 0)
                throw new Exception("Invalid Number Assigned");
            stockQuantity = value;
        }
    }
    // Constructor

    public Product(string id, string name, int price, string description, int quantity)
    {
        ProductId = id;
        Name = name;
        Price = price;
        Description = description;
        StockQuantity = quantity;
    }
    
    // Methods

    public void updateStock(int quantity)
    {
        if (StockQuantity == 0)
        {
            Console.WriteLine("Product is Empty!");
            return;
        }
        StockQuantity -= quantity;
        Console.WriteLine("Product has been Sold!!");
    }

    public decimal applyDiscount(decimal rate)
    {
        rate /= 100;
        Price = Price - (Price * rate);
        return Price;
    }

    public void getDetails()
    {
        Console.WriteLine($"Name : {Name}, Product ID : {ProductId}");
        Console.WriteLine($"Price : {Price}, Description : {Description}, Stock Quantity : {StockQuantity}");
    }

    public override string ToString()
    {
        return $"Name : {Name}, Description : {Description}, Price : {Price}";
    }
}