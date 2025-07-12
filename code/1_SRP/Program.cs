namespace _1_SRP
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

        private static void RunProblem()
        {
            var manager = new _1_SRP_AntiPattern.BakeryManager();

            // One class is handling all responsibilities
            manager.BakeBread();
            manager.ManageInventory();
            manager.OrderSupplies();
            manager.ServeCustomer();
            manager.CleanBakery();
        }

        private static void RunSolution()
        {
            var baker = new BreadBaker();
            var inventoryManager = new InventoryManager();
            var supplyOrder = new SupplyOrder();
            var customerService = new CustomerService();
            var cleaner = new BakeryCleaner();

            // Each class has a single responsibility
            baker.BakeBread();    
            inventoryManager.ManageInventory();
            supplyOrder.OrderSupplies();
            customerService.ServeCustomer();
            cleaner.CleanBakery();
        }
    }
}
