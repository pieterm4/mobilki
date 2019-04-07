// RocketEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MobileXamarin.Enums;
using MobileXamarin.EquationResolvers;
using MobileXamarin.IViewModels;
using MobileXamarin.Models;
using MobileXamarin.Repository;
using MobileXamarin.Views;
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
        private string selectedAmountOfThrownFuelUnit;
        private double amountOfThrownFuel;

        /// <summary>
        /// Gets or sets mass of the rocket
        /// </summary>
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

        /// <summary>
        /// Gets or sets mass of the fuel in the rocket
        /// </summary>
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

        /// <summary>
        /// Gets or sets for how long of the rocket's trip the result is calculating
        /// </summary>
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

        /// <summary>
        /// Gets or sets value of how much fuel is throwing out from the rocket
        /// </summary>
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

        /// <summary>
        /// Amount of thrown fuel away for period of time eg kg/s
        /// </summary>
        public double AmountOfThrownFuel
        {
            get => amountOfThrownFuel;
            set
            {
                if (Math.Abs(amountOfThrownFuel - value) > double.Epsilon)
                {
                    amountOfThrownFuel = value;
                    OnPropertyChanged(nameof(AmountOfThrownFuel));
                }
            }
        }

        /// <summary>
        /// Selected unit for mass of the rocket
        /// </summary>
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

        /// <summary>
        /// Selected unit for mass of the fuel
        /// </summary>
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

        /// <summary>
        /// Selected unit for the flight time
        /// </summary>
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

        /// <summary>
        /// Selected unit for the proper impulse
        /// </summary>
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

        /// <summary>
        /// Unit for thrown fuel away eg. kg/s
        /// </summary>
        public string SelectedAmountOfThrownFuelUnit
        {
            get => selectedAmountOfThrownFuelUnit;
            set
            {
                if (selectedAmountOfThrownFuelUnit != value)
                {
                    selectedAmountOfThrownFuelUnit = value;
                    OnPropertyChanged(nameof(SelectedAmountOfThrownFuelUnit));
                }
            }
        }

        /// <summary>
        /// Gets or sets units for mass of the rocket
        /// </summary>
        public ObservableCollection<string> MassOfTheRocketUnits { get; set; }

        /// <summary>
        /// Gets or sets units for mass of the fuel
        /// </summary>
        public ObservableCollection<string> MassOfTheFuelUnits { get; set; }

        /// <summary>
        /// Gets or sets units for the flight time
        /// </summary>
        public ObservableCollection<string> FlightTimeUnits { get; set; }

        /// <summary>
        /// Gets or sets units for the proper impulse
        /// </summary>
        public ObservableCollection<string> ProperImpulseUnits { get; set; }

        /// <summary>
        /// Gets or sets units for amount of thrown fuel
        /// </summary>
        public ObservableCollection<string> AmountOfThrownFuelUnits { get; set; }



        /// <summary>
        /// Constructor for RocketEquationViewModel
        /// </summary>
        /// <param name="resolver">Equation resolver for rocket</param>
        /// <param name="navigationService">Navigation service</param>
        /// <param name="messenger">Messenger</param>
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
                UnitRepository.GetStringByUnit(Units.Kilogram)
            };

            var massOfTheFuelUnits = new List<string>
            {
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

            var amountOfThrownFuelUnits = new List<string>
            {
                UnitRepository.GetStringByUnit(Units.KilogramPerSecond)
            };

            MassOfTheRocketUnits = new ObservableCollection<string>(massOfTheRocketUnits);
            MassOfTheFuelUnits = new ObservableCollection<string>(massOfTheFuelUnits);
            FlightTimeUnits = new ObservableCollection<string>(flightTimeUnits);
            ProperImpulseUnits = new ObservableCollection<string>(properImpulseUnits);
            AmountOfThrownFuelUnits = new ObservableCollection<string>(amountOfThrownFuelUnits);

            SelectedMassOfTheRocketUnit = UnitRepository.GetStringByUnit(Units.Kilogram);
            SelectedFlightTimeUnit = UnitRepository.GetStringByUnit(Units.Second);
            SelectedMassOfTheFuelUnit = UnitRepository.GetStringByUnit(Units.Kilogram);
            SelectedProperImpulseUnit = UnitRepository.GetStringByUnit(Units.MeterForSecond);
            SelectedAmountOfThrownFuelUnit = UnitRepository.GetStringByUnit(Units.KilogramPerSecond);
        }

        /// <summary>
        /// Determines if can execute Resolve command
        /// </summary>
        /// <returns>True when can execute Resolve command, False if not</returns>
        protected override bool ResolveCanExecute()
        {
            if (!string.IsNullOrEmpty(SelectedMassOfTheRocketUnit) &&
                !string.IsNullOrEmpty(SelectedMassOfTheFuelUnit) &&
                !string.IsNullOrEmpty(SelectedProperImpulseUnit) &&
                !string.IsNullOrEmpty(SelectedFlightTimeUnit) &&
                !string.IsNullOrEmpty(SelectedAmountOfThrownFuelUnit))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Executes Resolve command
        /// </summary>
        /// <returns>Task which execute command</returns>
        protected override async Task ResolveExecute()
        {
            IsBusy = true;
            
            var massOfTheRocketUnit = UnitRepository.GetUnitByString(SelectedMassOfTheRocketUnit);
            var massOfTheFuelUnit = UnitRepository.GetUnitByString(SelectedMassOfTheFuelUnit);
            var properImpulseUnit = UnitRepository.GetUnitByString(SelectedProperImpulseUnit);
            var flightTimeUnit = UnitRepository.GetUnitByString(SelectedFlightTimeUnit);
            var amountOfThrownFuelUnit = UnitRepository.GetUnitByString(SelectedAmountOfThrownFuelUnit);
            var rocketParameter = new RocketParameter(MassOfTheRocket, massOfTheRocketUnit, MassOfTheFuel,
                massOfTheFuelUnit, ProperImpulse, properImpulseUnit, FlightTime, flightTimeUnit, AmountOfThrownFuel, amountOfThrownFuelUnit);

            var result = await resolver.Resolve(rocketParameter);

            var parameters = new NavigationParameters
            {
                {"Result", result}
            };

            messenger.Send(result);
            await Task.Delay(2000);
            IsBusy = false;
            await NavigationService.NavigateTo(nameof(ResultView), parameters, true);  
        }
    }
}