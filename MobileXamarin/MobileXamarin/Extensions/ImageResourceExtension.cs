// ImageResourceExtension.cs
// All rights reserved
// Piotr Makowiec 14-03-2019

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileXamarin.Extensions
{
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            return ImageSource.FromResource(Source);
        }
    }
}