// KineticKineticEquotionResolver.cs
// All rights reserved
// Piotr Makowiec 18-03-2019

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileXamarin.Enums;
using MobileXamarin.Models;

namespace MobileXamarin.EquotionResolvers
{
    /// <inheritdoc />
    public class KineticKineticEquotionResolver : IKineticEquotionResolver
    {

        /// <inheritdoc />
        public async Task<Result> Resolve(double weight, Units weightUnit, double speed, Units speedUnit)
        {
            var solution = new List<string>();
            var lightSpeed = 299792458;
            var normalizedWeight = Normalization.NormalizeWeight(weight, weightUnit);
            var normalizedSpeed = Normalization.NormalizeSpeed(speed, speedUnit);

            await Task.Run(() =>
            {
                var secondStep = @"E_k = \frac{weight * c^2}{\sqrt{\frac{1 - speed^2}{c^2}}} - weight * c^2";
                var mathResult =
                    ((normalizedWeight * Math.Pow(lightSpeed, 2.0)) /
                    Math.Sqrt(1.0 - (Math.Pow(normalizedSpeed, 2.0)) / Math.Pow(lightSpeed, 2.0))) -
                    normalizedWeight * Math.Pow(lightSpeed, 2.0);

                var thirdStep = $"E_k = {mathResult} [J]";
                solution.Add(secondStep);
                solution.Add(thirdStep);
            });

            return new Result(new List<Point>(), solution);
        }
    }
}