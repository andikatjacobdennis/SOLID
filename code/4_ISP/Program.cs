namespace _4_ISP
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
            var basicPrinter = new _4_ISP_AntiPattern.BasicPrinter();
            basicPrinter.Print("Basic Document");

            try
            {
                basicPrinter.Scan("Basic Document"); // Will throw exception
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine(e.Message);
            }

            var advancedPrinter = new _4_ISP_AntiPattern.AdvancedPrinter();
            advancedPrinter.Print("Advanced Document");
            advancedPrinter.Scan("Advanced Document");
            advancedPrinter.Fax("Advanced Document");
        }

        private static void RunSolution()
        {
            IPrinter basicPrinter = new BasicPrinter();
            basicPrinter.Print("Basic Document");

            AdvancedPrinter advancedPrinter = new AdvancedPrinter();
            advancedPrinter.Print("Advanced Document");
            advancedPrinter.Scan("Advanced Document");
            advancedPrinter.Fax("Advanced Document");
        }
    }
}
