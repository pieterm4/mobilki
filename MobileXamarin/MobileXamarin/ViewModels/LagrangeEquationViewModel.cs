// LagrangeEquationViewModel.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MobileXamarin.EquotionResolvers;
using MobileXamarin.IViewModels;
using MobileXamarin.Views;
using Xamarin.Forms.Navigation;
using Point = MobileXamarin.Models.Point;

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
        /// <param name="navigationService">Navigation service <see cref="INavigationService"/></param>
        public LagrangeEquationViewModel(ILagrangeResolver resolver, IMessenger messenger, INavigationService navigationService)
        {
            this.resolver = resolver;
            this.messenger = messenger;
            NavigationService = navigationService;
            AddControlPointCommand = new RelayCommand(AddControlPoint, CanAddControlPoint);
            RemoveControlPointCommand = new RelayCommand(RemoveControlPoint, CanRemoveControlPoint);
            ControlPoints = GetDefaultControlPoints();
            ControlPoints.CollectionChanged += OnCollectionChanged;
        }

        private ObservableCollection<Point> GetDefaultControlPoints()
        {
            return new ObservableCollection<Point>
            {
                new Point(0.4, 0.5),
                new Point(0.8, 11.7),
                new Point(1.2, 14.8),
                new Point(1.6, 4.0),
                new Point(2.0, 2.2),
                new Point(2.4, 0.2)
            };
        }

        /// <inheritdoc />
        protected override bool ResolveCanExecute()
        {
            return ControlPoints.Count > 1;
        }

        /// <inheritdoc />
        protected override async Task ResolveExecute()
        {
            IsBusy = true;
            var result = await resolver.Resolve(ControlPoints);

            var parameters = new NavigationParameters
            {
                {"Result", result}
            };

            messenger.Send(result);
            await Task.Delay(2000);
            IsBusy = false;

            await NavigationService.NavigateTo(nameof(ResultView), parameters, true);
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RemoveControlPointCommand.RaiseCanExecuteChanged();
            Resolve.RaiseCanExecuteChanged();
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
            var point = new Point(NewX, NewY);
            ControlPoints.Add(point);
            ClearInput();
        }

        private void ClearInput()
        {
            NewX = 0d;
            NewY = 0d;
        }
    }
}