namespace _3_LSP
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
            var rectangle = new _3_LSP_AntiPattern.Rectangle();
            var square = new _3_LSP_AntiPattern.Square();

            _3_LSP_AntiPattern.AreaCalculator.PrintArea(rectangle); // Output: Area: 50
            _3_LSP_AntiPattern.AreaCalculator.PrintArea(square);    // Output: Area: 100 (unexpected!)
        }

        private static void RunSolution()
        {
            IShape rectangle = new Rectangle(5, 10);
            IShape square = new Square(5);

            AreaCalculator.PrintArea(rectangle); // Output: Area: 50
            AreaCalculator.PrintArea(square);    // Output: Area: 25
        }
    }
}
