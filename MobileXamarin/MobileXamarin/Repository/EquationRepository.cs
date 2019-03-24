// EquationRepository.cs
// All rights reserved
// Piotr Makowiec 13-03-2019

using System.Collections.Generic;
using MobileXamarin.Enums;
using MobileXamarin.IModels;
using MobileXamarin.Models;

namespace MobileXamarin.Repository
{
    public class EquationRepository : IEquationRepository
    {
        private readonly IEnumerable<IEquation> equations;

        public EquationRepository()
        {
            equations = Initialize();
        }

        private IEnumerable<IEquation> Initialize()
        {
            return new List<IEquation>
            {
                new Equation("Kinetic energy equation", "energiakinetyczna.png", EquationType.Kinetic),
                new Equation("Lagrange interpolation", "lagrange.png", EquationType.Lagrange)
            };
        }

        public IEnumerable<IEquation> GetEquations()
        {
            return equations;
        }
    }
}