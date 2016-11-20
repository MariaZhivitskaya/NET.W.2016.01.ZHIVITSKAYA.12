using System;

namespace Task1.Logic
{
    /// <summary>
    /// Provides methods for calculating characteristics of the circle.
    /// </summary>
    public class Circle : Figure
    {
        private double _r;

        /// <summary>
        /// A property for the radius.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if radius is less or equal than 0.
        /// </exception>
        public double R
        {
            get { return _r; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Wrong radius of the circle!");

                _r = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Circle class
        /// with a specified radius.
        /// </summary>
        /// <param name="r">The radius.</param>
        public Circle(double r)
        {
            R = r;
        }

        /// <summary>
        /// Finds the area of the circle.
        /// </summary>
        /// <returns>Returns the area.</returns>
        public override double Area() => Math.PI * Math.Pow(R, 2);

        /// <summary>
        /// Finds the perimeter of the circle.
        /// </summary>
        /// <returns>Returns the perimeter.</returns>
        public override double Perimeter() => 2 * Math.PI * R;
    }
}
