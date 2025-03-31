using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationAndVerificationMethods_Lab1
{
    public class Matrix
    {
        public static double[,] BuildMatrix(int n)
        {
            if (n <= 0)
                throw new ArgumentException();

            double[,] matrix = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 3; // Головна діагональ
                    }
                    else if (j == i + 1)
                    {
                        matrix[i, j] = 2; // Перша діагональ праворуч
                    }
                    else if (j == i - 1)
                    {
                        matrix[i, j] = 1; // Перша діагональ ліворуч
                    }
                    else
                    {
                        matrix[i, j] = 0; // Інші елементи
                    }
                }
            }

            return matrix;
        }

        public static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0,6:F2} ", matrix[i, j]);
                }
                Console.WriteLine("|");
            }
        }

        public static double CalculateConditionNumber(double a, double b)
        {
            return a * b;
        }

        public static double CalculateMatrixNorm(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            double maxColumnSum = 0;

            for (int j = 0; j < cols; j++)
            {
                double columnSum = 0;

                for (int i = 0; i < rows; i++)
                {
                    columnSum += Math.Abs(matrix[i, j]);
                }

                maxColumnSum = Math.Max(maxColumnSum, columnSum);
            }

            return maxColumnSum;
        }

        public static double[,] InverseMatrix(int n)
        {
            if (n <= 0)
                throw new ArgumentException();
            
            double[,] inverseMatrix = new double[n, n];

            for (int k = 0; k < n; k++)
            {
                double[] e = new double[n];
                e[k] = 1.0;

                double[] column = ThomasAlgorithm.Method(n, e);

                for (int i = 0; i < n; i++)
                {
                    inverseMatrix[i, k] = column[i];
                }
            }

            return inverseMatrix;
        }
    }
}
