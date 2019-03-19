using MobileXamarin.IViewModels;
using MobileXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultView : ContentPage
    {
        public IResultViewModel ViewModel { get; }
        public ResultView()
        {
            InitializeComponent();
            ViewModel = BindingContext as IResultViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            ViewModel.Dispose();

            BindingContext = null;
            return base.OnBackButtonPressed();
        }
    }
}