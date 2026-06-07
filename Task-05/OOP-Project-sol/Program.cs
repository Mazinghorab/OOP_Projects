using OOP_Project.Classes_and_Interfaces;

namespace OOP_Project;
class Program
{
    static void Main(string[] args)
    {
        Test();
    }

    public static void Test()
    {
        CreditCard c = new CreditCard("Ahmed Ali", "222", "910-110-520-456", 20000);
        PayPal p = new PayPal("Nour Amgad", "998", "154-298-987-376", 30000);
        BitCoin b = new BitCoin("Ahmed Sami", "111", 9000000);
        Ethereum e = new Ethereum("Israa Bakr", "653", 100000);

        c.PrintReceipt();
        Console.WriteLine();
        
        p.PrintReceipt();
        Console.WriteLine();
        
        b.PrintReceipt();
        Console.WriteLine();
        
        e.PrintReceipt();
    }
}

