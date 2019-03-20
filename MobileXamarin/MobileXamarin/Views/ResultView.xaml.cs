using System.Collections.Specialized;
using System.Linq;
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
            //if (ViewModel != null)
            //{
            //    ViewModel.Result.CollectionChanged += OnCollectionChanged;
            //    Math.LaTeX = string.Join(@"\\", ViewModel.Result);
            //}
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Math.LaTeX = string.Empty;
            //var newItems = e.NewItems;
            //Math.LaTeX = string.Join(@"\\", newItems);
        }

        protected override bool OnBackButtonPressed()
        {
            ViewModel.Dispose();

            BindingContext = null;
            return base.OnBackButtonPressed();
        }
    }
}