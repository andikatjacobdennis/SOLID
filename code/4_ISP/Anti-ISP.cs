namespace _4_ISP_AntiPattern
{
    // Violates ISP: Large interface forces implementation of all members
    public interface IMultiFunctionDevice
    {
        void Print(string document);
        void Scan(string document);
        void Fax(string document);
    }

    // BasicPrinter only wants to print, but must implement unused methods
    public class BasicPrinter : IMultiFunctionDevice
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }

        public void Scan(string document)
        {
            throw new NotImplementedException("Scan not supported by BasicPrinter.");
        }

        public void Fax(string document)
        {
            throw new NotImplementedException("Fax not supported by BasicPrinter.");
        }
    }

    // AdvancedPrinter supports all operations, so it's fine here
    public class AdvancedPrinter : IMultiFunctionDevice
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
