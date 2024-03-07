using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_iColorable_W07
{
    public abstract class Shape
    {
        public abstract double GetArea();
    }

    public interface IColorable
    {
        void HowToColor();
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
    }

    // Class Rectangle
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double GetArea()
        {
            return width * height;
        }
    }

    public class Triangle : Shape
    {
        private double side1;
        private double side2;
        private double side3;

        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        public override double GetArea()
        {
            double s = (side1 + side2 + side3) / 2;
            return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        }
    }

    public class Square : Rectangle, IColorable
    {
        public Square(double side) : base(side, side)
        {
        }

        public void HowToColor()
        {
            Console.WriteLine("Color all four sides.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[4];
            shapes[0] = new Circle(3);
            shapes[1] = new Rectangle(4, 6);
            shapes[2] = new Square(5);
            shapes[3] = new Triangle(3, 4, 5);

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Area: {shape.GetArea()}");

                if (shape is IColorable)
                {
                    Console.Write("How to color: ");
                    ((IColorable)shape).HowToColor();
                }

                Console.WriteLine();
            }

            Console.ReadLine();

            Console.ReadKey();
        }
    }
}
