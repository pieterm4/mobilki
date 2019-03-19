// IEquationRepository.cs
// All rights reserved
// Piotr Makowiec 13-03-2019

using System.Collections.Generic;
using MobileXamarin.IModels;

namespace MobileXamarin.Repository
{
    public interface IEquationRepository
    {
        IEnumerable<IEquation> GetEquations();
    }
}