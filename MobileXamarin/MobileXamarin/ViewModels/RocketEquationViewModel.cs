// RocketEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System;
using System.Threading.Tasks;
using MobileXamarin.IViewModels;

namespace MobileXamarin.ViewModels
{
    /// <summary>
    /// Rocket equation viewmodel
    /// </summary>
    public class RocketEquationViewModel : EquationViewModelBase, IRocketEquationViewModel
    {
        private double massOfTheRocket;
        private double massOfTheFuel;
        private double flightTime;
        private double properImpulse;

        /// <inheritdoc />
        public double MassOfTheRocket
        {
            get => massOfTheRocket;
            set
            {
                if (Math.Abs(massOfTheRocket - value) > double.Epsilon)
                {
                    massOfTheRocket = value;
                    OnPropertyChanged(nameof(MassOfTheRocket));
                }
            }
        }

        /// <inheritdoc />
        public double MassOfTheFuel
        {
            get => massOfTheFuel;
            set
            {
                if (Math.Abs(massOfTheFuel - value) > double.Epsilon)
                {
                    massOfTheFuel = value;
                    OnPropertyChanged(nameof(MassOfTheFuel));
                }
            }
        }

        /// <inheritdoc />
        public double FlightTime
        {
            get => flightTime;
            set
            {
                if (Math.Abs(flightTime - value) > double.Epsilon)
                {
                    flightTime = value;
                    OnPropertyChanged(nameof(FlightTime));
                }
            }
        }

        /// <inheritdoc />
        public double ProperImpulse
        {
            get => properImpulse;
            set
            {
                if (Math.Abs(properImpulse - value) > double.Epsilon)
                {
                    properImpulse = value;
                    OnPropertyChanged(nameof(ProperImpulse));
                }
            }
        }

        /// <inheritdoc />
        protected override bool ResolveCanExecute()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        protected override async Task ResolveExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}