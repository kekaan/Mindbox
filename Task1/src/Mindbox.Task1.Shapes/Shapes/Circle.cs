using Mindbox.Task1.Shapes.Interfaces;

namespace Mindbox.Task1.Shapes.Shapes;

/// <summary>
/// Represents a circle with a specified radius.
/// </summary>
public class Circle : IShape
{
    /// <summary>
    /// Gets the radius of the circle.
    /// </summary>
    public double Radius { get; }
    
    private double? _area;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class.
    /// </summary>
    /// <param name="radius">The radius of the circle. Must be greater than zero.</param>
    /// <exception cref="ArgumentException">Thrown when radius is less than or equal to zero.</exception>
    public Circle(double radius)
    {
        ValidateRadius(radius);

        Radius = radius;
    }
    
    /// <summary>
    /// Calculates the area of the circle.
    /// </summary>
    /// <returns>The area of the circle.</returns>
    public double CalculateArea()
    {
        _area ??= Math.PI * Math.Pow(Radius, 2);

        return _area.Value;
    }
    
    /// <summary>
    /// Validates that the radius is greater than zero.
    /// </summary>
    /// <param name="radius">The radius to validate.</param>
    /// <exception cref="ArgumentException">Thrown when the radius is less than or equal to zero.</exception>
    private static void ValidateRadius(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException($"Radius must be greater than zero. Provided radius: {radius}");
        }
    }
}