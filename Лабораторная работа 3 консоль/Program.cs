namespace Лабораторная_работа_3_консоль
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.Clear();

      const double a = 0.1, b = 1, k = (b - a) / 10, e = 0.0001;
      const int n = 10;
      double SN = 1, SE = 1, y;
      int counter;
      Console.Write("Условие задачи: y равен 3 в степени x\nдиапазон аргумента: 0,1 <= x <= 1; k = 0.09; n = 10, e = 0.0001\n");
      Console.WriteLine("s = 1 + (Ln(3)/1!) * x ... (Math.Pow(Ln(3), n) / n!) * (Math.Pow(x, n)\n");

      for (double x = a; x <= b; x += k)
      {
        counter = 0;
        Console.Write($"X= {x:f4} ");

        int factorialResult = 1, factorialTemp = 1;
        double lastResult, logResult = 1, xResult = 1;

        do
        {
          logResult *= Math.Log(3);
          factorialResult *= factorialTemp;
          factorialTemp++;
          xResult *= x;
          lastResult = logResult / factorialResult * xResult;
          SN += lastResult; //вычисление для заданной длины
          if (lastResult > e)
            SE += lastResult; //вычисление степенного ряда для заданной точности (e)
          counter++;
        }
        while (lastResult > e || counter != n);

        y = Math.Pow(3, x);
        Console.WriteLine($"SN= {SN:f4} SE= {SE:f4} Y= {y:f4}");
      }
    }
  }
}