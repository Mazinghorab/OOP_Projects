namespace OOP_Project.Classes_and_Interfaces;

class PayPal : PaymentMethod, IPaymentProcessor
{
    public PayPal(string name, string id, string cardnumber, double amount)
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
        return Amount > 0 && Amount <= 10000;
    }

    public string GetPaymentMethod()
    {
        return "Pay Pal";
    }

    public void PrintReceipt()
    {
        Console.WriteLine($"Name : {Name}, ID : {Id}");
        Console.WriteLine($"Card Number {Cardnumber}");
        Console.WriteLine($"Your Amount is : {Amount}");
    }
    public override string ToString()
    {
        return "It's Pay Pal";
    }
}