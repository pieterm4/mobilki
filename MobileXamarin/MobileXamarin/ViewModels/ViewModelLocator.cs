using MobileXamarin.IViewModels;
using Xamarin.Forms.Popups;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MobileXamarin.EquotionResolvers;
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

            SimpleIoc.Default.Register<IEquationRepository, EquationRepository>();
            SimpleIoc.Default.Register<IKineticEquotionResolver, KineticKineticEquotionResolver>();

            SimpleIoc.Default.Register<IHomeViewModel, HomeViewModel>();
            SimpleIoc.Default.Register<IDetailsViewModel, DetailsViewModel>();
            SimpleIoc.Default.Register<IKineticEnergyEquationViewModel, KineticEnergyEquationViewModel>();
            SimpleIoc.Default.Register<IResultViewModel, ResultViewModel>();

            SimpleIoc.Default.Register<IPopupsService, PopupsService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IMessenger, Messenger>();
        }

        public IHomeViewModel Home => ServiceLocator.Current.GetInstance<IHomeViewModel>();

        public IDetailsViewModel Details => ServiceLocator.Current.GetInstance<IDetailsViewModel>();

        public IKineticEnergyEquationViewModel Kinetic =>
            ServiceLocator.Current.GetInstance<IKineticEnergyEquationViewModel>();

        public IResultViewModel Result => ServiceLocator.Current.GetInstance<IResultViewModel>();
    }
}
