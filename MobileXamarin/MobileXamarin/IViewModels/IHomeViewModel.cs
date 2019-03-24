
using System.Collections.Generic;
using MobileXamarin.IModels;

namespace MobileXamarin.IViewModels
{
    /// <summary>
    /// View model for HomeView
    /// </summary>
    public interface IHomeViewModel
    {
        /// <summary>
        /// Gets all equations
        /// </summary>
        IEnumerable<IEquation> Equations { get; }
    }
}
