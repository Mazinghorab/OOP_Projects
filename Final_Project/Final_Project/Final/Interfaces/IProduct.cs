namespace Final.Interfaces;

public interface IProduct
{
    void getDetails();
    void updateStock(int quantity);
    decimal applyDiscount(decimal rate);
}