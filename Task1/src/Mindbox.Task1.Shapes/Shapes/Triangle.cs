using Mindbox.Task1.Shapes.Interfaces;

namespace Mindbox.Task1.Shapes.Shapes;

/// <summary>
/// Represents a triangle with three sides.
/// </summary>
public class Triangle : IShape
{
    /// <summary>
    /// Gets the length of side A of the triangle.
    /// </summary>
    public double SideA { get; }

    /// <summary>
    /// Gets the length of side B of the triangle.
    /// </summary>
    public double SideB { get; }

    /// <summary>
    /// Gets the length of side C of the triangle.
    /// </summary>
    public double SideC { get; }
    
    private double? _area;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Triangle"/> class with the specified sides.
    /// </summary>
    /// <param name="sideA">Length of side A. Must be greater than zero.</param>
    /// <param name="sideB">Length of side B. Must be greater than zero.</param>
    /// <param name="sideC">Length of side C. Must be greater than zero.</param>
    /// <exception cref="ArgumentException">Thrown when any side is less than or equal to zero,
    /// or when the provided sides do not form a valid triangle.</exception>
    public Triangle(double sideA, double sideB, double sideC)
    {
        ValidateSide(sideA, nameof(sideA));
        ValidateSide(sideB, nameof(sideB));
        ValidateSide(sideC, nameof(sideC));
        ValidateTriangle(sideA, sideB, sideC);

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }
    
    /// <summary>
    /// Calculates the area of the triangle using Heron's formula.
    /// </summary>
    /// <returns>The area of the triangle.</returns>
    public double CalculateArea()
    {
        if (_area is not null)
        {
            return _area.Value;
        }
        
        double halfPerimeter = GetPerimeter() / 2;

        _area = Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) *
                          (halfPerimeter - SideC));

        return _area.Value;
    }
    
    /// <summary>
    /// Determines if the triangle is a right triangle.
    /// </summary>
    /// <returns>True if the triangle is a right triangle; otherwise, false.</returns>
    public bool IsRightTriangle()
    {
        double[] sides = [SideA, SideB, SideC];
        Array.Sort(sides);
        return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 1e-10;
    }

    /// <summary>
    /// Returns the sides of the triangle as a read-only collection.
    /// </summary>
    /// <returns>A read-only list containing the lengths of the sides of the triangle.</returns>
    public IReadOnlyList<double> GetSides()
    {
        return new List<double> { SideA, SideB, SideC }.AsReadOnly();
    }
    
    /// <summary>
    /// Determines if the provided sides form a valid triangle.
    /// </summary>
    /// <param name="sideA">Length of side A.</param>
    /// <param name="sideB">Length of side B.</param>
    /// <param name="sideC">Length of side C.</param>
    /// <returns>True if the sides form a valid triangle; otherwise, false.</returns>
    private static void ValidateTriangle(double sideA, double sideB, double sideC)
    {
        if (sideA + sideB < sideC || sideA + sideC < sideB || sideB + sideC < sideA)
        {
            throw new ArgumentException(
                $"""
                 The provided sides do not form a valid triangle.
                 Provided sides: sideA = {sideA}, sideB = {sideB}, sideC = {sideC}
                 """);
        }
    }
    
    /// <summary>
    /// Validates that a side is greater than zero.
    /// </summary>
    /// <param name="side">The length of the side to validate.</param>
    /// <param name="sideName">The name of the parameter representing the side.</param>
    /// <exception cref="ArgumentException">Thrown when the side is less than or equal to zero.</exception>
    private static void ValidateSide(double side, string sideName)
    {
        if (side <= 0)
        {
            throw new ArgumentException($"{sideName} must be greater than zero. Provided value: {side}");
        }
    }
    
    /// <summary>
    /// Calculates the perimeter of the triangle by summing the lengths of its three sides.
    /// </summary>
    /// <returns>The perimeter of the triangle.</returns>
    private double GetPerimeter()
    {
        return SideA + SideB + SideC;
    }
}