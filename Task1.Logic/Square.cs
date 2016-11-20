using System;

namespace Task1.Logic
{
    public class Square : Figure
    {
        private double _a;

        /// <summary>
        /// A property for the side.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the side is less or equal than 0.
        /// </exception>
        public double A
        {
            get { return _a; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Wrong side of the square!");

                _a = value;
            }
        }


        /// <summary>
        /// Initializes a new instance of the Square class
        /// with a specified side.
        /// </summary>
        /// <param name="a">The side.</param>
        public Square(double a)
        {
            A = a;
        }

        /// <summary>
        /// Finds the area of the square.
        /// </summary>
        /// <returns>Returns the area.</returns>
        public override double Area() => A * A;

        /// <summary>
        /// Finds the perimeter of the square.
        /// </summary>
        /// <returns>Returns the perimeter.</returns>
        public override double Perimeter() => 4 * A;
    }
}
