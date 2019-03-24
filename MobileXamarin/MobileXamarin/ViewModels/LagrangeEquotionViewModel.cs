// LagrangeEquotionViewModel.cs
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
    public class LagrangeEquotionViewModel : EquationViewModelBase, ILagrangeEquotionViewModel
    {
        private readonly ILagrangeResolver resolver;
        private readonly IMessenger messenger;
        private ObservableCollection<Point> controlPoints;
        private double newX;
        private double newY;

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

        public RelayCommand AddControlPointCommand { get; set; }
        public RelayCommand RemoveControlPointCommand { get; set; }

        public LagrangeEquotionViewModel(ILagrangeResolver resolver, IMessenger messenger)
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

        protected override bool ResolveCanExecute()
        {
            return ControlPoints.Count > 1;
        }

        protected override async Task ResolveExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}