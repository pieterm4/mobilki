// ILagrangeEquotionViewModel.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System.Collections.ObjectModel;
using System.Drawing;
using GalaSoft.MvvmLight.Command;

namespace MobileXamarin.IViewModels
{
    /// <summary>
    /// Lagrange interpolation equation viewmodel
    /// </summary>
    public interface ILagrangeEquotionViewModel : IEquationViewModelBase
    {
        /// <summary>
        /// Gets or sets start control points for interpolation
        /// </summary>
        ObservableCollection<Point> ControlPoints { get; set; }

        /// <summary>
        /// Gets or sets command which adds new control point
        /// </summary>
        RelayCommand AddControlPointCommand { get; set; }

        /// <summary>
        /// Gets or sets command which removes last control point
        /// </summary>
        RelayCommand RemoveControlPointCommand { get; set; }

        /// <summary>
        /// Gets or sets x position of new control point
        /// </summary>
        double NewX { get; set; }

        /// <summary>
        /// Gets or sets y position of new control point
        /// </summary>
        double NewY { get; set; }
    }
}