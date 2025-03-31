using System;
using SpecificationAndVerificationMethods_Lab1;
using Xunit;

namespace SpecificationAndVerificationMethods_Lab1_Test
{
    public class VectorTestFixture
    {
        public Vector VectorA { get; }
        public Vector VectorB { get; }

        public VectorTestFixture()
        {
            VectorA = new Vector(new double[] { 1, 2, 3 });
            VectorB = new Vector(new double[] { 4, 5, 6 });
        }
    }

    public class VectorTests : IClassFixture<VectorTestFixture>
    {
        private readonly Vector _vectorA;
        private readonly Vector _vectorB;

        public VectorTests(VectorTestFixture fixture)
        {
            _vectorA = fixture.VectorA;
            _vectorB = fixture.VectorB;
        }

        [Fact]
        public void VectorSubtraction_ShouldReturnCorrectResult()
        {
            // Act
            Vector result = Vector.VectorSubtraction(_vectorB, _vectorA);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.elements.Length);
            Assert.Equal(new double[] { 3, 3, 3 }, result.elements);
            Assert.DoesNotContain(0, result.elements);
        }

        [Fact]
        public void VectorNorm_ShouldReturnMaxAbsoluteValue()
        {
            // Act
            double norm = Vector.VectorNorm(_vectorA);

            // Assert
            Assert.Equal(3, norm);
        }

        [Fact]
        public void VectorNorm_ShouldHandleNegativeValuesCorrectly()
        {
            // Arrange
            Vector negativeVector = new Vector(new double[] { -2, -5, -1 });

            // Act
            double norm = Vector.VectorNorm(negativeVector);

            // Assert
            Assert.Equal(5, norm);
        }

        [Theory]
        [InlineData(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 }, new double[] { 3, 3, 3 })]
        [InlineData(new double[] { 10, 20, 30 }, new double[] { 5, 10, 15 }, new double[] { -5, -10, -15 })]
        public void VectorSubtraction_ShouldWorkForVariousInputs(double[] arrA, double[] arrB, double[] expected)
        {
            // Arrange
            Vector vecA = new Vector(arrA);
            Vector vecB = new Vector(arrB);

            // Act
            Vector result = Vector.VectorSubtraction(vecB, vecA);

            // Assert
            Assert.Equal(expected, result.elements);
        }

        [Fact]
        public void VectorSubtraction_ShouldThrowExceptionForMismatchedLengths()
        {
            // Arrange
            Vector vecShort = new Vector(new double[] { 1, 2 });
            Vector vecLong = new Vector(new double[] { 1, 2, 3 });

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => Vector.VectorSubtraction(vecShort, vecLong));
        }
    }
}