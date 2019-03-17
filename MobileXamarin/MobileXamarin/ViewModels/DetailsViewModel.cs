using MobileXamarin.Models;
using Xamarin.Forms;
using MobileXamarin.IViewModels;
using System.Windows.Input;
using Xamarin.Forms.Popups;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Navigation;

namespace MobileXamarin.ViewModels
{
    public class DetailsViewModel : BaseViewModel, IDetailsViewModel
    {
        private SampleModel _mySampleModel;
        public SampleModel MySampleModel
        {
            get { return _mySampleModel; }
            set
            {
                _mySampleModel = value;
                OnPropertyChanged(nameof(MySampleModel));
            }
        }

        public ICommand SelectedItemCommand { get; set; }

        [Preserve]
        public DetailsViewModel(IPopupsService popupService,
            INavigationService navigationService)
        {
            this.PopupService = popupService;
            this.NavigationService = navigationService;
            SelectedItemCommand = new Command<string>(SelectedItem);

            MySampleModel = navigationService.GetParameters().GetValue<SampleModel>(nameof(SampleModel));
        }

        private async void SelectedItem(string param)
        {
            await PopupService.DisplayAlert("SelectedItem", param, "Ok");
        }
    }
}
