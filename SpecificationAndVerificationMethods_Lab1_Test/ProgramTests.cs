using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SpecificationAndVerificationMethods_Lab1;

namespace SpecificationAndVerificationMethods_Lab1_Test
{
    public class ProgramTests
    {
        [Fact]
        public void Main_HandlesUserInputCorrectly()
        {
            string input = "3\n1\n0\n";
            using (StringReader sr = new StringReader(input))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                Program.Main();

                string output = sw.ToString();
                Assert.Contains("Enter a number n for the matrix dimension nxn:", output);
                Assert.Contains("Choose the method. Enter 1 or 2.", output);
            }
        }

        [Theory]
        [InlineData("-3\n1\n", "Error: n must be a positive integer.")]
        [InlineData("0\n1\n", "Error: n must be a positive integer.")]
        [InlineData("abc\n1\n", "Error: n must be a positive integer.")]
        [InlineData("-5\n-2\n0\n1\n", "Error: n must be a positive integer.")]
        public void Main_HandlesInvalidN_Input(string input, string expectedErrorMessage)
        {
            using (StringReader sr = new StringReader(input))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                Program.Main();

                string output = sw.ToString();
                Assert.Contains(expectedErrorMessage, output);
            }
        }

        [Fact]
        public void Main_HandlesInvalidMethodChoice()
        {
            string input = "3\n5\n4\nabc\n2\n0\n";
            using (StringReader sr = new StringReader(input))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                Program.Main();

                string output = sw.ToString();
                Assert.Contains("Invalid input. Please enter a number 1 or 2:", output);
            }
        }

        [Fact]
        public void Main_HandlesInvalidEpsilon()
        {
            string input = "3\n2\nabc\n0.001\n1\n1\n1\n0\n";
            using (StringReader sr = new StringReader(input))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                Program.Main();

                string output = sw.ToString();
                Assert.Contains("Invalid input. Please enter a valid number:", output);
            }
        }

        [Fact]
        public void Main_HandlesInvalidInitialVectorInput()
        {
            string input = "3\n2\n0.001\n1\nabc\n2\n3\n0\n";
            using (StringReader sr = new StringReader(input))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                Program.Main();

                string output = sw.ToString();
                Assert.Contains("Invalid input. Please enter a valid number:", output);
            }
        }
    }
}
