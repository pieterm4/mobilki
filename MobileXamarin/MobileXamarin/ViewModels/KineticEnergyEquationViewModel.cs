// KineticEnergyEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MobileXamarin.Enums;
using MobileXamarin.EquationResolvers;
using MobileXamarin.IViewModels;
using MobileXamarin.Repository;
using MobileXamarin.Views;
using Xamarin.Forms.Navigation;

namespace MobileXamarin.ViewModels
{
    /// <summary>
    /// Kinetic Energy Equation ViewModel
    /// </summary>
    public class KineticEnergyEquationViewModel : EquationViewModelBase, IKineticEnergyEquationViewModel
    {
        private readonly IKineticEquationResolver resolver;
        private readonly IMessenger messenger;
        private double weight;
        private double speed;
        private string selectedWeightUnit;
        private string selectedSpeedUnit;

        /// <summary>
        /// Gets or sets weight of the object
        /// </summary>
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

        /// <summary>
        /// Gets or sets speed of the object
        /// </summary>
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

        /// <summary>
        /// Gets or sets all units for the weight
        /// </summary>
        public ObservableCollection<string> WeightUnits { get; set; }

        /// <summary>
        /// Gets or sets all units for the speed
        /// </summary>
        public ObservableCollection<string> SpeedUnits { get; set; }

        /// <summary>
        /// Gets or sets unit for the weight of the object
        /// </summary>
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

        /// <summary>
        /// Gets or sets unit for the speed of the object
        /// </summary>
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

        /// <summary>
        /// Constructor for KineticEnergyEquationViewModel
        /// </summary>
        /// <param name="resolver">Resolver for kinetic energy equation <see cref="IKineticEquationResolver"/></param>
        /// <param name="navigationService">Navigation service <see cref="INavigationService"/></param>
        /// <param name="messenger">Messenger <see cref="IMessenger"/></param>
        public KineticEnergyEquationViewModel(
            IKineticEquationResolver resolver,
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

        /// <summary>
        /// Determines if can execute Resolve command
        /// </summary>
        /// <returns>True when can execute Resolve command, False if not</returns>
        protected override bool ResolveCanExecute()
        {
            if (!string.IsNullOrEmpty(SelectedWeightUnit) && !string.IsNullOrEmpty(SelectedSpeedUnit))
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
            var weightUnit = UnitRepository.GetUnitByString(SelectedWeightUnit);
            var speedUnit = UnitRepository.GetUnitByString(SelectedSpeedUnit);
            var result = await resolver.Resolve(Weight, weightUnit, Speed, speedUnit);
            var parameters = new NavigationParameters { { "Result", result } };
            messenger.Send(result);
            await Task.Delay(2000);
            IsBusy = false;

            await NavigationService.NavigateTo(nameof(ResultView), parameters, true);
        }
    }
}