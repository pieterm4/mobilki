using MobileXamarin.IViewModels;
using Xamarin.Forms.Popups;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MobileXamarin.Repository;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Navigation;

namespace MobileXamarin.ViewModels
{
    public class ViewModelLocator
    {
        [Preserve]
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IEquotionRepository, EquotionRepository>();

            SimpleIoc.Default.Register<IHomeViewModel, HomeViewModel>();
            SimpleIoc.Default.Register<IDetailsViewModel, DetailsViewModel>();

            SimpleIoc.Default.Register<IPopupsService, PopupsService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
        }

        public IHomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IHomeViewModel>();
            }
        }

        public IDetailsViewModel Details
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDetailsViewModel>();
            }
        }
    }
}
