# Shapes Library

## Описание

Библиотека предоставляет функциональность для расчета площади геометрических фигур. На данный момент поддерживаются:
- Круг (Circle)
- Треугольник (Triangle)

### Основные функции:
- Вычисление площади фигуры.
- Проверка на то, является ли треугольник прямоугольным.
- Кеширование результата вычисления площади (вычисляется только один раз).
- Возможность легко добавлять другие фигуры.

## Требования

- .NET 8.0
- xUnit для тестирования

## Установка

Для интеграции библиотеки в проект:
1. Склонируйте репозиторий или скачайте исходный код.
2. Добавьте библиотеку в ваш проект:
```bash
dotnet add reference /path/to/Mindbox.Task1.Shapes.csproj
```

## Использование

### Circle (Круг)

Для создания круга и вычисления его площади:

```csharp
Circle circle = new(5);
double area = circle.CalculateArea();
Console.WriteLine($"Площадь круга: {area}");
```

### Triangle (Треугольник)
Для создания треугольника и вычисления его площади:
```csharp
Triangle triangle = new(3, 4, 5);
double area = triangle.CalculateArea();
Console.WriteLine($"Площадь треугольника: {area}");
```
Для проверки, является ли треугольник прямоугольным:
```csharp
bool isRightTriangle = triangle.IsRightTriangle();
Console.WriteLine($"Прямоугольный треугольник: {isRightTriangle}");
```
Для получения сторон треугольника:
```csharp
IReadOnlyList<double> sides = triangle.GetSides();
Console.WriteLine($"Стороны треугольника: {string.Join(", ", sides)}");
```

## Тестирование
Для запуска юнит-тестов используется xUnit. Тесты находятся в проекте Mindbox.Task1.Shapes.UnitTests.

Запуск тестов:
```bash
dotnet test
```

## Расширение библиотеки
Добавление новых фигур происходит через реализацию интерфейса IShape. Пример:
```csharp
public class Square : IShape
{
    public double Side { get; }

    public Square(double side)
    {
        if (side <= 0)
            throw new ArgumentException("Side length must be greater than zero.");

        Side = side;
    }

    public double CalculateArea()
    {
        return Math.Pow(Side, 2);
    }
}
```