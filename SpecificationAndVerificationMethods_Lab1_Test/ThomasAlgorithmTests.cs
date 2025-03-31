using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SpecificationAndVerificationMethods_Lab1;

namespace SpecificationAndVerificationMethods_Lab1_Test
{
    public class ThomasAlgorithmTests
    {
        [Fact]
        public void Method_ShouldSetCorrectDeterminant()
        {
            // Arrange
            int n = 3;
            double[] b = { 6, 9, 12 };

            // Act
            ThomasAlgorithm.Method(n, b);
            double determinant = ThomasAlgorithm.Determinant;

            // Assert
            Assert.True(determinant > 0);
        }

        [Fact]
        public void Method_ShouldThrowException_WhenNIsZeroOrNegative()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => ThomasAlgorithm.Method(0, new double[] { }));
            Assert.Throws<ArgumentException>(() => ThomasAlgorithm.Method(-3, new double[] { 1, 2, 3 }));
        }
    }
}
