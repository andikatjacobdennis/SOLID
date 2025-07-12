namespace _1_SRP_AntiPattern
{
    // This class violates the Single Responsibility Principle (SRP)
    // because it has multiple responsibilities and does not adhere to SRP.
    // It should be refactored into smaller classes, each with a single responsibility.
    public class BakeryManager
    {
        public void BakeBread()
        {
            Console.WriteLine("Baking high-quality bread...");
        }

        public void ManageInventory()
        {
            Console.WriteLine("Managing inventory...");
        }

        public void OrderSupplies()
        {
            Console.WriteLine("Ordering supplies...");
        }

        public void ServeCustomer()
        {
            Console.WriteLine("Serving customers...");
        }

        public void CleanBakery()
        {
            Console.WriteLine("Cleaning the bakery...");
        }
    }
}
