// KineticEnergyEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MobileXamarin.Enums;
using MobileXamarin.EquotionResolvers;
using MobileXamarin.IViewModels;
using MobileXamarin.Repository;
using MobileXamarin.Views;
using Xamarin.Forms.Navigation;

namespace MobileXamarin.ViewModels
{
    public class KineticEnergyEquationViewModel : EquationViewModelBase, IKineticEnergyEquationViewModel
    {
        private readonly IKineticEquotionResolver resolver;
        private readonly IMessenger messenger;
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

        public KineticEnergyEquationViewModel(
            IKineticEquotionResolver resolver,
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

        protected override bool ResolveCanExecute()
        {
            if (!string.IsNullOrEmpty(SelectedWeightUnit) && !string.IsNullOrEmpty(SelectedSpeedUnit))
            {
                return true;
            }

            return false;
        }

        protected override async Task ResolveExecute()
        {
            var weightUnit = UnitRepository.GetUnitByString(SelectedWeightUnit);
            var speedUnit = UnitRepository.GetUnitByString(SelectedSpeedUnit);
            var result = await resolver.Resolve(Weight, weightUnit, Speed, speedUnit);
            var parameters = new NavigationParameters { { "Result", result } };
            messenger.Send(result);

            await NavigationService.NavigateTo(nameof(ResultView), parameters, true);
        }
    }
}