namespace _5_DIP
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
            var report = new _5_DIP_AntiPattern.Report();

            report.GenerateFromDatabase();
            Console.WriteLine();
            report.GenerateFromAPI();
        }

        private static void RunSolution()
        {
            // Easily switch data sources here
            IDataSource dbSource = new DatabaseDataSource();
            IDataSource apiSource = new APIDataSource();

            Console.WriteLine("Using DatabaseDataSource:");
            Report reportFromDb = new Report(dbSource);
            reportFromDb.Generate();

            Console.WriteLine("\nUsing APIDataSource:");
            Report reportFromApi = new Report(apiSource);
            reportFromApi.Generate();
        }
    }
}
