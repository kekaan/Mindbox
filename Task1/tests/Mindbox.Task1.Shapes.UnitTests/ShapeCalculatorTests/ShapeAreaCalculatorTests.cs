using Mindbox.Task1.Shapes.Interfaces;
using Mindbox.Task1.Shapes.ShapeCalculators;
using Mindbox.Task1.Shapes.Shapes;

namespace Mindbox.Task1.Shapes.UnitTests.ShapeCalculatorTests;

public class ShapeAreaCalculatorTests
{
    [Fact]
    public void ShapeAreaCalculatorTest()
    {
        // Arrange
        IShape circle = new Circle(5);
        IShape triangle = new Triangle(3, 4, 5);

        // Act
        // Assert
        Assert.Equal(circle.CalculateArea(), ShapeAreaCalculator.CalculateArea(circle),
            TestsConstants.ComparisonPrecision);
        Assert.Equal(triangle.CalculateArea(), ShapeAreaCalculator.CalculateArea(triangle),
            TestsConstants.ComparisonPrecision);
    }
}