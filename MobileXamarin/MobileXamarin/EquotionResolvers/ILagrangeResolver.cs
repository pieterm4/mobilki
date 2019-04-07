// ILagrangeResolver.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System.Collections.Generic;
using System.Threading.Tasks;
using MobileXamarin.Models;

namespace MobileXamarin.EquotionResolvers
{
    /// <summary>
    /// Resolver for Lagrange interpolation equation
    /// </summary>
    public interface ILagrangeResolver
    {
        /// <summary>
        /// Resolves lagrange interpolation
        /// </summary>
        /// <param name="controlPoints">Control points based on interpolation is calculated</param>
        /// <returns>Points which can be displayed on the chart</returns>
        Task<Result> Resolve(IEnumerable<Point> controlPoints);
    }
}