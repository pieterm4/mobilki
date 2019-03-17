using System.Reflection;
using System.Globalization;
using Xamarin.Forms;
using MobileXamarin.Views;
using Xamarin.Forms.ToolKit.Extensions;

namespace MobileXamarin
{
    public partial class App : Application
    {
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

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
