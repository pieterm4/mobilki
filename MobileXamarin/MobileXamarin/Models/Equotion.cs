// Equotion.cs
// All rights reserved
// Piotr Makowiec 13-03-2019

using MobileXamarin.Enums;
using MobileXamarin.IModels;
using Xamarin.Forms;

namespace MobileXamarin.Models
{
    public class Equotion : IEquotion
    {
        private readonly string imageName;
        public string Name { get; }

        public EquotionType EquotionType { get; }

        public ImageSource Image => ImageSource.FromResource($"MobileXamarin.AppResources.Assets.{imageName}");


        public Equotion(string name, string imageName, EquotionType type)
        {
            this.imageName = imageName;
            Name = name;
            EquotionType = type;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}