using Mindbox.Task1.Shapes.Shapes;

namespace Mindbox.Task1.Shapes.UnitTests.ShapesTests;

public class TriangleTests
{
    [Theory]
    [InlineData(2, 3, 4, 2.9047375096555625)]
    [InlineData(3, 5, 6, 7.483314773547883)]
    public void CalculateArea_Success(double sideA, double sideB, double sideC, double expected)
    {
        // Arrange
        Triangle triangle = new(sideA, sideB, sideC);
        
        // Act
        // Assert
        Assert.Equal(expected, triangle.CalculateArea(), TestsConstants.ComparisonPrecision);
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 4, 5, false)]
    public void IsRightTriangle_Success(double sideA, double sideB, double sideC, bool expected)
    {
        // Arrange
        Triangle triangle = new(sideA, sideB, sideC);
        
        // Act
        // Assert
        Assert.Equal(expected, triangle.IsRightTriangle());
    }
    
    [Fact]
    public void Constructor_Success()
    {
        // Arrange
        double expectedSideA = 3;
        double expectedSideB = 4;
        double expectedSideC = 5;

        // Act
        Triangle triangle = new(expectedSideA, expectedSideB, expectedSideC);

        // Assert
        Assert.Equal(expectedSideA, triangle.SideA);
        Assert.Equal(expectedSideB, triangle.SideB);
        Assert.Equal(expectedSideC, triangle.SideC);
    }
    
    [Fact]
    public void GetSides_Success()
    {
        // Arrange
        double expectedSideA = 3;
        double expectedSideB = 4;
        double expectedSideC = 5;

        Triangle triangle = new(expectedSideA, expectedSideB, expectedSideC);

        // Act
        IReadOnlyList<double> sides = triangle.GetSides();

        // Assert
        Assert.Equal(expectedSideA, sides[0]);
        Assert.Equal(expectedSideB, sides[1]);
        Assert.Equal(expectedSideC, sides[2]);
    }
    
    [Theory]
    [InlineData(1,1,3)]
    public void Constructor_InvalidTriangle_ArgumentException(double sideA, double sideB, double sideC)
    {
        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }
    
    [Theory]
    [InlineData(0, 2, 1)]
    [InlineData(5, -4, 1)]
    [InlineData(2, 3, -1)]
    public void Constructor_InvalidSides_ArgumentException(double sideA, double sideB, double sideC)
    {
        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }
}