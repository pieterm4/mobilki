using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MobileXamarin.IModels;
using MobileXamarin.IViewModels;
using MobileXamarin.Models;
using MobileXamarin.Repository;
using Xamarin.Forms;
using INavigationService = Xamarin.Forms.Navigation.INavigationService;

namespace MobileXamarin.ViewModels
{
    public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        private readonly IEquotionRepository equotionRepository;
        private readonly IEnumerable<IEquotion> equotions;
        private IEquotion selectedEquotion;

        public string WelcomeText => "Welcome in Xamarin Bitch!";

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

        private RelayCommand NextPageCommand { get; }

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

        private void GoToNextPage()
        {
            throw new System.NotImplementedException();
        }
    }
}
