﻿// HomeViewModelTest.cs
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
        private Mock<IEquotionRepository> equotionRepository;
        private Mock<INavigationService> navigationService;

        [TestInitialize]
        public void Setup()
        {
            equotionRepository = new Mock<IEquotionRepository>();
            equotionRepository.Setup(x => x.GetEquotions());
            navigationService = new Mock<INavigationService>();
            navigationService.Setup(x => x.NavigateTo(It.IsAny<string>()));
        }

        [TestMethod]
        public void Given_HomeViewModel_When_Instantiated_Then_GetEquotionsInvoked()
        {
            var viewModel = GetObjectUnderTest();

            equotionRepository.Verify(x => x.GetEquotions(), Times.Once);
        }

        [TestMethod]
        public void Given_HomeViewModel_When_Initialized_Then_NextPageCommandCanExecuteShouldBeFalse()
        {
            var viewModel = GetObjectUnderTest();

            viewModel.NextPageCommand.CanExecute(new object()).Should().BeFalse();
        }

        [TestMethod]
        public void Given_HomeViewModel_When_SelectedEquotionIsNotNull_Then_NextPageCommandCanExecuteShouldBeTrue()
        {
            var equotion = Mock.Of<IEquotion>();
            var viewModel = GetObjectUnderTest();

            viewModel.SelectedEquotion = equotion;

            viewModel.NextPageCommand.CanExecute(new object()).Should().BeTrue();
        }

        private HomeViewModel GetObjectUnderTest()
        {
            return new HomeViewModel(equotionRepository.Object, navigationService.Object);
        }
    }
}