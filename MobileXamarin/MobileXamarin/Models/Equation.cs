// Equation.cs
// All rights reserved
// Piotr Makowiec 13-03-2019

using MobileXamarin.Enums;
using MobileXamarin.IModels;
using Xamarin.Forms;

namespace MobileXamarin.Models
{
    /// <summary>
    /// Equation model
    /// </summary>
    public class Equation : IEquation
    {
        private readonly string imageName;

        /// <summary>
        /// Name of the equation
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Type of equation
        /// </summary>
        public EquationType EquationType { get; }

        /// <summary>
        /// Gets the image of that equation
        /// </summary>
        public ImageSource Image => ImageSource.FromResource($"MobileXamarin.AppResources.Assets.{imageName}");


        /// <summary>
        /// Constructor for equation model
        /// </summary>
        /// <param name="name">Name of the equation</param>
        /// <param name="imageName">Image name which is in Assets for the equation</param>
        /// <param name="type">Type of equation</param>
        public Equation(string name, string imageName, EquationType type)
        {
            this.imageName = imageName;
            Name = name;
            EquationType = type;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }
}