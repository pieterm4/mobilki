// IResultViewModel.cs
// All rights reserved
// Piotr Makowiec 18-03-2019

using System;
using System.Collections.ObjectModel;
using CSharpMath.Rendering;
using GalaSoft.MvvmLight.Command;

namespace MobileXamarin.IViewModels
{
    /// <summary>
    /// Result viewmodel
    /// </summary>
    public interface IResultViewModel : IDisposable
    {
        /// <summary>
        /// Gets or sets collection of step results for the equation in MathSource type to display math symbols correctly
        /// </summary>
        ObservableCollection<MathSource> Result { get; set; }

        /// <summary>
        /// Gets or sets command which finish this equation resolving and goes to the start page
        /// </summary>
        RelayCommand Finish { get; set; }
    }
}