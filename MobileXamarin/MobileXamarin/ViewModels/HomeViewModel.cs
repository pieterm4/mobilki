using System.Collections.Generic;
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
        private readonly IEquotionRepository equotionRepository;
        private readonly IEnumerable<IEquotion> equotions;
        private IEquotion selectedEquotion;

        public IEquotion SelectedEquotion
        {
            get => selectedEquotion;
            set
            {
                if (selectedEquotion != value)
                {
                    selectedEquotion = value;
                    OnPropertyChanged(nameof(SelectedEquotion));
                    NextPageCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public IEnumerable<IEquotion> Equotions => equotions;

        public RelayCommand NextPageCommand { get; }

        public HomeViewModel(IEquotionRepository equotionRepository, INavigationService navigationService)
        {
            this.equotionRepository = equotionRepository;
            equotions = equotionRepository.GetEquotions();
            NavigationService = navigationService;
            NextPageCommand = new RelayCommand(GoToNextPage, CanGoToNextPage);
        }

        private bool CanGoToNextPage()
        {
            return SelectedEquotion != null;
        }

        private async void GoToNextPage()
        {
            switch (SelectedEquotion.EquotionType)
            {
                case EquotionType.Kinetic:
                    await NavigationService.NavigateTo(nameof(KineticEnergyEquotionView));
                    break;
            }
            
        }
    }
}
