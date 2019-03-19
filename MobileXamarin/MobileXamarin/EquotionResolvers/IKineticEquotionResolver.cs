// IKineticEquotionResolver.cs
// All rights reserved
// Piotr Makowiec 18-03-2019

using System.Collections.Generic;
using System.Threading.Tasks;
using MobileXamarin.Enums;

namespace MobileXamarin.EquotionResolvers
{
    public interface IKineticEquotionResolver
    {
        Task<IEnumerable<string>> Resolve(double weight, Units weightUnit, double speed, Units speedUnit);
    }
}