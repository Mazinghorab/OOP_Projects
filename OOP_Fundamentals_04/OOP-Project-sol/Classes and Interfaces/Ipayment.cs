namespace OOP_Project.Classes_and_Interfaces;

interface IPaymentProcessor
{
    void ProcessPayemnt();
    bool ValidatePayment();
    string GetPaymentMethod();
    void PrintReceipt();
}