// IEquationViewModelBase.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using GalaSoft.MvvmLight.Command;

namespace MobileXamarin.IViewModels
{
    public interface IEquationViewModelBase
    {
        RelayCommand Resolve { get; }
    }
}