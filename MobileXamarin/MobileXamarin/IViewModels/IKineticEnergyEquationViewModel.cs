// IKineticEnergyEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

namespace MobileXamarin.IViewModels
{
    public interface IKineticEnergyEquationViewModel : IEquationViewModelBase
    {
        double Weight { get; set; }

        double Speed { get; set; }

        string SelectedWeightUnit { get; set; }

        string SelectedSpeedUnit { get; set; }
    }
}