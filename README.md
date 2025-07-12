# SOLID

## 1. Single Responsibility Principle

**A class should have only one reason to change**

### Class Diagram

```mermaid
classDiagram
    class BreadBaker {
        +BakeBread()
    }

    class InventoryManager {
        +ManageInventory()
    }

    class SupplyOrder {
        +OrderSupplies()
    }

    class CustomerService {
        +ServeCustomer()
    }

    class BakeryCleaner {
        +CleanBakery()
    }

    class Program {
        +Main()
    }

    Program --> BreadBaker : uses
    Program --> InventoryManager : uses
    Program --> SupplyOrder : uses
    Program --> CustomerService : uses
    Program --> BakeryCleaner : uses
```

### Sequence Diagram

```mermaid
sequenceDiagram
    participant Program
    participant BreadBaker
    participant InventoryManager
    participant SupplyOrder
    participant CustomerService
    participant BakeryCleaner

    Program->>BreadBaker: BakeBread()
    BreadBaker-->>Program: "Baking high-quality bread..."

    Program->>InventoryManager: ManageInventory()
    InventoryManager-->>Program: "Managing inventory..."

    Program->>SupplyOrder: OrderSupplies()
    SupplyOrder-->>Program: "Ordering supplies..."

    Program->>CustomerService: ServeCustomer()
    CustomerService-->>Program: "Serving customers..."

    Program->>BakeryCleaner: CleanBakery()
    BakeryCleaner-->>Program: "Cleaning the bakery..."
```

```csharp
using System;

// Class for baking bread
public class BreadBaker
{
    public void BakeBread()
    {
        Console.WriteLine("Baking high-quality bread...");
    }
}

// Class for managing inventory
public class InventoryManager
{
    public void ManageInventory()
    {
        Console.WriteLine("Managing inventory...");
    }
}

// Class for ordering supplies
public class SupplyOrder
{
    public void OrderSupplies()
    {
        Console.WriteLine("Ordering supplies...");
    }
}

// Class for serving customers
public class CustomerService
{
    public void ServeCustomer()
    {
        Console.WriteLine("Serving customers...");
    }
}

// Class for cleaning the bakery
public class BakeryCleaner
{
    public void CleanBakery()
    {
        Console.WriteLine("Cleaning the bakery...");
    }
}

class Program
{
    static void Main()
    {
        var baker = new BreadBaker();
        var inventoryManager = new InventoryManager();
        var supplyOrder = new SupplyOrder();
        var customerService = new CustomerService();
        var cleaner = new BakeryCleaner();
        
        // Each class focuses on its specific responsibility
        baker.BakeBread();
        inventoryManager.ManageInventory();
        supplyOrder.OrderSupplies();
        customerService.ServeCustomer();
        cleaner.CleanBakery();
    }
}
```

## 2. Open/Closed Principle

**Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification**

### Class Diagram

```mermaid
classDiagram
    class IPaymentProcessor {
        +void ProcessPayment(double amount)
    }

    class CreditCardPaymentProcessor {
        +void ProcessPayment(double amount)
    }

    class PayPalPaymentProcessor {
        +void ProcessPayment(double amount)
    }

    class Program {
        +static void ProcessPayment(IPaymentProcessor processor, double amount)
        +static void Main()
    }

    IPaymentProcessor <|.. CreditCardPaymentProcessor
    IPaymentProcessor <|.. PayPalPaymentProcessor
    Program ..> IPaymentProcessor : uses

```

### Sequence Diagram

```mermaid
sequenceDiagram
    participant Main
    participant Program
    participant CreditCardProcessor as CreditCardPaymentProcessor
    participant PayPalProcessor as PayPalPaymentProcessor

    Main->>Program: Main()
    Program->>CreditCardProcessor: new CreditCardPaymentProcessor()
    Program->>PayPalProcessor: new PayPalPaymentProcessor()

    Program->>Program: ProcessPayment(creditCardProcessor, 100.00)
    Program->>CreditCardProcessor: ProcessPayment(100.00)
    CreditCardProcessor-->>Program: [Console Output]

    Program->>Program: ProcessPayment(payPalProcessor, 150.00)
    Program->>PayPalProcessor: ProcessPayment(150.00)
    PayPalProcessor-->>Program: [Console Output]
```

```csharp
using System;

// Base interface for payment processing
public interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

// Credit card payment processor
public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing credit card payment of ${amount}");
    }
}

// PayPal payment processor
public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing PayPal payment of ${amount}");
    }
}

class Program
{
    static void ProcessPayment(IPaymentProcessor processor, double amount)
    {
        processor.ProcessPayment(amount);
    }

    static void Main()
    {
        var creditCardProcessor = new CreditCardPaymentProcessor();
        var payPalProcessor = new PayPalPaymentProcessor();
        
        ProcessPayment(creditCardProcessor, 100.00);
        ProcessPayment(payPalProcessor, 150.00);
    }
}
```

## 3. Liskov's Substitution Principle

**Derived or child classes must be substitutable for their base or parent classes**

### Class Diagram

```mermaid
classDiagram
    class IShape {
        +int GetArea()
    }

    class Rectangle {
        +int Width
        +int Height
        +Rectangle(int width, int height)
        +int GetArea()
    }

    class Square {
        +int Side
        +Square(int side)
        +int GetArea()
    }

    class AreaCalculator {
        +static void PrintArea(IShape shape)
    }

    class Program {
        +void Main()
    }

    IShape <|.. Rectangle
    IShape <|.. Square
    Program --> Rectangle : uses
    Program --> Square : uses
    AreaCalculator --> IShape : uses
```

### Sequence Diagram

```mermaid
sequenceDiagram
    participant Program
    participant Rectangle
    participant Square
    participant AreaCalculator
    participant Console

    Program->>Rectangle: new Rectangle(5, 10)
    Program->>Square: new Square(5)

    Program->>AreaCalculator: PrintArea(rectangle)
    AreaCalculator->>Rectangle: GetArea()
    Rectangle-->>AreaCalculator: return 50
    AreaCalculator->>Console: Print "Area: 50"

    Program->>AreaCalculator: PrintArea(square)
    AreaCalculator->>Square: GetArea()
    Square-->>AreaCalculator: return 25
    AreaCalculator->>Console: Print "Area: 25"
```

```csharp
using System;

namespace LSPExample
{
    // Interface that both shapes will implement
    public interface IShape
    {
        int GetArea();
    }

    // Rectangle implementation
    public class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    // Square implementation using composition, not inheritance
    public class Square : IShape
    {
        public int Side { get; set; }

        public Square(int side)
        {
            Side = side;
        }

        public int GetArea()
        {
            return Side * Side;
        }
    }

    // A utility class to demonstrate LSP
    public class AreaCalculator
    {
        public static void PrintArea(IShape shape)
        {
            Console.WriteLine("Area: " + shape.GetArea());
        }
    }

    // Test the implementation
    class Program
    {
        static void Main(string[] args)
        {
            IShape rectangle = new Rectangle(5, 10);
            IShape square = new Square(5);

            AreaCalculator.PrintArea(rectangle); // Output: Area: 50
            AreaCalculator.PrintArea(square);    // Output: Area: 25
        }
    }
}
```

## 4. Interface Segregation Principle

**Do not force any client to implement an interface which is irrelevant to them.**

```csharp
using System;

public interface IPrinter
{
    void Print(string document);
}

public interface IScanner
{
    void Scan(string document);
}

public interface IFax
{
    void Fax(string document);
}

// BasicPrinter implements only what it needs (IPrinter)
public class BasicPrinter : IPrinter
{
    public void Print(string document)
    {
        Console.WriteLine($"Printing: {document}");
    }
}

// AdvancedPrinter implements all capabilities
public class AdvancedPrinter : IPrinter, IScanner, IFax
{
    public void Print(string document)
    {
        Console.WriteLine($"Printing: {document}");
    }

    public void Scan(string document)
    {
        Console.WriteLine($"Scanning: {document}");
    }

    public void Fax(string document)
    {
        Console.WriteLine($"Faxing: {document}");
    }
}

// Example usage
class Program
{
    static void Main()
    {
        IPrinter basicPrinter = new BasicPrinter();
        basicPrinter.Print("Basic Document");

        AdvancedPrinter advancedPrinter = new AdvancedPrinter();
        advancedPrinter.Print("Advanced Document");
        advancedPrinter.Scan("Advanced Document");
        advancedPrinter.Fax("Advanced Document");
    }
}
```

## 5. Dependency Inversion Principle

**High-level modules should not depend on low-level modules. Both should depend on abstractions**

```csharp
using System;
using System.Collections.Generic;

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

// 5. Program entry point
public class Program
{
    public static void Main(string[] args)
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
```
