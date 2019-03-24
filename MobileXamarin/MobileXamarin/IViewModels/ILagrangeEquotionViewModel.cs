// ILagrangeEquotionViewModel.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System.Collections.ObjectModel;
using System.Drawing;
using GalaSoft.MvvmLight.Command;

namespace MobileXamarin.IViewModels
{
    public interface ILagrangeEquotionViewModel : IEquationViewModelBase
    {
        ObservableCollection<Point> ControlPoints { get; set; }

        RelayCommand AddControlPointCommand { get; set; }

        RelayCommand RemoveControlPointCommand { get; set; }
        double NewX { get; set; }
        double NewY { get; set; }
    }
}