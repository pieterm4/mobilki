using System;
using System.Collections.Specialized;
using System.Linq;
using MobileXamarin.IViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Point = MobileXamarin.Models.Point;

namespace MobileXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LagrangeEquotionView : ContentPage
    {
        /// <summary>
        /// View Model which is context for that view
        /// </summary>
        public ILagrangeEquationViewModel ViewModel => BindingContext as ILagrangeEquationViewModel;

        /// <summary>
        /// Lagrange Equation View Constructor
        /// </summary>
        public LagrangeEquotionView()
        {
            InitializeComponent();
        }

        private void RemoveItem(object sender, EventArgs e)
        {
            var item = (sender as BindableObject)?.BindingContext as Point;
            ViewModel.ControlPoints.Remove(item);
        }
    }
}