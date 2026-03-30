namespace OOP_Project.Classes_and_Interfaces;

class Ethereum : CryptoCurrency, ICryptoCurrencyProcessor
{
    public Ethereum(string name, string id, double amount)
        : base(name, id, amount)
    {
        
    }
    public void ProcessCrypto()
    {
        Console.WriteLine($"Amount : {Amount}");
    }

    public string GetCryptoMethod()
    {
        return "Ethereum";
    }

    public void PrintReceipt()
    {
        Console.WriteLine($"Name : {Name}, ID : {Id}");
        Console.WriteLine($"Your Amount is : {Amount}");
    }
    public override string ToString()
    {
        return "It's Ethereum";
    }
}