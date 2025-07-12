# Advanced SOLID Principle Interview Questions in C#

## Single Responsibility Principle (SRP)

### Question 1

"You have a class that fetches data from an API, parses the JSON response, logs the data, and saves it to a database. How would you apply SRP here?"

### C# Code Example (Anti-SRP)

```csharp
using System;
using System.Net;
using Newtonsoft.Json;

public class DataProcessor
{
    public void ProcessData()
    {
        var json = new WebClient().DownloadString("https://api.example.com/data");
        var data = JsonConvert.DeserializeObject<Data>(json);
        Console.WriteLine("Data received: " + data);
        SaveToDatabase(data);
    }

    private void SaveToDatabase(Data data)
    {
        // Database save logic
    }
}
```

### Follow-up Answer (SRP)

To follow SRP, we should split the responsibilities into separate classes:

```csharp
public class DataFetcher
{
    public string FetchData(string url) => new WebClient().DownloadString(url);
}

public class DataParser
{
    public Data Parse(string json) => JsonConvert.DeserializeObject<Data>(json);
}

public class DataLogger
{
    public void Log(Data data) => Console.WriteLine("Data received: " + data);
}

public class DataRepository
{
    public void Save(Data data) { /* Database save logic */ }
}

// Usage
var fetcher = new DataFetcher();
var parser = new DataParser();
var logger = new DataLogger();
var repository = new DataRepository();

var json = fetcher.FetchData("https://api.example.com/data");
var data = parser.Parse(json);
logger.Log(data);
repository.Save(data);
```

## Open/Closed Principle (OCP)

### Question 2

"How can the Strategy Pattern support the Open/Closed Principle? Can you provide an example where it fails to do so if misused?"

### C# Code Prompt (Anti-OCP)

```csharp
using System;

public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal total);
}

public class BlackFridayDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal total) => total * 0.7m;
}

public class NoDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal total) => total;
}

public class CheckoutService
{
    private readonly IDiscountStrategy _discountStrategy;

    public CheckoutService(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public decimal CalculateTotal(decimal cartTotal)
    {
        return _discountStrategy.ApplyDiscount(cartTotal);
    }
}
```

### Follow-up Answer (OCP)

If someone adds conditional logic inside `ApplyDiscount`, it would violate OCP:

```csharp
// Violation of OCP
public class ConditionalDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal total)
    {
        if (DateTime.Now.Month == 11) return total * 0.7m; // Black Friday
        if (DateTime.Now.Day == 1) return total * 0.9m; // New Year's Day
        return total;
    }
}
```

The correct approach is to create separate strategy classes for each discount type and compose them as needed.

## Liskov Substitution Principle (LSP)

### Question 3

"Suppose you have a base class `Bird` with a method `Fly()`, and then a subclass `Penguin`. How would you redesign this hierarchy to follow LSP?"

### C# Problem Code (Anti-LSP)

```csharp
using System;

public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Flying");
    }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Penguins can't fly");
    }
}
```

### Follow-up Answer (LSP)

Better design would separate flying capability:

```csharp
public class Bird { }

public interface IFlyingBird
{
    void Fly();
}

public class Sparrow : Bird, IFlyingBird
{
    public void Fly() => Console.WriteLine("Flying");
}

public class Penguin : Bird { }
```


## Interface Segregation Principle (ISP)

### Question 4

"How would you refactor an interface with 10 methods, of which only 3 are used by most implementers?"

### C# Code Prompt (Anti-ISP)

```csharp
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
    void AttendMeetings();
    void FileReports();
    // 5 more...
}
```

### Follow-up Answer (ISP)

Split into role-specific interfaces:

```csharp
public interface IWorkable { void Work(); }
public interface IFeedable { void Eat(); }
public interface IRestable { void Sleep(); }
public interface IManager { void AttendMeetings(); }
public interface IOfficeWorker { void FileReports(); }

// Classes implement only what they need
public class Developer : IWorkable, IFeedable, IRestable
{
    public void Work() { /* coding */ }
    public void Eat() { /* lunch */ }
    public void Sleep() { /* rest */ }
}
```

Forcing unused methods leads to:

1. Bloated implementations
2. Violation of SRP
3. Confusing API contracts
4. Potential NotImplementedExceptions

## Dependency Inversion Principle (DIP)

### Question 5

"What's the difference between Dependency Injection and Dependency Inversion? Are they always used together?"

### Question 6

"In a plugin architecture, how would you apply DIP so that plugins don't tightly couple to the main system?"

### C# Code Prompt (Anti-DIP)

```csharp
public interface IDataExporter
{
    void Export(string data);
}

public class ReportGenerator
{
    private readonly IDataExporter _exporter;

    public ReportGenerator(IDataExporter exporter)
    {
        _exporter = exporter;
    }

    public void GenerateReport()
    {
        _exporter.Export("report data");
    }
}
```

### Follow-up Answers (DIP)

**Question 5 Answer:**

- **Dependency Inversion Principle** is a design principle stating that high-level modules shouldn't depend on low-level modules (both should depend on abstractions)
- **Dependency Injection** is an implementation technique to achieve loose coupling
- They often work together but are distinct concepts

**Question 6 Answer:**
For plugins:

1. Define core interfaces in a shared assembly
2. Plugins implement these interfaces
3. Host application discovers and loads plugins via reflection
4. Communication happens only through interfaces

Example:

```csharp
// In shared contract assembly
public interface IPlugin
{
    string Name { get; }
    void Execute();
}

// Host application loads all IPlugin implementations
var plugins = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface)
    .Select(t => (IPlugin)Activator.CreateInstance(t));

foreach (var plugin in plugins)
{
    plugin.Execute();
}
```

## Bonus Conceptual Question

### Question 7

"What is the difference between the Open/Closed Principle and the Liskov Substitution Principle?"

### Complete Answer

**Key Difference:**

- OCP is about how to structure your system for easy extension
- LSP is about how to properly implement inheritance hierarchies
- OCP violations make the system rigid to changes
- LSP violations lead to runtime errors and unexpected behavior
