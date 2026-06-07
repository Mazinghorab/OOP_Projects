using Final.Interfaces;
namespace Final.Classes;

public class CartItem : ICartItem
{
    // Fields
    protected Product product;
    protected int quantity;
    
    // Properties
    public int Quantity
    {
        get { return quantity; }
        private set
        {
            if (value <= 0)
                throw new Exception("Invalid Number!!");
            quantity = value;
        }
    }
    
    // Constructor
    public CartItem(Product pr, int q) 
    {
        Quantity = q;
        product = pr;
    }
    
    // Methods
    public void decreaseQuantity()
    {
        if (Quantity <= 0)
        {
            Console.WriteLine("Empty!!");
            return;
        }

        Quantity--;
        Console.WriteLine("Item Has been Taked!!");
    }

    public int TotalQuantity()
    {
        return Quantity;
    }
}