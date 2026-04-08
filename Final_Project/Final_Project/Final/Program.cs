using Final.Classes;
namespace Final;

class Program
{
    static void Main(string[] args)
    {
        ShoppingCart cart = new ShoppingCart("12");
        Customer customer = new Customer("11", "Muhammed", "Muhammed06@gmail.com", "El Haram", cart);
        while (true)
        {
            Console.WriteLine("Welcome to E-commerce Shopping System");
            Console.WriteLine("Please Selcet from the Given : ");
            Console.WriteLine("1. Place an Order");
            Console.WriteLine("2. add item");
            Console.WriteLine("3. remove item");
            Console.WriteLine("4. Get Total Items");
            Console.WriteLine("5. Clear the Cart from Items");
            Console.WriteLine("6. Get the Customer Check out");
            Console.WriteLine("7. view Order History");
            Console.WriteLine("0. Exit");
            if (int.TryParse(Console.ReadLine(), out int Chosen))
            {
                switch (Chosen)
                {
                    case 1: Ch1(customer); break;
                    case 2: Ch2(cart); break;
                    case 3: Ch3(cart, "22"); break;
                    case 4: Ch4(cart); break;
                    case 5: Ch5(cart); break;
                    case 6: Ch6(customer); break;
                    case 7: Ch7(customer); break;
                    case 0 : return;
                    default :
                        Console.WriteLine("Please, Enter a Number betweem 1 to 8");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input!!");
                continue;
            }
        }
    }

    public static void Ch1(Customer customer)
    {
        Order order = new Order("10", 'A', 2000, 3);
        customer.OrderHistory.Add(order);
        Console.WriteLine("Order placed successfully!");
    }
    public static void Ch2(ShoppingCart cart)
    {
        Product product = new Product("15", "Joystick", 768, "PS2 Joystick", 10);
        cart.addItem(product, 2);
        product.updateStock(2);
        Console.WriteLine($"{product.Name} added to the Cart.");
    }
    public static void Ch3(ShoppingCart cart, string id)
    {
        cart.removeItem(id);
        Console.WriteLine($"Item with id : {id} has beem Removed.");
    }
    public static void Ch4(ShoppingCart cart)
    {
        Console.WriteLine($"Total Items : {cart.calculateTotalItems()}");
    }
    public static void Ch5(ShoppingCart cart)
    {
        cart.clearCart();
    }
    public static void Ch6(Customer customer)
    {
        customer.checkout();
    }
    public static void Ch7(Customer customer)
    {
        customer.viewOrderHistory();
    }
}