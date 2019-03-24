// HomeViewModelTest.cs
// All rights reserved
// Piotr Makowiec 17-03-2019

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileXamarin.IModels;
using MobileXamarin.Repository;
using MobileXamarin.ViewModels;
using Moq;
using Xamarin.Forms.Navigation;

namespace UnitTest.ViewModels
{
    [TestClass]
    public class HomeViewModelTest
    {
        private Mock<IEquationRepository> equationRepository;
        private Mock<INavigationService> navigationService;

        [TestInitialize]
        public void Setup()
        {
            equationRepository = new Mock<IEquationRepository>();
            equationRepository.Setup(x => x.GetEquations());
            navigationService = new Mock<INavigationService>();
            navigationService.Setup(x => x.NavigateTo(It.IsAny<string>()));
        }

        [TestMethod]
        public void Given_HomeViewModel_When_Instantiated_Then_GetEquationsInvoked()
        {
            var viewModel = GetObjectUnderTest();

            equationRepository.Verify(x => x.GetEquations(), Times.Once);
        }

        [TestMethod]
        public void Given_HomeViewModel_When_Initialized_Then_NextPageCommandCanExecuteShouldBeFalse()
        {
            var viewModel = GetObjectUnderTest();

            viewModel.NextPageCommand.CanExecute(new object()).Should().BeFalse();
        }

        [TestMethod]
        public void Given_HomeViewModel_When_SelectedEquationIsNotNull_Then_NextPageCommandCanExecuteShouldBeTrue()
        {
            var equation = Mock.Of<IEquation>();
            var viewModel = GetObjectUnderTest();

            viewModel.SelectedEquation = equation;

            viewModel.NextPageCommand.CanExecute(new object()).Should().BeTrue();
        }

        private HomeViewModel GetObjectUnderTest()
        {
            return new HomeViewModel(equationRepository.Object, navigationService.Object);
        }
    }
}