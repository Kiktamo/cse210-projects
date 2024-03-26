using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("Purple", 4);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Orange", 10, 5);
        shapes.Add(rectangle);

        Circle circle = new Circle("Green", 8);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"This {shape.GetColor()} shape, has an area of {shape.GetArea()}");          
        }
    }
}