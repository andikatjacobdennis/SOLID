namespace _3_LSP
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
}
