using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileXamarin.Enums;
using MobileXamarin.Repository;

namespace UnitTest
{
    [TestClass]
    public class UnitRepositoryTest
    {
        [TestMethod]
        public void Given_UnitRepository_When_GetUnitStringForSecond_Then_ResultIsSecondsStringRepresentation()
        {
            var expected = "s";

            var result = UnitRepository.GetUnitString(Units.Second);

            result.Should().Be(expected);
        }

        [TestMethod]
        public void Given_UnitRepository_When_GetUnitStringForSecond_Then_ResultIsGramStringRepresentation()
        {
            var expected = "g";

            var result = UnitRepository.GetUnitString(Units.Gram);

            result.Should().Be(expected);
        }

        [TestMethod]
        public void Given_UnitRepository_When_GetUnitStringForSecond_Then_ResultIsKilogramStringRepresentation()
        {
            var expected = "Kg";

            var result = UnitRepository.GetUnitString(Units.Kilogram);

            result.Should().Be(expected);
        }

        [TestMethod]
        public void Given_UnitRepository_When_GetUnitStringForSecond_Then_ResultIsMeterStringRepresentation()
        {
            var expected = "m";

            var result = UnitRepository.GetUnitString(Units.Meter);

            result.Should().Be(expected);
        }

        [TestMethod]
        public void Given_UnitRepository_When_GetUnitStringForSecond_Then_ResultIsHourStringRepresentation()
        {
            var expected = "h";

            var result = UnitRepository.GetUnitString(Units.Hour);

            result.Should().Be(expected);
        }

        [TestMethod]
        public void Given_UnitRepository_When_GetUnitStringForSecond_Then_ResultIsKilometerStringRepresentation()
        {
            var expected = "Km";

            var result = UnitRepository.GetUnitString(Units.Kilometer);

            result.Should().Be(expected);
        }

        [TestMethod]
        public void Given_UnitRepository_When_GetUnitStringForSecond_Then_ResultIsKilometerPerHourStringRepresentation()
        {
            var expected = "Km/h";

            var result = UnitRepository.GetUnitString(Units.KilometerPerHour);

            result.Should().Be(expected);
        }

        [TestMethod]
        public void Given_UnitRepository_When_GetUnitStringForSecond_Then_ResultIsMeterPerSecondStringRepresentation()
        {
            var expected = "m/s";

            var result = UnitRepository.GetUnitString(Units.MeterForSecond);

            result.Should().Be(expected);
        }
    }
}
