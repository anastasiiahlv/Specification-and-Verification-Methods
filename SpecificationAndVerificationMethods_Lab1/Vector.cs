using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationAndVerificationMethods_Lab1
{
    public class Vector
    {
        public double[] elements;

        public Vector(double[] elements)
        {
            this.elements = elements;
        }

        public static Vector VectorSubtraction(Vector x_k_next, Vector x_k)
        {
            if (x_k.elements.Length != x_k.elements.Length)
                throw new IndexOutOfRangeException();

            double[] result = new double[x_k.elements.Length];
            for (int i = 0; i < x_k.elements.Length; i++)
            {
                result[i] = x_k_next.elements[i] - x_k.elements[i];
            }
            return new Vector(result);
        }

        public static double VectorNorm(Vector x)
        {
            double max = Math.Abs(x.elements[0]);
            for (int i = 1; i < x.elements.Length; i++)
            {
                if (Math.Abs(x.elements[i]) > max)
                {
                    max = Math.Abs(x.elements[i]);
                }
            }
            return max;
        }

        public void PrintVector()
        {
            Console.WriteLine("[" + string.Join(", ", elements) + "]");
        }
    }
}
