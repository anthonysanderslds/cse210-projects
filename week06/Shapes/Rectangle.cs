public class Rectangle : Shape
{
    private double _longSide;
    private double _shortSide;

    public Rectangle(string color, double longSide, double shortSide) : base(color)
    {
        _longSide = longSide;
        _shortSide = shortSide;
    }

    public override double GetArea()
    {
        return _longSide * _shortSide;
    }
}