// IEquotionViewModelBase.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using System.Windows.Input;

namespace MobileXamarin.IViewModels
{
    public interface IEquotionViewModelBase
    {
        string EquotionName { get; }
        ICommand Resolve { get; }
    }
}