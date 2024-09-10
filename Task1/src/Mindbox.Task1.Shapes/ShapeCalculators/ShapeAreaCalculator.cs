using Mindbox.Task1.Shapes.Interfaces;

namespace Mindbox.Task1.Shapes.ShapeCalculators;

/// <summary>
/// Provides a method to calculate the area of any shape implementing the <see cref="IShape"/> interface.
/// </summary>
public static class ShapeAreaCalculator
{
    /// <summary>
    /// Calculates the area of the specified shape.
    /// </summary>
    /// <param name="shape">The shape to calculate the area for.</param>
    /// <returns>The area of the shape.</returns>
    public static double CalculateArea(IShape shape) => shape.CalculateArea();
}