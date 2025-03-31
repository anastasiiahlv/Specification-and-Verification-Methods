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
    }
}
