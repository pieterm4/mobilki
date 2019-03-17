// KineticEnergyEquotionViewModel.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MobileXamarin.Enums;
using MobileXamarin.IViewModels;
using MobileXamarin.Repository;

namespace MobileXamarin.ViewModels
{
    public class KineticEnergyEquotionViewModel : EquotionViewModelBase, IKineticEnergyEquotionViewModel
    {
        private double weight;
        private double speed;
        private string selectedWeightUnit;
        private string selectedSpeedUnit;

        public double Weight
        {
            get => weight;
            set
            {
                if (Math.Abs(weight - value) > double.Epsilon)
                {
                    weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        public double Speed
        {
            get => speed;
            set
            {
                if (Math.Abs(speed - value) > double.Epsilon)
                {
                    speed = value;
                    OnPropertyChanged(nameof(Speed));
                }
            }
        }

        public ObservableCollection<string> WeightUnits { get; set; }

        public ObservableCollection<string> SpeedUnits { get; set; }

        public string SelectedWeightUnit
        {
            get => selectedWeightUnit;
            set
            {
                if (selectedWeightUnit != value)
                {
                    selectedWeightUnit = value;
                    OnPropertyChanged(nameof(SelectedWeightUnit));
                }
            }
        }

        public string SelectedSpeedUnit
        {
            get => selectedSpeedUnit;
            set
            {
                if (selectedSpeedUnit != value)
                {
                    selectedSpeedUnit = value;
                    OnPropertyChanged(nameof(SelectedSpeedUnit));
                }
            }
        }

        public KineticEnergyEquotionViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            var weightUnits = new List<string>
            {
                UnitRepository.GetStringByUnit(Units.Gram),
                UnitRepository.GetStringByUnit(Units.Kilogram)
            };

            var speedUnits = new List<string>
            {
                UnitRepository.GetStringByUnit(Units.KilometerPerHour),
                UnitRepository.GetStringByUnit(Units.MeterForSecond)
            };

            WeightUnits = new ObservableCollection<string>(weightUnits);
            SpeedUnits = new ObservableCollection<string>(speedUnits);

            SelectedSpeedUnit = UnitRepository.GetStringByUnit(Units.KilometerPerHour);
            SelectedWeightUnit = UnitRepository.GetStringByUnit(Units.Kilogram);
        }
    }
}