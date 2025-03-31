using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationAndVerificationMethods_Lab1
{
    public class ThomasAlgorithm
    {
        public static double Determinant;

        public static double[] Method(int n, double[] b)
        {
            if (n <= 1)
                throw new ArgumentException();

            double[] a = new double[n]; // Піддіагональ
            double[] c = new double[n]; // Наддіагональ
            double[] d = new double[n]; // Вектор правої частини
            double[] alpha = new double[n];
            double[] beta = new double[n];
            double[] x = new double[n];

            // Заповнюємо коефіцієнти тридіагональної матриці
            for (int i = 0; i < n; i++)
            {
                d[i] = b[i]; // Вектор правої частини
                a[i] = (i > 0) ? 1 : 0; // Піддіагональ
                c[i] = (i < n - 1) ? 2 : 0; // Наддіагональ
            }

            Determinant = 3; // Початкове значення визначника

            // Прямий хід
            alpha[0] = c[0] / 3;
            beta[0] = d[0] / 3;

            for (int i = 1; i < n - 1; i++)
            {
                double z = 3 - a[i] * alpha[i - 1];
                alpha[i] = c[i] / z;
                beta[i] = (d[i] - a[i] * beta[i - 1]) / z;
                Determinant *= z; // Множимо визначник на z
            }
            Determinant *= (3 - a[n - 2] * alpha[n - 2]); // Останній множник для визначника

            beta[n - 1] = (d[n - 1] - a[n - 2] * beta[n - 2]) / (3 - a[n - 2] * alpha[n - 2]);

            // Зворотний хід
            x[n - 1] = beta[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                x[i] = beta[i] - alpha[i] * x[i + 1];
            }

            return x;
        }
    }
}
