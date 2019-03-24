// IEquationRepository.cs
// All rights reserved
// Piotr Makowiec 13-03-2019

using System.Collections.Generic;
using MobileXamarin.IModels;

namespace MobileXamarin.Repository
{
    /// <summary>
    /// Repository for equations
    /// </summary>
    public interface IEquationRepository
    {
        /// <summary>
        /// Get all saved equations
        /// </summary>
        /// <returns>Returns all equations</returns>
        IEnumerable<IEquation> GetEquations();
    }
}