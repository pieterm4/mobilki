// ResultViewModel.cs
// All rights reserved
// Piotr Makowiec 18-03-2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CSharpMath.Rendering;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microcharts;
using Microsoft.Win32.SafeHandles;
using MobileXamarin.IViewModels;
using MobileXamarin.Models;
using SkiaSharp;
using Xamarin.Forms.Navigation;
using Xamarin.Forms.Popups;

namespace MobileXamarin.ViewModels
{
    /// <summary>
    /// Result viewmodel
    /// </summary>
    public class ResultViewModel : BaseViewModel, IResultViewModel
    {
        private readonly IMessenger messenger;
        private bool disposed = false;
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private ObservableCollection<MathSource> solution;
        private Chart chart;
        private bool isChartVisible;


        /// <summary>
        /// Gets or sets collection of step results for the equation in MathSource type to display math symbols correctly
        /// </summary>
        public ObservableCollection<MathSource> Solution
        {
            get => solution;
            set
            {
                if (solution != value)
                {
                    solution = value;
                    OnPropertyChanged(nameof(Solution));
                }
            }
        }

        /// <summary>
        /// Control points for chart
        /// </summary>
        public ObservableCollection<Point> ControlPoints { get; set; }

        /// <summary>
        /// Start points before calculation
        /// </summary>
        public ObservableCollection<Point> StartPoints { get; set; }

        /// <summary>
        /// Gets or sets chart (right now we use Telerik, so it is not used
        /// </summary>
        public Chart Chart
        {
            get => chart;
            set
            {
                if (chart != value)
                {
                    chart = value;
                    OnPropertyChanged(nameof(Chart));
                }
            }
        }

        public bool IsChartVisible
        {
            get => isChartVisible;
            set {
                if (isChartVisible != value) {
                    isChartVisible = value;
                    OnPropertyChanged(nameof(IsChartVisible));
                }
            }
        }

        private void SetChartVisibility() {
            IsChartVisible = ControlPoints.Count>0;
        }

        /// <summary>
        /// Gets or sets command which finish this equation resolving and goes to the start page
        /// </summary>
        public RelayCommand Finish { get; set; }

        /// <summary>
        /// Constructor for ResultViewModel
        /// </summary>
        /// <param name="navigationService">Navigation service <see cref="INavigationService"/></param>
        /// <param name="popupsService">Popup service <see cref="IPopupsService"/></param>
        /// <param name="messenger">Messenger <see cref="IMessenger"/></param>
        public ResultViewModel(
            INavigationService navigationService,
            IPopupsService popupsService,
            IMessenger messenger)
        {
            this.messenger = messenger;
            NavigationService = navigationService;
            PopupService = popupsService;
            Finish = new RelayCommand(async () => await FinishExecute(), CanFinishExecute);
            this.messenger.Register<Result>(this, OnGetMessage);
            Solution = new ObservableCollection<MathSource>();
            ControlPoints = new ObservableCollection<Point>();
            StartPoints = new ObservableCollection<Point>();
            Chart = new LineChart()
            {
                LineMode = LineMode.Straight,
                PointSize = 18,
                
            };
            SetupResult();

            SetupChartEntries();
            SetChartVisibility();
        }

        private void SetupChartEntries()
        {
            var entries = new List<Entry>();
            foreach (var controlPoint in ControlPoints)
            {
                var entry = new Entry((float) controlPoint.Y)
                    {Color = new SKColor(255, 160, 200), Label = controlPoint.X.ToString(CultureInfo.InvariantCulture)};
                entries.Add(entry);
            }

            Chart.Entries = entries;
        }

        private void SetupResult()
        {
            var result = GetResult();
            SetupPoints(result);
        }

        private void SetupPoints(Result result)
        {
            foreach (var value in result.Solution)
            {
                Solution.Add(new MathSource(value));
            }

            foreach (var resultControlPoint in result.ControlPoints)
            {
                ControlPoints.Add(resultControlPoint);
            }

            foreach (var startPoint in result.StartPoints)
            {
                StartPoints.Add(startPoint);
            }
        }

        private async Task FinishExecute()
        {
            var isGoingToStart = await PopupService.DisplayAlert("Finishing...", "Do you want to come back to start page?", "Yes", "No");
            if (isGoingToStart)
            {
                await NavigationService.PopToRootAsync(true);
            }
        }

        private bool CanFinishExecute()
        {
            return true;
        }

        private void OnGetMessage(Result result)
        {
            Solution.Clear();
            ControlPoints.Clear();
            StartPoints.Clear();
            SetupPoints(result);
           
            SetupChartEntries();
            SetChartVisibility();
        }

        private Result GetResult()
        {
            return NavigationService.GetParameters().GetValue<Result>("Result");
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose this when it's not whi;e disposing
        /// </summary>
        /// <param name="disposing">Is disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
    }
}