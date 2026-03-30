namespace OOP_Project.Classes_and_Interfaces;

public abstract class CryptoCurrency
{
    protected string name;
    protected string id;
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
    public double Amount
    {
        get { return amount; }
        set
        {
            if (value < 0)
                throw new Exception("Invalid amount");
            amount = value;
        }
    }
    
    public CryptoCurrency(string namee, string idd, double amountt)
    {
        Name = namee;
        Id = idd;
        Amount = amountt;
    }

}