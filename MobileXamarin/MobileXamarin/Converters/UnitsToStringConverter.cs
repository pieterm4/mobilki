// UnitsToStringConverter.cs
// All rights reserved
// Piotr Makowiec 17-03-2019

using System;
using System.Collections.Generic;
using System.Globalization;
using MobileXamarin.Enums;
using MobileXamarin.Repository;
using Xamarin.Forms;

namespace MobileXamarin.Converters
{
    public class UnitsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<Units> units)
            {
                var listOfUnits = new List<string>();
                foreach (var unit in units)
                {
                    var unitString = UnitRepository.GetStringByUnit(unit);

                    listOfUnits.Add(unitString);
                }

                return listOfUnits;
            }

            var unitValue = value is Units unitV ? unitV : Units.Unknown;
            var unitStr = UnitRepository.GetStringByUnit(unitValue);

            return unitStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<string> strings)
            {
                var listOfUnits = new List<Units>();
                foreach (var s in strings)
                {
                    if (string.IsNullOrEmpty(s))
                    {
                        listOfUnits.Add(Units.Unknown);
                    }

                    listOfUnits.Add(UnitRepository.GetUnitByString(s));
                }

                return listOfUnits;
            }

            var stringRepresentation = (string) value;

            if (string.IsNullOrEmpty(stringRepresentation))
            {
                return Units.Unknown;
            }

            return UnitRepository.GetUnitByString(stringRepresentation);
        }
    }
}