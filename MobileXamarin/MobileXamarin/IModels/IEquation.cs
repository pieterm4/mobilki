// IEquation.cs
// All rights reserved
// Piotr Makowiec 16-03-2019

using MobileXamarin.Enums;
using Xamarin.Forms;

namespace MobileXamarin.IModels
{
    /// <summary>
    /// Equation model interface
    /// </summary>
    public interface IEquation
    {
        /// <summary>
        /// Name of the equation
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the image of that equation
        /// </summary>
        ImageSource Image { get; }

        /// <summary>
        /// Type of equation
        /// </summary>
        EquationType EquationType { get; }
    }
}