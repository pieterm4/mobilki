// IEquotion.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using MobileXamarin.Enums;
using Xamarin.Forms;

namespace MobileXamarin.IModels
{
    public interface IEquotion
    {
        string Name { get; }
        ImageSource Image { get; }
        EquotionType EquotionType { get; }
    }
}