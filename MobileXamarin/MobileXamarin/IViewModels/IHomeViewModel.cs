
using System.Collections.Generic;
using MobileXamarin.IModels;

namespace MobileXamarin.IViewModels
{
    public interface IHomeViewModel
    {
        string WelcomeText { get; }

        IEnumerable<IEquotion> Equotions { get; }
    }
}
