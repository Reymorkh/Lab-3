using System.Numerics;

namespace Лабораторная_работа_3_консоль
{
    internal class Program
    {
        public static int Factorial(int n)
        {
            int factorial =1;
            for (int i = 1; i != n; i++)
                factorial *= i;
            return factorial;

        }
        public static double Function(int i, double x)
        {
            double result = Math.Pow(Math.Log(3), i) / Factorial(i) * Math.Pow(x, i);
            return result;
        }

        static void Main(string[] args)
        {
            const double a = 0.1, b = 1, k = (b - a) / 10, e = 0.0001;
            const int n = 10;
            double SN = 1, SE = 1, y;
            Console.WriteLine("Условие задачи: y равен 3 в степени x");
            Console.WriteLine("диапазон аргумента: 0,1 <= x <= 1; k = 0.09; n = 10, e = 0.0001");
            Console.WriteLine("s = 1 + (Ln(3)/1!) * x ... (Math.Pow(Ln(3), n) / n!) * (Math.Pow(x, n)");
            Console.WriteLine();


            for (double x = a; x <= b; x += k)
            {
                Console.Write("X= {0} ", Math.Round(x, 4));
                int j = 1;
                for (int i = 1; i <= n; i++)
                {
                    j *= i;
                    double logResult = 1;
                    for (int z = 1; z <= i; z++)
                        logResult *= Math.Log(3);
                    SN += logResult / j * x;

                    if (logResult / j * x < e)
                        SE += Math.Log(3) / j * x;

                }

               

                y = Math.Pow(3, x);
                Console.WriteLine("SN= {0} SE= {1} Y= {2}", SN, SE, y);
                SN = 1;
                SE = 1;
            }            
        }
    }
}