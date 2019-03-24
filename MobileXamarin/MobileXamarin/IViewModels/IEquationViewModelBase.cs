// IEquationViewModelBase.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using GalaSoft.MvvmLight.Command;

namespace MobileXamarin.IViewModels
{
    /// <summary>
    /// Base interface for equation view models
    /// </summary>
    public interface IEquationViewModelBase
    {
        /// <summary>
        /// Gets command for resolving equation
        /// </summary>
        RelayCommand Resolve { get; }
    }
}