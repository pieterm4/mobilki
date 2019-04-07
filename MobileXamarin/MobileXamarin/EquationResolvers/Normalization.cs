// Normalization.cs
// All rights reserved
// Piotr Makowiec 25-03-2019

using System.ComponentModel;
using MobileXamarin.AppResources.Localization;
using MobileXamarin.Enums;

namespace MobileXamarin.EquationResolvers
{
    /// <summary>
    /// Normalization class
    /// </summary>
    public static class Normalization
    {
        /// <summary>
        /// Normalizes speed to meter per second
        /// </summary>
        /// <param name="speed">Speed value</param>
        /// <param name="speedUnit">Speed unit</param>
        /// <returns>Speed in meter for second unit</returns>
        /// <exception cref="InvalidEnumArgumentException">Exception when cannot find unit</exception>
        public static double NormalizeSpeed(double speed, Units speedUnit)
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

        /// <summary>
        /// Normalizes weight to kilograms
        /// </summary>
        /// <param name="weight">Weight value</param>
        /// <param name="weightUnit">Weight unit</param>
        /// <returns>Weight in kilograms</returns>
        /// <exception cref="InvalidEnumArgumentException">Exception when cannot find unit</exception>
        public static double NormalizeWeight(double weight, Units weightUnit)
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

        /// <summary>
        /// Normalizes time to seconds
        /// </summary>
        /// <param name="time">Time value</param>
        /// <param name="timeUnit">Time unit</param>
        /// <returns>Time in seconds</returns>
        /// <exception cref="InvalidEnumArgumentException">Exception when cannot find unit</exception>
        public static double NormalizeTime(double time, Units timeUnit)
        {
            const double changingValue = 3600;
            switch (timeUnit)
            {
                case Units.Hour:
                    return time * changingValue;
                case Units.Second:
                    return time;
                default: throw new InvalidEnumArgumentException(Resources.Unknown_time_unit);
            }
        }
    }
}