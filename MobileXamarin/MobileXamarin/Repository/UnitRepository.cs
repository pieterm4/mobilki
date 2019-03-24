// UnitRepository.cs
// All rights reserved
// Piotr Makowiec 17-03-2019

using System.Collections.Generic;
using System.Linq;
using MobileXamarin.Enums;

namespace MobileXamarin.Repository
{
    /// <summary>
    /// Repository for units
    /// </summary>
    public static class UnitRepository
    {
        private static IDictionary<Units, string> unitRepresentation;

        private static void Initialize()
        {
            unitRepresentation = new Dictionary<Units, string>
            {
                {Units.Hour, "h" },
                {Units.Gram, "g" },
                {Units.Kilogram, "Kg" },
                {Units.Kilometer, "Km" },
                {Units.Meter, "m" },
                {Units.KilometerPerHour, "Km/h" },
                {Units.MeterForSecond, "m/s" },
                {Units.Second, "s" }
            };
        }

        /// <summary>
        /// Get string unit representation based on its enum value
        /// </summary>
        /// <param name="unit">Enum for unit</param>
        /// <returns>String representation for unit, if doesn't exist - returns empty string</returns>
        public static string GetStringByUnit(Units unit)
        {
            Initialize();
            var canGetValue = unitRepresentation.TryGetValue(unit, out var representation);

            return canGetValue ? representation : string.Empty;
        }

        /// <summary>
        /// Get enum unit based on the string representation
        /// </summary>
        /// <param name="unitString">String representation of the unit</param>
        /// <returns>Enum representation of the unit</returns>
        public static Units GetUnitByString(string unitString)
        {
            Initialize();
            var unit = unitRepresentation.FirstOrDefault(x => x.Value == unitString).Key;

            return unit;
        }
    }
}