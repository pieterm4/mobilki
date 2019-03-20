// IResultViewModel.cs
// All rights reserved
// Piotr Makowiec 18-03-2019

using System;
using System.Collections.ObjectModel;
using CSharpMath.Rendering;
using GalaSoft.MvvmLight.Command;

namespace MobileXamarin.IViewModels
{
    public interface IResultViewModel : IDisposable
    {
        ObservableCollection<MathSource> Result { get; set; }
        RelayCommand Finish { get; set; }
    }
}