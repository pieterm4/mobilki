// IKineticEquationResolver.cs
// All rights reserved
// Piotr Makowiec 18-03-2019

using System.Threading.Tasks;
using MobileXamarin.Enums;
using MobileXamarin.Models;

namespace MobileXamarin.EquationResolvers
{
    /// <summary>
    /// Resolver for kinetic energy equation
    /// </summary>
    public interface IKineticEquationResolver
    {
        /// <summary>
        /// Resolves kinetic energy equation
        /// </summary>
        /// <param name="weight">Weight of the object</param>
        /// <param name="weightUnit">Unit of object's weight</param>
        /// <param name="speed">Speed of object</param>
        /// <param name="speedUnit">Unit of object's speed</param>
        /// <returns>Returns step by step in Latex format result of the equation resolving</returns>
        Task<Result> Resolve(double weight, Units weightUnit, double speed, Units speedUnit);
    }
}