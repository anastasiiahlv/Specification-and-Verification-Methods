using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SpecificationAndVerificationMethods_Lab1;

namespace SpecificationAndVerificationMethods_Lab1_Test
{
    public class MatrixTestFixture
    {
        public double[,] SampleMatrix3x3 { get; }
        public double[,] SampleMatrix4x4 { get; }

        public MatrixTestFixture()
        {
            SampleMatrix3x3 = Matrix.BuildMatrix(3);
            SampleMatrix4x4 = Matrix.BuildMatrix(4);
        }
    }

    public class MatrixTests : IClassFixture<MatrixTestFixture>
    {
        private readonly double[,] _matrix3x3;
        private readonly double[,] _matrix4x4;

        public MatrixTests(MatrixTestFixture fixture)
        {
            _matrix3x3 = fixture.SampleMatrix3x3;
            _matrix4x4 = fixture.SampleMatrix4x4;
        }

        [Fact]
        public void BuildMatrix_ShouldReturnCorrectSize()
        {
            // Act
            double[,] matrix = Matrix.BuildMatrix(5);

            // Assert
            Assert.Equal(5, matrix.GetLength(0));
            Assert.Equal(5, matrix.GetLength(1));
        }

        [Fact]
        public void BuildMatrix_ShouldHaveCorrectDiagonalValues()
        {
            // Act & Assert
            Assert.Equal(3, _matrix3x3[0, 0]); // Головна діагональ
            Assert.Equal(2, _matrix3x3[0, 1]); // Верхня діагональ
            Assert.Equal(1, _matrix3x3[1, 0]); // Нижня діагональ
            Assert.Equal(0, _matrix3x3[0, 2]); // Решта елементів
        }

        [Fact]
        public void CalculateConditionNumber_ShouldReturnCorrectValue()
        {
            // Act
            double result = Matrix.CalculateConditionNumber(2.0, 5.0);

            // Assert
            Assert.Equal(10.0, result);
        }

        [Theory]
        [InlineData(1.5, 2.0, 3.0)]
        [InlineData(3.0, 3.0, 9.0)]
        [InlineData(0.0, 5.0, 0.0)]
        public void CalculateConditionNumber_ShouldBeCorrect(double a, double b, double expected)
        {
            // Act
            double result = Matrix.CalculateConditionNumber(a, b);

            // Assert
            Assert.Equal(expected, result, 5);
        }

        [Fact]
        public void CalculateMatrixNorm_ShouldReturnCorrectNorm()
        {
            // Act
            double norm = Matrix.CalculateMatrixNorm(_matrix3x3);

            // Assert
            Assert.Equal(6, norm);
        }

        [Fact]
        public void BuildMatrix_ShouldThrowExceptionForNegativeSize()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => Matrix.InverseMatrix(-3));
        }

        [Fact]
        public void InverseMatrix_ShouldThrowExceptionForNegativeSize()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => Matrix.InverseMatrix(-3));
        }

        [Fact]
        public void InverseMatrix_ShouldReturnSquareMatrix()
        {
            // Act
            double[,] inverse = Matrix.InverseMatrix(3);

            // Assert
            Assert.Equal(3, inverse.GetLength(0));
            Assert.Equal(3, inverse.GetLength(1));
        }
    }
}
