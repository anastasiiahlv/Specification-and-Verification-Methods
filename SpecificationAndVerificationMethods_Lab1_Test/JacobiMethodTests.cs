using SpecificationAndVerificationMethods_Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpecificationAndVerificationMethods_Lab1_Test
{
    public class JacobiMethodTests
    {
        [Fact]
        public void NextIterationVector_CalculatesCorrectly()
        {
            Vector inputVector = new Vector(new double[] { 1, 2, 3 });
            Vector expected = new Vector(new double[] { 0.33 * (-2 * 2 + 1),
                                                0.33 * (-1 * 1 - 2 * 3 + 2),
                                                0.33 * (-1 * 2 + 3) });

            Vector result = JacobiMethod.NextIterationVector(inputVector);

            Assert.Equal(expected.elements, result.elements, new DoubleComparer(1e-5));
        }

        [Fact]
        public void VectorNorm_CorrectlyCalculatesMaximumNorm()
        {
            Vector vector = new Vector(new double[] { -7, 3, -1 });
            double expectedNorm = 7;

            double result = Vector.VectorNorm(vector);

            Assert.Equal(expectedNorm, result, new DoubleComparer(1e-5));
        }

        [Fact]
        public void JacobiMethod_ConvergesToSolution()
        {
            double epsilon = 1e-3;
            int n = 3;
            double[] initialElements = { 0, 0, 0 };

            var (result, iterationCount, found) = JacobiMethod.Method(epsilon, n, initialElements);

            Assert.True(found, "Метод повинен знайти розв’язок.");
            Assert.True(iterationCount > 0 && iterationCount <= 100, "Кількість ітерацій має бути в межах 100.");
        }

        [Fact]
        public void JacobiMethod_DoesNotExceedMaxIterations()
        {
            double epsilon = 1e-10;
            int n = 5;
            double[] initialElements = { 100, -100, 50, 20, -50 };

            var (result, iterationCount, found) = JacobiMethod.Method(epsilon, n, initialElements);

            Assert.True(iterationCount <= 100, "Метод не повинен перевищувати 100 ітерацій.");
        }

        [Fact]
        public void JacobiMethod_ReturnsCorrectVectorSize()
        {
            double epsilon = 1e-3;
            int n = 4;
            double[] initialElements = { 1, 2, 3, 4 };

            var (result, iterationCount, found) = JacobiMethod.Method(epsilon, n, initialElements);

            Assert.Equal(n, result.elements.Length);
        }

        [Fact]
        public void Method_ShouldThrowExceptionForZeroEpsilon()
        {
            // Arrange
            double epsilon = 0;
            int n = 3;
            double[] initialElements = { 1, 1, 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => JacobiMethod.Method(epsilon, n, initialElements));
        }
    }

    public class DoubleComparer : IEqualityComparer<double>
    {
        private readonly double _tolerance;

        public DoubleComparer(double tolerance = 1e-5)
        {
            _tolerance = tolerance;
        }

        public bool Equals(double x, double y)
        {
            return Math.Abs(x - y) < _tolerance;
        }

        public int GetHashCode(double obj)
        {
            return obj.GetHashCode();
        }
    }
}
