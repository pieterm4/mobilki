// HomeViewModelTest.cs
// All rights reserved
// Piotr Makowiec 17-03-2019

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileXamarin.Repository;
using MobileXamarin.ViewModels;
using Moq;
using Xamarin.Forms.Navigation;

namespace UnitTest.ViewModels
{
    [TestClass]
    public class HomeViewModelTest
    {
        [TestMethod]
        public void Given_HomeViewModel_When_Instantiated_Then_GetEquotionsInvoked()
        {
            var equotionRepository = new Mock<IEquotionRepository>();
            equotionRepository.Setup(x => x.GetEquotions());
            var navigationService = new Mock<INavigationService>();

            var viewModel = new HomeViewModel(equotionRepository.Object, navigationService.Object);

            equotionRepository.Verify(x => x.GetEquotions(), Times.Once);
        }
    }
}