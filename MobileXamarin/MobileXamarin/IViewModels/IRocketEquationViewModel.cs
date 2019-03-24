// IRocketEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

namespace MobileXamarin.IViewModels
{
    public interface IRocketEquationViewModel : IEquationViewModelBase
    {
        double MassOfTheRocket { get; set; }
        double MassOfTheFuel { get; set; }
        double FlightTime { get; set; }
        double ProperImpulse { get; set; }
    }
}