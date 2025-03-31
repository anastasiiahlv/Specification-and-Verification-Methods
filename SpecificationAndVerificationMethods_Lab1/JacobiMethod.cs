using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationAndVerificationMethods_Lab1
{
    public class JacobiMethod
    {
        /*public static void Method(double epsilon, int n, double[] initialElements)
        {
            Vector x_k = new Vector(initialElements);
            Vector x_k_next;
            Vector vectorSubtraction;
            Vector result = new Vector(new double[n]);

            double norm;
            int iterationCount = 0;
            bool isResult = false;

            for (int i = 1; i <= 100; i++)
            {
                x_k_next = NextIterationVector(x_k);
                vectorSubtraction = Vector.VectorSubtraction(x_k_next, x_k);
                norm = Vector.VectorNorm(vectorSubtraction);

                Console.WriteLine(" ----------------------------------------------------------");
                Console.WriteLine($"{i} iteration");
                Console.Write("x_k: ");
                x_k_next.PrintVector();
                Console.Write("x_k_prev: ");
                x_k.PrintVector();
                Console.WriteLine();

                Console.WriteLine("x_k_next - x_k");
                vectorSubtraction.PrintVector();
                Console.WriteLine();

                Console.WriteLine("Vector norm: " + norm);
                Console.WriteLine(" ----------------------------------------------------------");

                x_k = x_k_next;

                if (norm <= epsilon && !isResult)
                {
                    iterationCount = i;
                    isResult = true;
                    result = x_k_next;
                    break;
                }
            }

            if (isResult)
            {
                Console.WriteLine($"The solution of the system with an epsilon of {epsilon} is:");
                result.PrintVector();
                Console.WriteLine($"Result is found during {iterationCount} iteration");
            }
            else
            {
                Console.WriteLine("Solution is not found within 100 iterations.");
            }
        }*/

        public static (Vector result, int iterationCount, bool found) Method(double epsilon, int n, double[] initialElements)
        {
            if (epsilon == 0)
                throw new ArgumentException();

            Vector x_k = new Vector(initialElements);
            Vector x_k_next;
            Vector vectorSubtraction;
            Vector result = new Vector(new double[n]);

            double norm;
            int iterationCount = 0;
            bool isResult = false;

            for (int i = 1; i <= 100; i++)
            {
                x_k_next = NextIterationVector(x_k);
                vectorSubtraction = Vector.VectorSubtraction(x_k_next, x_k);
                norm = Vector.VectorNorm(vectorSubtraction);

                x_k = x_k_next;

                if ((norm <= epsilon || norm == 0) && !isResult)
                {
                    iterationCount = i;
                    isResult = true;
                    result = x_k_next;
                    break;
                }
            }

            return (result, iterationCount, isResult);
        }

        public static Vector NextIterationVector(Vector x_k)
        {
            double[] newElements = new double[x_k.elements.Length];

            for (int i = 0; i < x_k.elements.Length; i++)
            {
                double left = (i > 0) ? -1 * x_k.elements[i - 1] : 0;
                double right = (i < x_k.elements.Length - 1) ? -2 * x_k.elements[i + 1] : 0;
                newElements[i] = 0.33 * (left + right + (i + 1));
            }

            return new Vector(newElements);
        }
    }
}
