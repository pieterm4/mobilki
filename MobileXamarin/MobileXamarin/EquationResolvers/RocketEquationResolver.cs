// RocketEquationResolver.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileXamarin.Models;

namespace MobileXamarin.EquationResolvers
{
    /// <inheritdoc />
    public class RocketEquationResolver : IRocketEquationResolver
    {
        /// <summary>
        /// Resolves rocket equation
        /// </summary>
        /// <param name="rocketParameter">Parameters of the rocket</param>
        /// <returns>Result</returns>
        public async Task<Result> Resolve(RocketParameter rocketParameter)
        {
            var time = Normalization.NormalizeTime(rocketParameter.FlightTime, rocketParameter.FlightTimeUnit);
            var massOfTheRocket = rocketParameter.MassOfTheRocket + rocketParameter.MassOfTheFuel;
            var solution =  await Task.Run(() =>
            {
                var first = @"a = \frac{dv}{dt} = \frac{u}{M} * \frac{dM}{dt} - g";
                var second = @"dv = \frac{u}{M} * dM - gdt";
                var third = @"\int_{v_0}^{v} dv = -u \int_{m_0}^{m} \frac{dM}{M} - \int_{0}^{t} g dt";
                var fourth = @"v(t) = v_0 + u ln\frac{m_0}{m_0 - n_g * t}";

                var mathResult = CalculateVelocity(time);
                var fifth = $"v({time}) = {mathResult} [m/s]";

                var result = new List<string>
                {
                    first,
                    second,
                    third,
                    fourth,
                    fifth
                };

                var controlPoints = new List<Point>();

                for (int i = 0; i <= time; i++)
                {
                    controlPoints.Add(new Point(i, CalculateVelocity(i)));
                }

                return new Result(controlPoints, result);


                double CalculateVelocity(double time1)
                {
                    return rocketParameter.ProperImpulse *
                           Math.Log((massOfTheRocket) /
                                    (massOfTheRocket - rocketParameter.AmountOfThrownFuel * time1));
                }
            });

            return solution;
        }
    }
}