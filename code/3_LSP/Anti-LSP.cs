namespace _3_LSP_AntiPattern
{
    // Rectangle class
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    // Square inherits from Rectangle (Anti-LSP)
    public class Square : Rectangle
    {
        public override int Width
        {
            get { return base.Width; }
            set
            {
                base.Width = value;
                base.Height = value; // Side effect: changing Width also changes Height
            }
        }

        public override int Height
        {
            get { return base.Height; }
            set
            {
                base.Height = value;
                base.Width = value; // Side effect: changing Height also changes Width
            }
        }
    }

    // A utility class to demonstrate LSP violation
    public class AreaCalculator
    {
        public static void PrintArea(Rectangle rectangle)
        {
            rectangle.Width = 5;
            rectangle.Height = 10;

            // Expected: 5 * 10 = 50
            // But if rectangle is actually a Square, it will be 10 * 10 = 100
            Console.WriteLine("Area: " + rectangle.GetArea());
        }
    }
}