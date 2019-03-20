// KineticKineticEquotionResolver.cs
// All rights reserved
// Piotr Makowiec 18-03-2019

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using MobileXamarin.AppResources.Localization;
using MobileXamarin.Enums;

namespace MobileXamarin.EquotionResolvers
{
    public class KineticKineticEquotionResolver : IKineticEquotionResolver
    {
        public async Task<IEnumerable<string>> Resolve(double weight, Units weightUnit, double speed, Units speedUnit)
        {
            var result = new List<string>();
            var lightSpeed = 299792458;
            var normalizedWeight = NormalizeWeight(weight, weightUnit);
            var normalizedSpeed = NormalizeSpeed(speed, speedUnit);

            await Task.Run(() =>
            {
                var secondStep = @"E_k = \frac{weight * c^2}{\sqrt{\frac{1 - speed^2}{c^2}}} - weight * c^2";
                var mathResult =
                    ((normalizedWeight * Math.Pow(lightSpeed, 2.0)) /
                    Math.Sqrt(1.0 - (Math.Pow(normalizedSpeed, 2.0)) / Math.Pow(lightSpeed, 2.0))) -
                    normalizedWeight * Math.Pow(lightSpeed, 2.0);

                var thirdStep = $"E_k = {mathResult} [J]";
                result.Add(secondStep);
                result.Add(thirdStep);
            });

            return result;
        }

        private double NormalizeSpeed(double speed, Units speedUnit)
        {
            const double changingValue = 3.6;
            switch (speedUnit)
            {
                case Units.KilometerPerHour:
                    return speed / changingValue;
                case Units.MeterForSecond:
                    return speed;
                default: throw new InvalidEnumArgumentException(Resources.Unknown_speed_unit);
            }
        }

        private double NormalizeWeight(double weight, Units weightUnit)
        {
            const double changingValue = 1000;
            switch (weightUnit)
            {
                case Units.Gram:
                    return weight / changingValue;
                case Units.Kilogram:
                    return weight;
                default: throw new InvalidEnumArgumentException(Resources.Unknown_weight_unit);
            }
        }
    }
}