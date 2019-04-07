// LagrangeResolver.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileXamarin.Models;

namespace MobileXamarin.EquotionResolvers
{
    /// <summary>
    /// Lagrange resolver
    /// </summary>
    public class LagrangeResolver : ILagrangeResolver
    {
        /// <summary>
        /// Resolves lagrange interpolation
        /// </summary>
        /// <param name="controlPoints">Control points based on interpolation is calculated</param>
        /// <returns>Points which can be displayed on the chart</returns>
        public async Task<Result> Resolve(IEnumerable<Point> controlPoints)
        {
            var interpolatedPoints = new List<Point>();
            const int dataPoints = 1000;
            var points = controlPoints.ToList();

            var orderedControlPoints = points.OrderBy(x => x.X).ToList();


            return await Task.Run( () =>
            {
                for (int i = 0; i < dataPoints; i++)
                {
                    var y = Interpolate(i * orderedControlPoints.Last().X / dataPoints, orderedControlPoints);
                    var x = i * orderedControlPoints.Last().X / dataPoints;

                    interpolatedPoints.Add(new Point(x, y));
                }

                interpolatedPoints.RemoveAll(x => x.X < points.First().X - 0.1);
                var orderedInterpolatedPoints = interpolatedPoints.OrderBy(x => x.X).ToList();
                var solution = orderedInterpolatedPoints.Select(x => x.ToString());
                var result = new Result(orderedInterpolatedPoints, solution, orderedControlPoints);

                return result;
            });
        }

        private double Interpolate(double xp, List<Point> orderedControlPoints)
        {
            var amountOfControlPoints = orderedControlPoints.Count;
            double yp;
            int i, k;
            yp = 0.0;
            for (i = 0; i < amountOfControlPoints; i++)
            {
                var nominator = 1.0;
                var denominator = 1.0;
                /* calculate the Lk elements */
                for (k = 0; k < amountOfControlPoints; k++)
                {
                    if (k != i)
                    {
                        /* nominator and denominator for one L element */
                        nominator = nominator * (xp - orderedControlPoints.ElementAt(k).X);
                        denominator = denominator * (orderedControlPoints.ElementAt(i).X - orderedControlPoints.ElementAt(k).X);
                    }
                }
                /* put every thing thogether to yp*/
                if (Math.Abs(denominator) > double.Epsilon)
                    yp = yp + orderedControlPoints.ElementAt(i).Y * nominator / denominator;
                else
                    yp = 0.0;
            }
            return yp;
        }
    }
}