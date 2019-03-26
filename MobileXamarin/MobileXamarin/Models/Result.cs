// Result.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System.Collections.Generic;

namespace MobileXamarin.Models
{
    /// <summary>
    /// Result of rocket equation resolver
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Control points for the chart
        /// </summary>
        public IEnumerable<Point> ControlPoints { get; }

        /// <summary>
        /// Latex representation of the velocity at the end of the rocket's flight time
        /// </summary>
        public IEnumerable<string> Solution { get; }

        /// <summary>
        /// Constructor for Rocket EquationResult
        /// </summary>
        /// <param name="controlPoints">Control points for chart</param>
        /// <param name="solution">Latex representation of the velocity at the end of the rocket's flight</param>
        public Result(IEnumerable<Point> controlPoints, IEnumerable<string> solution)
        {
            ControlPoints = controlPoints;
            Solution = solution;
        }
    }
}