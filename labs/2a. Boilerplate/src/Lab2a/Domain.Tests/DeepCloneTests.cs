using FluentAssertions;

namespace Domain.Tests;

[TestClass]
public sealed class DeepCloneTests
{
    [TestMethod]
    public void Aircraft_DeepClone()
    {
        // Arrange
        var sut = new Aircraft
        {
            Manufacturer = "Airbus",
            Model = "A320",
            Seats = 150,
            Engines =
            [
                new AircraftEngine
                {
                    Manufacturer = "IAE",
                    Power = 25000
                },
                new AircraftEngine
                {
                    Manufacturer = "IAE",
                    Power = 25000
                }
            ]
        };

        // Act
        var result = sut.DeepClone();

        // Assert
        result.Should().NotBe(sut);
        result.Should().BeEquivalentTo(sut);
        result.Engines.Should().NotBeSameAs(sut.Engines);
    }

    [TestMethod]
    public void AircraftEngine_DeepClone()
    {
        // Arrange
        var sut = new AircraftEngine
        {
            Manufacturer = "GE Aviation",
            Power = 27000
        };

        // Act
        var result = sut.DeepClone();

        // Assert
        result.Should().NotBe(sut);
        result.Should().BeEquivalentTo(sut);
    }

    [TestMethod]
    public void Flight_DeepClone()
    {
        // Arrange
        var sut = new Flight
        {
            DepartureAirport = "JFK",
            ArrivalAirport = "LAX",
            DepartureTime = new DateTime(2024, 10, 1, 8, 0, 0),
            ArrivalTime = new DateTime(2024, 10, 1, 11, 0, 0),
            Aircraft = new Aircraft
            {
                Manufacturer = "Boeing",
                Model = "737",
                Seats = 160,
                Engines =
                [
                    new AircraftEngine
                    {
                        Manufacturer = "CFM International",
                        Power = 27000
                    },
                    new AircraftEngine
                    {
                        Manufacturer = "CFM International",
                        Power = 27000
                    }
                ]
            }
        };

        // Act
        var result = sut.DeepClone();

        // Assert
        result.Should().NotBe(sut);
        result.Should().BeEquivalentTo(sut);
        result.Aircraft.Should().NotBe(sut.Aircraft);
    }
}
