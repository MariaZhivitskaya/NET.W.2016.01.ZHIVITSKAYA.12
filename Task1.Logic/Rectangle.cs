using System;

namespace Task1.Logic
{
    /// <summary>
    /// Provides methods for calculating characteristics of the rectangle.
    /// </summary>
    public class Rectangle : Figure
    {
        private double _a;
        private double _b;

        /// <summary>
        /// A property for the first side.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the first side is less or equal than 0.
        /// </exception>
        public double A
        {
            get { return _a; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Wrong side of the rectangle!");

                _a = value;
            }
        }

        /// <summary>
        /// A property for the second side.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the second side is less or equal than 0.
        /// </exception>
        public double B
        {
            get { return _b; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Wrong side of the rectangle!");

                _b = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Rectangle class
        /// with specified sides.
        /// </summary>
        /// <param name="a">The first side.</param>
        /// <param name="b">The second side.</param>
        public Rectangle(double a, double b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Finds the area of the rectangle.
        /// </summary>
        /// <returns>Returns the area.</returns>
        public override double Area() => A * B;

        /// <summary>
        /// Finds the perimeter of the rectangle.
        /// </summary>
        /// <returns>Returns the perimeter.</returns>
        public override double Perimeter() => 2 * (A + B);
    }
}
