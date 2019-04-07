// EquationViewModelBase.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MobileXamarin.IViewModels;

namespace MobileXamarin.ViewModels
{
    /// <summary>
    /// Abstract base class for equation view models
    /// </summary>
    public abstract class EquationViewModelBase : BaseViewModel, IEquationViewModelBase
    {
        private bool isBusy;

        /// <summary>
        /// Indicates when to show busy indication
        /// </summary>
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }

        /// <summary>
        /// Gets command for resolving equation
        /// </summary>
        public RelayCommand Resolve { get; }

        /// <summary>
        /// Constructor for base class for equation view models
        /// </summary>
        protected EquationViewModelBase()
        {
            Resolve = new RelayCommand(async () => await ResolveExecute(), ResolveCanExecute);
        }

        /// <summary>
        /// Determines if can execute Resolve command
        /// </summary>
        /// <returns>True when can execute Resolve command, False if not</returns>
        protected abstract bool ResolveCanExecute();

        /// <summary>
        /// Executes Resolve command
        /// </summary>
        /// <returns>Task which execute command</returns>
        protected abstract Task ResolveExecute();
    }
}