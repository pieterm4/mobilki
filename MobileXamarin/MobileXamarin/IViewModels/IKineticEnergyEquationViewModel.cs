// IKineticEnergyEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

namespace MobileXamarin.IViewModels
{
    /// <summary>
    /// View model for Kinetic Energy Equation View
    /// </summary>
    public interface IKineticEnergyEquationViewModel : IEquationViewModelBase
    {
        /// <summary>
        /// Gets or sets weight of the object
        /// </summary>
        double Weight { get; set; }

        /// <summary>
        /// Gets or sets speed of the object
        /// </summary>
        double Speed { get; set; }

        /// <summary>
        /// Gets or sets unit for the weight of the object
        /// </summary>
        string SelectedWeightUnit { get; set; }

        /// <summary>
        /// Gets or sets unit for the speed of the object
        /// </summary>
        string SelectedSpeedUnit { get; set; }
    }
}