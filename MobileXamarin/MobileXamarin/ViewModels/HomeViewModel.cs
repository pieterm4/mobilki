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
    public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        private IEquation selectedEquation;

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

        public IEnumerable<IEquation> Equations { get; }

        public RelayCommand NextPageCommand { get; }

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
                    await NavigationService.NavigateTo(nameof(KineticEnergyEquationView));
                    break;
            }
            
        }
    }
}
