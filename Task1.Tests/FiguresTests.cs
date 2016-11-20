using System;
using System.Collections;
using NUnit.Framework;
using Task1.Logic;

namespace Task1.Tests
{
    [TestFixture]
    public class FiguresTests
    {
        private readonly double _epsilon =
            double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"]);

        private static readonly Circle Circle = new Circle(0.025);
        private static readonly Rectangle Rectangle = new Rectangle(0.025, 1.245);
        private static readonly Triangle Triangle = new Triangle(0.025, 1.245, 1.25);
        private static readonly Square Square = new Square(0.025);

        private const double ExpectedAreaCircle = 0.0019634954;
        private const double ExpectedAreaRectangle = 0.031125;
        private const double ExpectedAreaTriangle = 0.0152779252518;
        private const double ExpectedAreaSquare = 0.000625;

        private const double ExpectedPerimeterCircle = 0.1570796327;
        private const double ExpectedPerimeterRectangle = 2.54;
        private const double ExpectedPerimeterTriangle = 2.52;
        private const double ExpectedPerimeterSquare = 0.1;

        [Test, TestCaseSource(typeof (AreaTest), nameof(AreaTest.AreaTestCases))]
        public void AreaTests(Figure figure, double expected)
            => Assert.Less(Math.Abs(figure.Area() - expected), _epsilon);

        [Test, TestCaseSource(typeof (PerimaterTest), nameof(PerimaterTest.PerimeterTestCases))]
        public void PerimeterTests(Figure figure, double expected)
            => Assert.Less(Math.Abs(figure.Perimeter() - expected), _epsilon);

        public class AreaTest
        {
            public static IEnumerable AreaTestCases
            {
                get
                {
                    yield return new TestCaseData(Circle, ExpectedAreaCircle);
                    yield return new TestCaseData(Rectangle, ExpectedAreaRectangle);
                    yield return new TestCaseData(Triangle, ExpectedAreaTriangle);
                    yield return new TestCaseData(Square, ExpectedAreaSquare);
                }
            }
        }

        public class PerimaterTest
        {
            public static IEnumerable PerimeterTestCases
            {
                get
                {
                    yield return new TestCaseData(Circle, ExpectedPerimeterCircle);
                    yield return new TestCaseData(Rectangle, ExpectedPerimeterRectangle);
                    yield return new TestCaseData(Triangle, ExpectedPerimeterTriangle);
                    yield return new TestCaseData(Square, ExpectedPerimeterSquare);
                }
            }
        }
    }
}
