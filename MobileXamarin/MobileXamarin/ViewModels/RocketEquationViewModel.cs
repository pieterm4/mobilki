// RocketEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MobileXamarin.Enums;
using MobileXamarin.EquotionResolvers;
using MobileXamarin.IViewModels;
using MobileXamarin.Models;
using MobileXamarin.Repository;
using Xamarin.Forms.Navigation;

namespace MobileXamarin.ViewModels
{
    /// <summary>
    /// Rocket equation viewmodel
    /// </summary>
    public class RocketEquationViewModel : EquationViewModelBase, IRocketEquationViewModel
    {
        private readonly IRocketEquationResolver resolver;
        private readonly IMessenger messenger;
        private double massOfTheRocket;
        private double massOfTheFuel;
        private double flightTime;
        private double properImpulse;
        private string selectedMassOfTheRocketUnit;
        private string selectedMassOfTheFuelUnit;
        private string selectedFlightTimeUnit;
        private string selectedProperImpulseUnit;

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
        public string SelectedMassOfTheRocketUnit
        {
            get => selectedMassOfTheRocketUnit;
            set
            {
                if (selectedMassOfTheRocketUnit != value)
                {
                    selectedMassOfTheRocketUnit = value;
                    OnPropertyChanged(nameof(SelectedMassOfTheRocketUnit));
                }
            }
        }

        /// <inheritdoc />
        public string SelectedMassOfTheFuelUnit
        {
            get => selectedMassOfTheFuelUnit;
            set
            {
                if (selectedMassOfTheFuelUnit != value)
                {
                    selectedMassOfTheFuelUnit = value;
                    OnPropertyChanged(nameof(SelectedMassOfTheFuelUnit));
                }
            }
        }

        /// <inheritdoc />
        public string SelectedFlightTimeUnit
        {
            get => selectedFlightTimeUnit;
            set
            {
                if (selectedFlightTimeUnit != value)
                {
                    selectedFlightTimeUnit = value;
                    OnPropertyChanged(nameof(SelectedFlightTimeUnit));
                }
            }
        }

        /// <inheritdoc />
        public string SelectedProperImpulseUnit
        {
            get => selectedProperImpulseUnit;
            set
            {
                if (selectedProperImpulseUnit != value)
                {
                    selectedProperImpulseUnit = value;
                    OnPropertyChanged(nameof(SelectedProperImpulseUnit));
                }
            }
        }

        /// <inheritdoc />
        public ObservableCollection<string> MassOfTheRocketUnits { get; set; }

        /// <inheritdoc />
        public ObservableCollection<string> MassOfTheFuelUnits { get; set; }

        /// <inheritdoc />
        public ObservableCollection<string> FlightTimeUnits { get; set; }

        /// <inheritdoc />
        public ObservableCollection<string> ProperImpulseUnits { get; set; }

        /// <summary>
        /// Constructor for RocketEquationViewModel
        /// </summary>
        /// <param name="resolver"></param>
        /// <param name="navigationService"></param>
        /// <param name="messenger"></param>
        public RocketEquationViewModel(
            IRocketEquationResolver resolver,
            INavigationService navigationService,
            IMessenger messenger)
        {
            this.resolver = resolver;
            this.messenger = messenger;
            NavigationService = navigationService;

            Initialize();
        }

        private void Initialize()
        {
            var massOfTheRocketUnits = new List<string>
            {
                UnitRepository.GetStringByUnit(Units.Gram),
                UnitRepository.GetStringByUnit(Units.Kilogram)
            };

            var massOfTheFuelUnits = new List<string>
            {
                UnitRepository.GetStringByUnit(Units.Gram),
                UnitRepository.GetStringByUnit(Units.Kilogram)
            };

            var flightTimeUnits = new List<string>
            {
                UnitRepository.GetStringByUnit(Units.Second),
                UnitRepository.GetStringByUnit(Units.Hour)
            };

            var properImpulseUnits = new List<string>
            {
                UnitRepository.GetStringByUnit(Units.KilometerPerHour),
                UnitRepository.GetStringByUnit(Units.MeterForSecond)
            };

            MassOfTheRocketUnits = new ObservableCollection<string>(massOfTheRocketUnits);
            MassOfTheFuelUnits = new ObservableCollection<string>(massOfTheFuelUnits);
            FlightTimeUnits = new ObservableCollection<string>(flightTimeUnits);
            ProperImpulseUnits = new ObservableCollection<string>(properImpulseUnits);

            SelectedMassOfTheRocketUnit = UnitRepository.GetStringByUnit(Units.Kilogram);
            SelectedFlightTimeUnit = UnitRepository.GetStringByUnit(Units.Second);
            SelectedMassOfTheFuelUnit = UnitRepository.GetStringByUnit(Units.Kilogram);
            SelectedProperImpulseUnit = UnitRepository.GetStringByUnit(Units.MeterForSecond);
        }

        /// <inheritdoc />
        protected override bool ResolveCanExecute()
        {
            if (!string.IsNullOrEmpty(SelectedMassOfTheRocketUnit) &&
                !string.IsNullOrEmpty(SelectedMassOfTheFuelUnit) &&
                !string.IsNullOrEmpty(SelectedProperImpulseUnit) &&
                !string.IsNullOrEmpty(SelectedFlightTimeUnit))
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        protected override async Task ResolveExecute()
        {
            var massOfTheRocketUnit = UnitRepository.GetUnitByString(SelectedMassOfTheRocketUnit);
            var massOfTheFuelUnit = UnitRepository.GetUnitByString(SelectedMassOfTheFuelUnit);
            var properImpulseUnit = UnitRepository.GetUnitByString(SelectedProperImpulseUnit);
            var flightTimeUnit = UnitRepository.GetUnitByString(SelectedFlightTimeUnit);
            var rocketParameter = new RocketParameter(MassOfTheRocket, massOfTheRocketUnit, MassOfTheFuel,
                massOfTheFuelUnit, ProperImpulse, properImpulseUnit, FlightTime, flightTimeUnit);

            var result = await resolver.Resolve(rocketParameter);
        }
    }
}