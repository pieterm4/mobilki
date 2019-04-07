using System.Linq;
using MobileXamarin.IViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileXamarin.Views
{
    /// <summary>
    /// Result view
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultView : ContentPage
    {
        /// <summary>
        /// View model for that view
        /// </summary>
        public IResultViewModel ViewModel { get; }
        /// <summary>
        /// Constructor for result view
        /// </summary>
        public ResultView()
        {
            InitializeComponent();
            ViewModel = BindingContext as IResultViewModel;

        }

        /// <summary>
        /// Handle when view is appearing
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            equationList.ScrollItemIntoView(ViewModel.Solution.Last());
        }


        /// <summary>
        /// Handle when back button pressed
        /// </summary>
        /// <returns>True if pressed</returns>
        protected override bool OnBackButtonPressed()
        {
            ViewModel.Dispose();

            BindingContext = null;
            return base.OnBackButtonPressed();
        }
    }
}