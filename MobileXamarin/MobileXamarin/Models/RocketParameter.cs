// RocketParameter.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using MobileXamarin.Enums;

namespace MobileXamarin.Models
{
    /// <summary>
    /// Parameters of the rocket
    /// </summary>
    public class RocketParameter
    {
        /// <summary>
        /// Gets Mass of the rocket
        /// </summary>
        public double MassOfTheRocket { get; }

        /// <summary>
        /// Gets Mass of the rocket unit
        /// </summary>
        public Units MassOfTheRocketUnit { get; }

        /// <summary>
        /// Gets mass of the fuel
        /// </summary>
        public double MassOfTheFuel { get; }

        /// <summary>
        /// Gets mass of the fuel unit
        /// </summary>
        public Units MassOfTheFuelUnit { get; }

        /// <summary>
        /// Gets proper impulse
        /// </summary>
        public double ProperImpulse { get; }

        /// <summary>
        /// Gets proper impulse unit
        /// </summary>
        public Units ProperImpulseUnit { get; }

        /// <summary>
        /// Gets flight time
        /// </summary>
        public double FlightTime { get; }

        /// <summary>
        /// Gets flight time unit
        /// </summary>
        public Units FlightTimeUnit { get; }

        /// <summary>
        /// Parameters of the rocket
        /// </summary>
        /// <param name="massOfTheRocket">Mass of the rocket</param>
        /// <param name="massOfTheRocketUnit">Mass rocket unit</param>
        /// <param name="massOfTheFuel">Mass of the fuel</param>
        /// <param name="massOfTheFuelUnit">Mass of the fuel unit</param>
        /// <param name="properImpulse">Proper impulse</param>
        /// <param name="properImpulseUnit">Proper impulse unit</param>
        /// <param name="flightTime">Flight time</param>
        /// <param name="flightTimeUnit">Flight time unit</param>
        public RocketParameter(double massOfTheRocket, Units massOfTheRocketUnit, double massOfTheFuel, Units massOfTheFuelUnit, double properImpulse, Units properImpulseUnit, double flightTime, Units flightTimeUnit)
        {
            MassOfTheRocket = massOfTheRocket;
            MassOfTheRocketUnit = massOfTheRocketUnit;
            MassOfTheFuel = massOfTheFuel;
            MassOfTheFuelUnit = massOfTheFuelUnit;
            ProperImpulse = properImpulse;
            ProperImpulseUnit = properImpulseUnit;
            FlightTime = flightTime;
            FlightTimeUnit = flightTimeUnit;
        }
    }
}