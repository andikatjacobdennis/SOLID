namespace _4_ISP
{
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
}
