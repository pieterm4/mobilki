// IRocketEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

namespace MobileXamarin.IViewModels
{
    /// <summary>
    /// Rocket equation view model
    /// </summary>
    public interface IRocketEquationViewModel : IEquationViewModelBase
    {
        /// <summary>
        /// Gets or sets mass of the rocket
        /// </summary>
        double MassOfTheRocket { get; set; }

        /// <summary>
        /// Gets or sets mass of the fuel in the rocket
        /// </summary>
        double MassOfTheFuel { get; set; }

        /// <summary>
        /// Gets or sets for how long of the rocket's trip the result is calculating
        /// </summary>
        double FlightTime { get; set; }

        /// <summary>
        /// Gets or sets value of how much fuel is throwing out from the rocket
        /// </summary>
        double ProperImpulse { get; set; }
    }
}