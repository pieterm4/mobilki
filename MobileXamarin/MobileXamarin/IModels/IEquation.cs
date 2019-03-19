// IEquation.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using MobileXamarin.Enums;
using Xamarin.Forms;

namespace MobileXamarin.IModels
{
    public interface IEquation
    {
        string Name { get; }
        ImageSource Image { get; }
        EquationType EquationType { get; }
    }
}