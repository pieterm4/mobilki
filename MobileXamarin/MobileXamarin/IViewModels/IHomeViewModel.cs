
using System.Collections.Generic;
using MobileXamarin.IModels;

namespace MobileXamarin.IViewModels
{
    public interface IHomeViewModel
    {
        IEnumerable<IEquotion> Equotions { get; }
    }
}
