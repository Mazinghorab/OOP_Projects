namespace OOP_Project.Classes_and_Interfaces;

public abstract class PaymentMethod
{
    protected string name;
    protected string id;
    protected string CardNumber;
    protected double amount;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid Name");
            name = value;
        }
    }
    public string Id
    {
        get { return id; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid ID");
            id = value;
        }
    }
    public string Cardnumber
    {
        get { return CardNumber; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid CardNumber");
            CardNumber = value;
        }
    }
    public double Amount
    {
        get { return amount; }
        set
        {
            if (value < 0)
                throw new Exception("Invalid Amount");
            amount = value;
        }
    }
    
    public PaymentMethod(string namee, string idd, string CardNumberr, double amountt)
    {
        Name = namee;
        Id = idd;
        Cardnumber = CardNumberr;
        Amount = amountt;
    }

}