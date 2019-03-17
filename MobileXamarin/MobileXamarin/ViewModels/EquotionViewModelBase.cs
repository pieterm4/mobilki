// EquotionViewModelBase.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using System.Windows.Input;
using MobileXamarin.IViewModels;

namespace MobileXamarin.ViewModels
{
    public abstract class EquotionViewModelBase : BaseViewModel, IEquotionViewModelBase
    {
        public string EquotionName { get; }
        public ICommand Resolve { get; }
    }
}