using System;

namespace Task1.Logic
{
    /// <summary>
    /// Provides methods for calculating characteristics of the triangle.
    /// </summary>
    public class Triangle : Figure
    {
        private double _a;
        private double _b;
        private double _c;

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
                    throw new ArgumentOutOfRangeException("Wrong side of the triangle!");

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
                    throw new ArgumentOutOfRangeException("Wrong side of the triangle!");

                _b = value;
            }
        }

        /// <summary>
        /// A property for the third side.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the third side is less or equal than 0.
        /// </exception>
        public double C
        {
            get { return _c; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Wrong side of the triangle!");

                _c = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Triangle class
        /// with specified sides.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if sides are wrong.
        /// </exception>
        /// <param name="a">The first side.</param>
        /// <param name="b">The second side.</param>
        /// <param name="c">The third side.</param>
        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            if (!IsTriangle())
                throw new ArgumentOutOfRangeException("The triangle with" +
                                                      "specified sides doesn't exist!");
        }

        /// <summary>
        /// Finds the area of the triangle
        /// according to the Heron's formula.
        /// </summary>
        /// <returns>Returns the area.</returns>
        public override double Area() =>
            Math.Sqrt(Semiperimeter() * (Semiperimeter() - A) *
                (Semiperimeter() - B) * (Semiperimeter() - C));

        /// <summary>
        /// Finds the perimeter of the triangle.
        /// </summary>
        /// <returns>Returns the perimeter.</returns>
        public override double Perimeter() => A + B + C;

        /// <summary>
        /// Finds the semiperimeter of the triangle.
        /// </summary>
        /// <returns>Returns the semiperimeter.</returns>
        public double Semiperimeter() => Perimeter() / 2;

        /// <summary>
        /// Indicates whether the triangle with specified sides can exist.
        /// </summary>
        /// <returns>Returns true or false.</returns>
        private bool IsTriangle() => 
            A + B >= C && A + C >= B && B + C >= A;
    }
}
