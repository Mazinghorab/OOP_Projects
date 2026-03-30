namespace OOP_Project.Classes_and_Interfaces;

class BitCoin : CryptoCurrency, ICryptoCurrencyProcessor
{
    public BitCoin(string name, string id, double amount)
        : base(name, id, amount)
    {
        
    }

    public void ProcessCrypto()
    {
        Console.WriteLine($"Amount : {Amount}");
    }

    public string GetCryptoMethod()
    {
        return "Bit Coin";
    }

    public void PrintReceipt()
    {
        Console.WriteLine($"Name : {Name}, ID : {Id}");
        Console.WriteLine($"Your Amount is : {Amount}");
    }

    public override string ToString()
    {
        return "It's Bit Coin";
    }
}