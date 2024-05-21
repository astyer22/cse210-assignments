using System;

class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public  string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    public virtual double GetArea()
    {
        return 0;
    }
}

class Square : Shape
{
    private double _side;

    public Square(double side, string color) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    
}

class Rectangle : Shape
{
    private double _length;
    private double _width;

    public Rectangle(double length, double width, string color) : base(color)
    {
        _length = length;
        _width = width;
    }

    public override double GetArea()
    {
        return _length * _width;
    }
}

class Circle : Shape
{
    private double _radius;

    public Circle(double radius , string color) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square(4, "Red");

        string color = square.GetColor();
        double area = square.GetArea();

        Console.WriteLine($"Color: {color}");
        Console.WriteLine($"Area: {area}");

        Rectangle rectangle = new Rectangle(4, 5, "Blue");

        string color2 = rectangle.GetColor();
        double area2 = rectangle.GetArea();

        Console.WriteLine($"Color: {color2}");
        Console.WriteLine($"Area: {area2}");

        Circle circle = new Circle(4, "Green");

        string color3 = circle.GetColor();
        double area3 = circle.GetArea();

        Console.WriteLine($"Color: {color3}");
        Console.WriteLine($"Area: {area3}");
    }
}
}