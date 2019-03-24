using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MobileXamarin.Enums;
using MobileXamarin.IModels;
using MobileXamarin.IViewModels;
using MobileXamarin.Repository;
using MobileXamarin.Views;
using INavigationService = Xamarin.Forms.Navigation.INavigationService;

namespace MobileXamarin.ViewModels
{
    /// <summary>
    /// Home view model <see cref="IHomeViewModel"/>
    /// </summary>
    public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        private IEquation selectedEquation;

        /// <summary>
        /// Selected equation from the list
        /// </summary>
        public IEquation SelectedEquation
        {
            get => selectedEquation;
            set
            {
                if (selectedEquation != value)
                {
                    selectedEquation = value;
                    OnPropertyChanged(nameof(SelectedEquation));
                    NextPageCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc />
        public IEnumerable<IEquation> Equations { get; }

        /// <summary>
        /// Command for navigating to the next page when equation has been selected
        /// </summary>
        public RelayCommand NextPageCommand { get; }

        /// <summary>
        /// Constructor for HomeViewModel
        /// </summary>
        /// <param name="equationRepository">Equation repository <see cref="IEquationRepository"/></param>
        /// <param name="navigationService">Navigation service <see cref="INavigationService"/></param>
        public HomeViewModel(IEquationRepository equationRepository, INavigationService navigationService)
        {
            Equations = equationRepository.GetEquations();
            NavigationService = navigationService;
            NextPageCommand = new RelayCommand(async () => await GoToNextPage(), CanGoToNextPage);
        }

        private bool CanGoToNextPage()
        {
            return SelectedEquation != null;
        }

        private async Task GoToNextPage()
        {
            switch (SelectedEquation.EquationType)
            {
                case EquationType.Kinetic:
                    await NavigationService.NavigateTo(nameof(KineticEnergyEquationView), animated:true);
                    break;
                case EquationType.Lagrange:
                    await NavigationService.NavigateTo(nameof(LagrangeEquotionView), animated: true);
                    break;
                case EquationType.Rocket:
                    await NavigationService.NavigateTo(nameof(RocketEquationView), animated: true);
                    break;
            }
            
        }
    }
}
