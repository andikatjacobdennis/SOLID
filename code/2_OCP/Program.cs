namespace _2_OCP
{
    internal class Program
    {
        static void Main()
        {
            bool runSolution = true;

            if (runSolution)
            {
                RunSolution();
            }
            else
            {
                RunProblem();
            }
        }

        private static void ProcessPayment(IPaymentProcessor processor, double amount)
        {
            processor.ProcessPayment(amount);
        }

        private static void RunProblem()
        {
            var processor = new _2_OCP_AntiPattern.PaymentProcessor();

            processor.ProcessPayment("creditcard", 100.00);
            processor.ProcessPayment("paypal", 150.00);
        }

        private static void RunSolution()
        {
            var creditCardProcessor = new CreditCardPaymentProcessor();
            var payPalProcessor = new PayPalPaymentProcessor();

            ProcessPayment(creditCardProcessor, 100.00);
            ProcessPayment(payPalProcessor, 150.00);
        }
    }
}
