using SpecificationAndVerificationMethods_Lab1;
using System;

public class Program
{
    static void ResultOutput(int n)
    {
        double[,] matrix = Matrix.BuildMatrix(n);
        Console.WriteLine("Matrix A:");
        Matrix.PrintMatrix(matrix);

        Console.WriteLine("\nInverse matrix A^(-1):");
        double[,] invertMatrix = Matrix.InverseMatrix(n);
        Matrix.PrintMatrix(invertMatrix);

        double det = ThomasAlgorithm.Determinant;
        Console.WriteLine("\nDeterminant A: " + det);

        Console.WriteLine("\nA norm: " + Matrix.CalculateMatrixNorm(matrix));
        Console.WriteLine("A^-1 norm: " + Matrix.CalculateMatrixNorm(invertMatrix));

        double conditionNumber = Matrix.CalculateConditionNumber(
            Matrix.CalculateMatrixNorm(matrix),
            Matrix.CalculateMatrixNorm(invertMatrix)
        );
        Console.WriteLine("\nCondition number: " + conditionNumber);
    }

    public static void Main()
    {
        int m = -1;
        int n = 0;
        double epsilon = 0;

        while (m != 0)
        {
            int maxAttempts = 5;
            int attempts = 0;

            Console.Write("Enter a number n for the matrix dimension nxn: ");
            while ((!int.TryParse(Console.ReadLine(), out n) || n <= 0) && attempts < maxAttempts)
            {
                Console.WriteLine("Error: n must be a positive integer.");
                attempts++;
                if (attempts == maxAttempts)
                {
                    Console.WriteLine("Too many invalid attempts. Exiting.");
                    return;
                }
                Console.Write("Enter a number n for the matrix dimension nxn: ");
            }

            Console.WriteLine("Choose the method. Enter 1 or 2.");
            Console.WriteLine("1 - Thomas Algorithm");
            Console.WriteLine("2 - Jacobi Method");
            Console.Write("Enter: ");

            if (int.TryParse(Console.ReadLine(), out int selectedMethod) && (selectedMethod == 1 || selectedMethod == 2))
            {
                switch (selectedMethod)
                {
                    case 1:
                        double[] b = new double[n];
                        for (int i = 0; i < n; i++)
                        {
                            b[i] = i + 1;
                        }
                        double[] solution = ThomasAlgorithm.Method(n, b);

                        Console.WriteLine("Result:");
                        foreach (double x_i in solution)
                        {
                            Console.WriteLine(x_i);
                        }

                        Console.WriteLine("\nDeterminant A = " + ThomasAlgorithm.Determinant);
                        Console.WriteLine();

                        ResultOutput(n);
                        break;

                    case 2:
                        Console.Write("Enter the precision: ");
                        while (!double.TryParse(Console.ReadLine(), out epsilon))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number: ");
                        }

                        double[] initialElements = new double[n];
                        Console.WriteLine("Enter the initial approximation (" + n + " elements): ");
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write("Element [" + (i + 1) + "] = ");
                            while (!double.TryParse(Console.ReadLine(), out initialElements[i]))
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number: ");
                            }
                        }

                        var (result, iterationCount, found) = JacobiMethod.Method(epsilon, n, initialElements);

                        if (found)
                        {
                            Console.WriteLine($"The solution of the system with an epsilon of {epsilon} is:");
                            result.PrintVector();
                            Console.WriteLine($"Result found in {iterationCount} iterations.");
                        }
                        else
                        {
                            Console.WriteLine("Solution was not found within 100 iterations.");
                        }

                        ResultOutput(n);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number 1 or 2: ");
                continue;
            }

            Console.Write("Enter 1 to continue, 0 to exit: ");
            if (!int.TryParse(Console.ReadLine(), out m))
            {
                Console.WriteLine("Invalid input. Exiting.");
                break;
            }
        }
    }
}