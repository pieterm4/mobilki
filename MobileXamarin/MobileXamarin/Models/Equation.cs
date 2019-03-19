// Equation.cs
// All rights reserved
// Piotr Makowiec 13-03-2019

using MobileXamarin.Enums;
using MobileXamarin.IModels;
using Xamarin.Forms;

namespace MobileXamarin.Models
{
    public class Equation : IEquation
    {
        private readonly string imageName;
        public string Name { get; }

        public EquationType EquationType { get; }

        public ImageSource Image => ImageSource.FromResource($"MobileXamarin.AppResources.Assets.{imageName}");


        public Equation(string name, string imageName, EquationType type)
        {
            this.imageName = imageName;
            Name = name;
            EquationType = type;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}