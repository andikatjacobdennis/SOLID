namespace _5_DIP
{
    // 1. The abstraction
    public interface IDataSource
    {
        List<string> GetData();
    }

    // 2. Low-level module: Database data source
    public class DatabaseDataSource : IDataSource
    {
        public List<string> GetData()
        {
            // Simulate fetching data from a database
            return new List<string> { "DB Record 1", "DB Record 2", "DB Record 3" };
        }
    }

    // 3. Low-level module: API data source
    public class APIDataSource : IDataSource
    {
        public List<string> GetData()
        {
            // Simulate fetching data from an API
            return new List<string> { "API Data 1", "API Data 2" };
        }
    }

    // 4. High-level module: Report class
    public class Report
    {
        private readonly IDataSource _dataSource;

        // Dependency Injection via constructor
        public Report(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public void Generate()
        {
            List<string> data = _dataSource.GetData();
            Console.WriteLine("Report Content:");
            foreach (string item in data)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}
