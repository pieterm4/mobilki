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

        Units WeightUnits { get; set; }

        Units SpeedUnits { get; set; }
    }
}