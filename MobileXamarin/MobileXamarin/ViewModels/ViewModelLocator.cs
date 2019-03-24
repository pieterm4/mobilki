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
    /// <summary>
    /// IoC container
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Constructor for ViewModelLocator
        /// </summary>
        [Preserve]
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IEquationRepository, EquationRepository>();
            SimpleIoc.Default.Register<IKineticEquotionResolver, KineticKineticEquotionResolver>();
            SimpleIoc.Default.Register<ILagrangeResolver, LagrangeResolver>();
            SimpleIoc.Default.Register<IRocketEquationResolver, RocketEquationResolver>();

            SimpleIoc.Default.Register<IHomeViewModel, HomeViewModel>();
            SimpleIoc.Default.Register<IKineticEnergyEquationViewModel, KineticEnergyEquationViewModel>();
            SimpleIoc.Default.Register<IResultViewModel, ResultViewModel>();
            SimpleIoc.Default.Register<ILagrangeEquationViewModel, LagrangeEquationViewModel>();
            SimpleIoc.Default.Register<IRocketEquationViewModel, RocketEquationViewModel>();

            SimpleIoc.Default.Register<IPopupsService, PopupsService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IMessenger, Messenger>();
        }

        /// <summary>
        /// Gets an instance for <see cref="IHomeViewModel"/> <see cref="HomeViewModel"/>
        /// </summary>
        public IHomeViewModel Home => ServiceLocator.Current.GetInstance<IHomeViewModel>();

        /// <summary>
        /// Gets an instance for <see cref="IKineticEnergyEquationViewModel"/> <see cref="KineticEnergyEquationViewModel"/>
        /// </summary>
        public IKineticEnergyEquationViewModel Kinetic =>
            ServiceLocator.Current.GetInstance<IKineticEnergyEquationViewModel>();

        /// <summary>
        /// Gets an instance for <see cref="IResultViewModel"/> <see cref="ResultViewModel"/>
        /// </summary>
        public IResultViewModel Result => ServiceLocator.Current.GetInstance<IResultViewModel>();

        /// <summary>
        /// Gets an instance for <see cref="ILagrangeEquationViewModel"/> <see cref="LagrangeEquationViewModel"/>
        /// </summary>
        public ILagrangeEquationViewModel Lagrange => ServiceLocator.Current.GetInstance<ILagrangeEquationViewModel>();

        /// <summary>
        /// Gets an instance for <see cref="IRocketEquationViewModel"/> <see cref="RocketEquationViewModel"/>
        /// </summary>
        public IRocketEquationViewModel Rocket => ServiceLocator.Current.GetInstance<IRocketEquationViewModel>();
    }
}
