﻿// IRocketEquationResolver.cs
// All rights reserved
// Piotr Makowiec 24-03-2019

using System.Threading.Tasks;
using MobileXamarin.Models;

namespace MobileXamarin.EquationResolvers
{
    /// <summary>
    /// Resolver for vertical rocket start equation
    /// </summary>
    public interface IRocketEquationResolver
    {
        /// <summary>
        /// Resolves rocket equation
        /// </summary>
        /// <param name="rocketParameter">Parameters of the rocket</param>
        /// <returns>Result</returns>
        Task<Result> Resolve(RocketParameter rocketParameter);
    }
}