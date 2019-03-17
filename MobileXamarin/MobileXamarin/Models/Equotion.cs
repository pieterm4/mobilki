// Equotion.cs
// All rights reserved
// Piotr Makowiec 13-03-2019

using System.Reflection;
using MobileXamarin.IModels;
using Xamarin.Forms;
using Xamarin.Forms.ToolKit.Extensions;

namespace MobileXamarin.Models
{
    public class Equotion : IEquotion
    {
        private readonly string imageName;
        public string Name { get; set; }

        public ImageSource Image => ImageSource.FromResource($"MobileXamarin.AppResources.Assets.{imageName}");

        //public string Image => imageName;

        public Equotion(string name, string imageName)
        {
            this.imageName = imageName;
            Name = name;

            ImageResourceExtension.InitImageResourceExtension("AppResources.Assets", typeof(App).GetTypeInfo().Assembly);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}