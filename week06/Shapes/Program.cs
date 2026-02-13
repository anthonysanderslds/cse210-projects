using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> _shapes = new List<Shape>();

        Square square = new Square("red", 4);
        Rectangle rectangle = new Rectangle("blue", 3, 3);
        Circle circle = new Circle("pink", 3);

        _shapes.Add(square);
        _shapes.Add(rectangle);
        _shapes.Add(circle);

        foreach (Shape shape in _shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"This {shape} is {color} with an area of {area:0.00} square inches.");
            Console.WriteLine();
        }
    }
}