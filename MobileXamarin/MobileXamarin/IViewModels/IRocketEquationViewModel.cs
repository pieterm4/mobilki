// IRocketEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System.Collections.ObjectModel;

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

        /// <summary>
        /// Gets or sets units for mass of the rocket
        /// </summary>
        ObservableCollection<string> MassOfTheRocketUnits { get; set; }

        /// <summary>
        /// Gets or sets units for mass of the fuel
        /// </summary>
        ObservableCollection<string> MassOfTheFuelUnits { get; set; }

        /// <summary>
        /// Gets or sets units for the flight time
        /// </summary>
        ObservableCollection<string> FlightTimeUnits { get; set; }

        /// <summary>
        /// Gets or sets units for the proper impulse
        /// </summary>
        ObservableCollection<string> ProperImpulseUnits { get; set; }

        /// <summary>
        /// Selected unit for mass of the rocket
        /// </summary>
        string SelectedMassOfTheRocketUnit { get; set; }

        /// <summary>
        /// Selected unit for mass of the fuel
        /// </summary>
        string SelectedMassOfTheFuelUnit { get; set; }

        /// <summary>
        /// Selected unit for the flight time
        /// </summary>
        string SelectedFlightTimeUnit { get; set; }

        /// <summary>
        /// Selected unit for the proper impulse
        /// </summary>
        string SelectedProperImpulseUnit { get; set; }
    }
}