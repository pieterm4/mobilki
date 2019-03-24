// LagrangeEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MobileXamarin.EquotionResolvers;
using MobileXamarin.IViewModels;

namespace MobileXamarin.ViewModels
{
    /// <summary>
    /// Lagrange interpolation viewmodel
    /// </summary>
    public class LagrangeEquationViewModel : EquationViewModelBase, ILagrangeEquationViewModel
    {
        private readonly ILagrangeResolver resolver;
        private readonly IMessenger messenger;
        private ObservableCollection<Point> controlPoints;
        private double newX;
        private double newY;

        /// <inheritdoc />
        public ObservableCollection<Point> ControlPoints
        {
            get => controlPoints;
            set
            {
                if (controlPoints != value)
                {
                    controlPoints = value;
                    OnPropertyChanged(nameof(ControlPoints));
                    Resolve.RaiseCanExecuteChanged();
                    RemoveControlPointCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc />
        public double NewX
        {
            get => newX;
            set
            {
                if (Math.Abs(newX - value) > double.Epsilon)
                {
                    newX = value;
                    OnPropertyChanged(nameof(NewX));
                    AddControlPointCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc />
        public double NewY
        {
            get => newY;
            set
            {
                if (Math.Abs(newY - value) > double.Epsilon)
                {
                    newY = value;
                    OnPropertyChanged(nameof(NewY));
                    AddControlPointCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc />
        public RelayCommand AddControlPointCommand { get; set; }

        /// <inheritdoc />
        public RelayCommand RemoveControlPointCommand { get; set; }

        /// <summary>
        /// Constructor for LagrangeEquationViewModel
        /// </summary>
        /// <param name="resolver">Lagrange interpolation equation resolver <see cref="ILagrangeResolver"/></param>
        /// <param name="messenger">Messenger <see cref="IMessenger"/></param>
        public LagrangeEquationViewModel(ILagrangeResolver resolver, IMessenger messenger)
        {
            this.resolver = resolver;
            this.messenger = messenger;
            AddControlPointCommand = new RelayCommand(AddControlPoint, CanAddControlPoint);
            RemoveControlPointCommand = new RelayCommand(RemoveControlPoint, CanRemoveControlPoint);
        }

        private bool CanRemoveControlPoint()
        {
            return ControlPoints.Any();
        }

        private void RemoveControlPoint()
        {
            if (ControlPoints.Any())
            {
                ControlPoints.Remove(ControlPoints.Last());
            }
        }

        private bool CanAddControlPoint()
        {
            return true;
        }

        private void AddControlPoint()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        protected override bool ResolveCanExecute()
        {
            return ControlPoints.Count > 1;
        }

        /// <inheritdoc />
        protected override async Task ResolveExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}