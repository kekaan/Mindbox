namespace Mindbox.Task1.Shapes.Interfaces;

/// <summary>
/// Represents a geometric shape that can calculate its area.
/// </summary>
public interface IHasArea
{
    /// <summary>
    /// Calculate the area of the shape.
    /// </summary>
    /// <returns>Area of the shape.</returns>
    double CalculateArea();
}