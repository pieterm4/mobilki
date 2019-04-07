// Point.cs
// All rights reserved
// Piotr Makowiec 26-03-2019

namespace MobileXamarin.Models
{
    /// <summary>
    /// Point with double points
    /// </summary>
    public class Point
    {
        /// <summary>
        /// X value
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Y value
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Point constructor
        /// </summary>
        /// <param name="x">X value</param>
        /// <param name="y">Y value</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"P({X}, {Y})";
        }
    }
}