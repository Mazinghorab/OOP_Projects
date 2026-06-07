using Final.Interfaces;
namespace Final.Classes;

public class ShoppingCart : IShoppingCart
{
    // Fields
    protected Dictionary<Product, int> Items;
    protected string cartId;
    
    // Properties
    public string CartId
    {
        get { return cartId; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid Number for Cart ID!!");
            cartId = value;
        }
    }
    
    // Constructor
    public ShoppingCart(string id)
    {
        CartId = id;
        this.Items = new Dictionary<Product, int>();
    }
    
    // Methods
    public void addItem(Product product, int quantity)
    {
        if (Items.ContainsKey(product))
        {
            Items[product] += quantity;
        }
        else
            Items.Add(product, quantity);
            
    }

    public void removeItem(string productId)
    {
        if (Items.Count == 0)
        {
            Console.WriteLine("Cannot remove an Item from an Empty Shopping Cart!!!");
            return;
        }

        var itemToRemove = Items.Keys.FirstOrDefault(k => k.ProductId == productId);
        if (itemToRemove != null)
        {
            Items.Remove(itemToRemove);
            Console.WriteLine($"Product {productId} is removed.");
        }
        else
        {
            Console.WriteLine("Item not found in cart.");
        }
    }

    public int calculateTotalItems()
    {
        return Items.Count;
    }

    public void clearCart()
    {
        if (Items.Count == 0)
        {
            Console.WriteLine("Cannot Clear an Empty Cart!!");
            return;
        }
        Items.Clear();
    }
    
}