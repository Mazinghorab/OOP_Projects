namespace OOP_Project.Classes_and_Interfaces;

class CreditCard : PaymentMethod, IPaymentProcessor
{
    public CreditCard(string name, string id, string cardnumber, double amount)
        : base(name, id, cardnumber, amount)
    {
        
    }
    public void ProcessPayemnt()
    {
        if (!ValidatePayment())
        {
            Console.WriteLine("Failed to Process");
            return;
        }
        
        Console.WriteLine($"Payment : {Amount}");
    }

    public bool ValidatePayment()
    {
        return amount > 0 && amount <= 50000;
    }

    public string GetPaymentMethod()
    {
        return "Credit Card";
    }

    public void PrintReceipt()
    {
        Console.WriteLine($"Name : {Name}, ID : {Id}");
        Console.WriteLine($"Card Number {Cardnumber}");
        Console.WriteLine($"Your Amount is : {Amount}");
    }

    public override string ToString()
    {
        return "It's Credit Card";
    }
}