using Mindbox.Task1.Shapes.Shapes;

namespace Mindbox.Task1.Shapes.UnitTests.ShapesTests;

public class CircleTests
{
    [Fact]
    public void Constructor_Success()
    {
        // Arrange
        double expectedRadius = 5;

        // Act
        Circle circle = new(expectedRadius);

        // Assert
        Assert.Equal(expectedRadius, circle.Radius);
    }
    
    [Theory]
    [InlineData(3, 28.2743338815)]
    [InlineData(12, 452.389342104)]
    public void CalculateArea_Success(double radius, double expectedResult)
    {
        // Arrange
        Circle circle = new(radius);

        // Act
        // Assert
        Assert.Equal(expectedResult, circle.CalculateArea(),  TestsConstants.ComparisonPrecision);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-2)]
    public void Constructor_InvalidRadius_ArgumentException(double radius)
    {
        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }
}