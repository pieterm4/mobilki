using Xamarin.Forms.Popups;
using System.ComponentModel;
using Xamarin.Forms.Navigation;
using System.Runtime.CompilerServices;

namespace MobileXamarin.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IPopupsService PopupService;
        protected INavigationService NavigationService;

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
