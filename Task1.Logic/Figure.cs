namespace Task1.Logic
{
    /// <summary>
    /// Provides methods for calculating characteristics of figures.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Finds the area.
        /// </summary>
        /// <returns>Returns the area.</returns>
        public abstract double Area();

        /// <summary>
        /// Finds the perimeter. 
        /// </summary>
        /// <returns>Returns the perimeter.</returns>
        public abstract double Perimeter();
    }
}
