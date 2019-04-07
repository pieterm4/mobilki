using System;
using MobileXamarin.IViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Point = MobileXamarin.Models.Point;

namespace MobileXamarin.Views
{
    /// <summary>
    /// Lagrange view
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LagrangeEquationView : ContentPage
    {
        /// <summary>
        /// View Model which is context for that view
        /// </summary>
        public ILagrangeEquationViewModel ViewModel => BindingContext as ILagrangeEquationViewModel;

        /// <summary>
        /// Lagrange Equation View Constructor
        /// </summary>
        public LagrangeEquationView()
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