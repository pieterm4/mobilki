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
        /// Points before calculation
        /// </summary>
        public IEnumerable<Point> StartPoints { get; }

        /// <summary>
        /// Constructor for Result
        /// </summary>
        /// <param name="controlPoints">Control points for chart</param>
        /// <param name="solution">Latex representation of the velocity at the end of the rocket's flight</param>
        public Result(IEnumerable<Point> controlPoints, IEnumerable<string> solution)
        {
            ControlPoints = controlPoints;
            Solution = solution;
        }

        /// <summary>
        /// Constructor for Result
        /// </summary>
        /// <param name="controlPoints">Control points for chart</param>
        /// <param name="solution">Latex representation of the velocity at the end of the rocket's flight</param>
        /// <param name="startPoints">Points before calculation</param>
        public Result(IEnumerable<Point> controlPoints, IEnumerable<string> solution, IEnumerable<Point> startPoints) : this(controlPoints, solution)
        {
            StartPoints = startPoints;
        }
    }
}