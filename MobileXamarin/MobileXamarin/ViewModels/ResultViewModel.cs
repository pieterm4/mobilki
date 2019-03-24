// ResultViewModel.cs
// All rights reserved
// Piotr Makowiec 18-03-2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CSharpMath.Rendering;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32.SafeHandles;
using MobileXamarin.IViewModels;
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
        private ObservableCollection<MathSource> result;

        /// <inheritdoc />
        public ObservableCollection<MathSource> Result
        {
            get => result;
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        /// <inheritdoc />
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
            this.messenger.Register<IEnumerable<string>>(this, OnGetMessage);
            Result = new ObservableCollection<MathSource>();
            SetupResult();
        }

        private void SetupResult()
        {
            var parameters = GetResult().ToList();
            foreach (var parameter in parameters)
            {
                Result.Add(new MathSource(parameter));
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

        private void OnGetMessage(IEnumerable<string> obj)
        {
            Result.Clear();
            foreach (var variable in obj)
            {
                Result.Add(new MathSource(variable));
            }
        }

        private IEnumerable<string> GetResult()
        {
            return NavigationService.GetParameters().GetValue<IEnumerable<string>>("Result");
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