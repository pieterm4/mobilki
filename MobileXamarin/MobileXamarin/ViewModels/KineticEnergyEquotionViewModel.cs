// KineticEnergyEquotionViewModel.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using System;
using MobileXamarin.Enums;
using MobileXamarin.IViewModels;

namespace MobileXamarin.ViewModels
{
    public class KineticEnergyEquotionViewModel : EquotionViewModelBase, IKineticEnergyEquotionViewModel
    {
        private double weight;
        private double speed;
        private Units weightUnits;
        private Units speedUnits;

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

        public Units WeightUnits
        {
            get => weightUnits;
            set
            {
                if (weightUnits != value)
                {
                    weightUnits = value;
                    OnPropertyChanged(nameof(WeightUnits));
                }
            }
        }

        public Units SpeedUnits
        {
            get => speedUnits;
            set
            {
                if (speedUnits != value)
                {
                    speedUnits = value;
                    OnPropertyChanged(nameof(SpeedUnits));
                }
            }
        }

        public KineticEnergyEquotionViewModel()
        {
            
        }
    }
}