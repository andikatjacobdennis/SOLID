namespace _2_OCP_AntiPattern
{
    public class PaymentProcessor
    {
        public void ProcessPayment(string paymentType, double amount)
        {
            if (paymentType == "creditcard")
            {
                Console.WriteLine($"Processing credit card payment of ${amount}");
            }
            else if (paymentType == "paypal")
            {
                Console.WriteLine($"Processing PayPal payment of ${amount}");
            }
            else
            {
                Console.WriteLine("Unsupported payment method");
            }
        }
    }
}
