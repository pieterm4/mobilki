using System.Reflection;
using System.Globalization;
using Xamarin.Forms;
using MobileXamarin.Views;
using Xamarin.Forms.ToolKit.Extensions;

namespace MobileXamarin
{
    /// <summary>
    /// Core class for Xamarin app
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Constructor for App
        /// </summary>
        public App()
        {
            InitializeComponent();

            #region Init ImageResourceExtension
            ImageResourceExtension.InitImageResourceExtension("AppResources.Assets", typeof(App).GetTypeInfo().Assembly);
            #endregion

            #region Init TranslateExtension            
            TranslateExtension.InitTranslateExtension("AppResources.Localization.Resources", CultureInfo.CurrentCulture, typeof(App).GetTypeInfo().Assembly);
            #endregion

            NavigationPage navigationPage = new NavigationPage(new HomeView());
            navigationPage.BarBackgroundColor = Color.FromHex("#7E1335");
            navigationPage.BarTextColor = Color.White;
            MainPage = navigationPage;
        }

        /// <summary>
        /// Handle when your app starts
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Handle when your app sleeps
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Handle when your app resumes
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
