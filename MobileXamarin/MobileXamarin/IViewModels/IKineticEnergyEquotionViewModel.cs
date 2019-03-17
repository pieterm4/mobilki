// IKineticEnergyEquotionViewModel.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using MobileXamarin.Enums;

namespace MobileXamarin.IViewModels
{
    public interface IKineticEnergyEquotionViewModel : IEquotionViewModelBase
    {
        double Weight { get; set; }

        double Speed { get; set; }

        string SelectedWeightUnit { get; set; }

        string SelectedSpeedUnit { get; set; }
    }
}