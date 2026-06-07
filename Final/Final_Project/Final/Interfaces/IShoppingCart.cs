using Final.Classes;
namespace Final.Interfaces;

public interface IShoppingCart
{
    void addItem(Product product, int quantity);
    void removeItem(string productId);
    int calculateTotalItems();
    void clearCart();
}