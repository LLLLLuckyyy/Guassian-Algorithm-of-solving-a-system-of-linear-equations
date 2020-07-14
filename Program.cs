using System;

namespace Guassian_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            double[,] matrix = new double[n, n];
            double[] vector = new double[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i,j] = rnd.Next(1,10);
                }
                vector[i] = rnd.Next(1,15);
            }

            Display(matrix, vector, n);

            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int k = i + 1; k < n; k++)
                    {
                        matrix[i, k] = matrix[i, k] / matrix[i, i];
                    }
                    vector[i] = vector[i] / matrix[i, i];
                    matrix[i, i] = 1;

                    for (int j = i + 1; j < n; j++)
                    {
                        for (int k = i + 1; k < n; k++)
                        {
                            matrix[j, k] = matrix[j, k] - matrix[i, k] * matrix[j, i];
                        }
                        vector[j] = vector[j] - vector[i] * matrix[j, i];
                        matrix[j, i] = 0;
                    }
                }
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return;
            }

            Display(matrix, vector, n);

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = n - 1; j > i; j--)
                {
                    vector[i] -= vector[j] * matrix[i, j];
                    matrix[i, j] -= matrix[j, j] * matrix[i, j];
                }
            }

            Display(matrix, vector, n);
        }



        static void Display(double[,] matrix,double[] vector, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine("=\t" + vector[i]);
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n\n\n");
        }
    }
}
