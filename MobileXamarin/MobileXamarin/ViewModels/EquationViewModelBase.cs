// EquationViewModelBase.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MobileXamarin.IViewModels;

namespace MobileXamarin.ViewModels
{
    public abstract class EquationViewModelBase : BaseViewModel, IEquationViewModelBase
    {
        public RelayCommand Resolve { get; }

        protected EquationViewModelBase()
        {
            Resolve = new RelayCommand(async () => await ResolveExecute(), ResolveCanExecute);
        }

        protected abstract bool ResolveCanExecute();

        protected abstract Task ResolveExecute();
    }
}