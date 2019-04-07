// IResultViewModel.cs
// All rights reserved
// Piotr Makowiec 18-03-2019

using System;
using System.Collections.ObjectModel;
using CSharpMath.Rendering;
using GalaSoft.MvvmLight.Command;
using Microcharts;
using MobileXamarin.Models;

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
        ObservableCollection<MathSource> Solution { get; set; }

        /// <summary>
        /// Control points for chart
        /// </summary>
        ObservableCollection<Point> ControlPoints { get; set; }

        /// <summary>
        /// Gets or sets command which finish this equation resolving and goes to the start page
        /// </summary>
        RelayCommand Finish { get; set; }

        Chart Chart { get; set; }
        ObservableCollection<Point> StartPoints { get; set; }
    }
}