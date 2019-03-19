// ResultViewModel.cs
// All rights reserved
// Piotr Makowiec 18-03-2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32.SafeHandles;
using MobileXamarin.IViewModels;
using Xamarin.Forms.Navigation;
using Xamarin.Forms.Popups;

namespace MobileXamarin.ViewModels
{
    public class ResultViewModel : BaseViewModel, IResultViewModel
    {
        private readonly IMessenger messenger;
        private bool disposed = false;
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private ObservableCollection<string> result;

        public ObservableCollection<string> Result
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

        public RelayCommand Finish { get; set; }

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

            var parameters = GetResult();
            Result = new ObservableCollection<string>(parameters);
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
            Result = new ObservableCollection<string>(obj);
        }

        private IEnumerable<string> GetResult()
        {
            return NavigationService.GetParameters().GetValue<IEnumerable<string>>("Result");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
    }
}