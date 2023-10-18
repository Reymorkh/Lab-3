using System.Numerics;

namespace Лабораторная_работа_3_консоль
{
    internal class Program
    {
        public static void obrabotka(ref double logResult, ref int fResult, ref int fTemp, ref double xResult, double x, ref double lastResult)
        {
            logResult *= Math.Log(3);
            fResult *= fTemp;
            fTemp++;
            xResult *=x;
            lastResult = logResult / fResult * xResult;
        }

        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            const double a = 0.1, b = 1, k = (b - a) / 10, e = 0.0001;
            const int n = 10;
            double SN = 1, SE = 1, y;
            Console.WriteLine("Условие задачи: y равен 3 в степени x");
            Console.WriteLine("диапазон аргумента: 0,1 <= x <= 1; k = 0.09; n = 10, e = 0.0001");
            Console.WriteLine("s = 1 + (Ln(3)/1!) * x ... (Math.Pow(Ln(3), n) / n!) * (Math.Pow(x, n)");
            for (double x = a; x <= b; x += k)
            {
                Console.Write("X= {0} ", Math.Round(x, 4));
                int fResult = 1, fTemp = 1;
                double lastResult = 1, logResult = 1, xResult = 1;
                for (int i = 1; i <= n; i++)
                {
                    obrabotka(ref logResult, ref fResult, ref fTemp, ref xResult, x, ref lastResult);                  
                    SN += lastResult;
                }
                lastResult = 1;
                logResult = 1;
                fResult = 1;
                fTemp = 1;
                xResult = 1;
                do
                {
                    obrabotka(ref logResult, ref fResult, ref fTemp, ref xResult, x, ref lastResult);
                    SE += lastResult;
                }
                while (lastResult < e);
                y = Math.Pow(3, x);
                Console.WriteLine("SN= {0} SE= {1} Y= {2}", SN, SE, Math.Round(y, 4));
            }
        }
    }
}