namespace _2_OCP
{
    // Base interface for payment processing
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    // Credit card payment processor
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount}");
        }
    }

    // PayPal payment processor
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount}");
        }
    }
}
