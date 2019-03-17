// UnitRepository.cs
// All rights reserved
// Piotr Makowiec 17-03-2019

using System.Collections.Generic;
using System.Linq;
using MobileXamarin.Enums;

namespace MobileXamarin.Repository
{
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

        public static string GetStringByUnit(Units unit)
        {
            Initialize();
            var canGetValue = unitRepresentation.TryGetValue(unit, out var representation);

            return canGetValue ? representation : string.Empty;
        }

        public static Units GetUnitByString(string unitString)
        {
            Initialize();
            var unit = unitRepresentation.FirstOrDefault(x => x.Value == unitString).Key;

            return unit;
        }
    }
}