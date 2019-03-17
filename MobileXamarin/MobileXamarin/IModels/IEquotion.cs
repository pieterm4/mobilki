// IEquotion.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using Xamarin.Forms;

namespace MobileXamarin.IModels
{
    public interface IEquotion
    {
        string Name { get; set; }
        ImageSource Image { get; }
    }
}