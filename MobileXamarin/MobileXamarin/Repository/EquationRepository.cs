// EquationRepository.cs
// All rights reserved
// Piotr Makowiec 13-03-2019

using System.Collections.Generic;
using MobileXamarin.Enums;
using MobileXamarin.IModels;
using MobileXamarin.Models;

namespace MobileXamarin.Repository
{
    /// <inheritdoc />
    public class EquationRepository : IEquationRepository
    {
        private readonly IEnumerable<IEquation> equations;

        /// <summary>
        /// Constructor for Equation repository
        /// </summary>
        public EquationRepository()
        {
            equations = Initialize();
        }

        private IEnumerable<IEquation> Initialize()
        {
            return new List<IEquation>
            {
                new Equation("Kinetic energy equation", "energiakinetyczna.png", EquationType.Kinetic),
                new Equation("Lagrange interpolation", "lagrange.png", EquationType.Lagrange),
                new Equation("Vertical movement of the rocket", "rocket.png", EquationType.Rocket)
            };
        }

        /// <inheritdoc />
        public IEnumerable<IEquation> GetEquations()
        {
            return equations;
        }
    }
}