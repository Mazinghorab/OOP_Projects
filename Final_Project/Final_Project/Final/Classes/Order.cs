using Final.Interfaces;
namespace Final.Classes;

public class Order : IOrder
{
    // Fields
    protected string orderId;
    protected DateTime date { get; private set; }
    protected char status;
    protected decimal fianlTotal;
    protected int purchaseItemsNumber;
    
    // Properties
    public string OrderId
    {
        get { return orderId; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Invalid Order ID!!");
            orderId = value;
        }
    }
    public char Status
    {
        get { return status; }
        private set
        {
            if (value != 'A' && value != 'N')
                throw new Exception("Invalid Status!!");
            status = value;
        }
    }
    public decimal FinalTotal
    {
        get { return fianlTotal; }
        private set
        {
            if (value < 0)
                throw new Exception("Invalid Total!!");
            fianlTotal = value;
        }
    }
    public int PurchaseItemsNumber
    {
        get { return purchaseItemsNumber; }
        private set
        {
            if (value < 0)
                throw new Exception("Invalid Purchase Number!!");
            purchaseItemsNumber = value;
        }
    }
    
    // Constructor
    public Order(string id, char s, decimal tot, int pur)
    {
        OrderId = id;
        Status = s;
        FinalTotal = tot;
        PurchaseItemsNumber = pur;
        date = DateTime.Now;
    }
    
    // Methods
    public void printRecipt()
    {
        Console.WriteLine($"Order ID : {OrderId}, Date : {date}, Status : {Status}");
        Console.WriteLine($"Total : {FinalTotal}, Purchase Number : {PurchaseItemsNumber}");
    }

    public void updateStatus()
    {
        Status = 'N';
    }
    
}