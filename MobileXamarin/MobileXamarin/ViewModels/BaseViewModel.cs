using Xamarin.Forms.Popups;
using System.ComponentModel;
using Xamarin.Forms.Navigation;
using System.Runtime.CompilerServices;

namespace MobileXamarin.ViewModels
{
    /// <summary>
    /// Base class for view models
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Popup service for displaying popups
        /// </summary>
        protected IPopupsService PopupService;

        /// <summary>
        /// Navigation service for navigation through pages
        /// </summary>
        protected INavigationService NavigationService;

        #region INotifyPropertyChanged Implementation
        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// OnPropertyChanged - raises PropertyChanged event
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
