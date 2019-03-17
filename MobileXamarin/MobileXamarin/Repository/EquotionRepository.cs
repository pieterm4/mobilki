// EquotionRepository.cs
// All rights reserved
// Piotr Makowiec 13-03-2019

using System.Collections.Generic;
using MobileXamarin.IModels;
using MobileXamarin.Models;

namespace MobileXamarin.Repository
{
    public class EquotionRepository : IEquotionRepository
    {
        private readonly IEnumerable<IEquotion> equotions;

        public EquotionRepository()
        {
            equotions = Initialize();
        }

        private IEnumerable<IEquotion> Initialize()
        {
            return new List<IEquotion>
            {
                new Equotion("Kinetic energy equotion", "energiakinetyczna.png"),
                new Equotion("Relative speed equotion", "ic_sample.png")
            };
        }

        public IEnumerable<IEquotion> GetEquotions()
        {
            return equotions;
        }
    }
}