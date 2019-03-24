// RocketEquationResult.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System.Collections.Generic;
using System.Drawing;

namespace MobileXamarin.Models
{
    /// <summary>
    /// Result of rocket equation resolver
    /// </summary>
    public class RocketEquationResult
    {
        /// <summary>
        /// Control points for the chart
        /// </summary>
        public IEnumerable<Point> ControlPoints { get; }

        /// <summary>
        /// Latex representation of the velocity at the end of the rocket's flight time
        /// </summary>
        public string Result { get; }

        /// <summary>
        /// Constructor for Rocket EquationResult
        /// </summary>
        /// <param name="controlPoints">Control points for chart</param>
        /// <param name="result">Latex representation of the velocity at the end of the rocket's flight</param>
        public RocketEquationResult(IEnumerable<Point> controlPoints, string result)
        {
            ControlPoints = controlPoints;
            Result = result;
        }
    }
}