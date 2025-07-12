namespace _5_DIP_AntiPattern
{
    // 1. Low-level module: Database data source
    public class DatabaseDataSource
    {
        public List<string> GetData()
        {
            // Simulate fetching data from a database
            return new List<string> { "DB Record 1", "DB Record 2", "DB Record 3" };
        }
    }

    // 2. Low-level module: API data source
    public class APIDataSource
    {
        public List<string> GetData()
        {
            // Simulate fetching data from an API
            return new List<string> { "API Data 1", "API Data 2" };
        }
    }

    // 3. High-level module: Report class (tightly coupled to low-level modules)
    public class Report
    {
        private readonly DatabaseDataSource _dbSource;
        private readonly APIDataSource _apiSource;

        public Report()
        {
            // Direct instantiation (tight coupling)
            _dbSource = new DatabaseDataSource();
            _apiSource = new APIDataSource();
        }

        public void GenerateFromDatabase()
        {
            List<string> data = _dbSource.GetData();
            Console.WriteLine("Report from Database:");
            foreach (string item in data)
            {
                Console.WriteLine($"- {item}");
            }
        }

        public void GenerateFromAPI()
        {
            List<string> data = _apiSource.GetData();
            Console.WriteLine("Report from API:");
            foreach (string item in data)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}
