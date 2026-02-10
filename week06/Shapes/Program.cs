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

        //string sColor = square.GetColor();
        //Console.WriteLine();

        // string rColor = rectangle.GetColor();
        // Console.WriteLine($" The square is {rColor} with an area of {rectangle.GetArea()} square inches.");
        // Console.WriteLine();

        // string cColor = circle.GetColor();
        // Console.WriteLine($" The square is {cColor} with an area of {circle.GetArea():0.00} square inches.");
    }
}