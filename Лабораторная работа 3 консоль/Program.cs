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
      Console.Write("Условие задачи: y равен 3 в степени x\nдиапазон аргумента: 0,1 <= x <= 1; k = 0.09; n = 10, e = 0.0001\n");
      Console.WriteLine("s = 1 + (Ln(3)/1!) * x ... (Math.Pow(Ln(3), n) / n!) * (Math.Pow(x, n)\n");
      for (double x = a; x <= b; x += k)
      {
        double SN = 1, SE = 1, y;

        int factorialResult = 1, factorialTemp = 1;
        double lastResult = 1, log = Math.Log(3), localLogResult = 1, xResult = 1;

        for (int i = 1; i <= n; i++) //вычисление степенного ряда с известной длиной (n)
        {
          localLogResult *= log;
          factorialResult *= i;
          xResult *= x;
          SN += localLogResult / (double)factorialResult * xResult; //вычисление куска рекуррента //итоговая переменная для общей суммы
        }

        localLogResult = 1;
        factorialResult = 1;
        xResult = 1;
        double tempResult;

        do //вычисление степенного ряда для заданной точности (e)
        {
          tempResult = lastResult;
          localLogResult *= log;
          factorialResult *= factorialTemp;
          xResult *= x;
          lastResult = localLogResult / (double)factorialResult * xResult;
          SE += lastResult;
          factorialTemp++;
        }
        while (Math.Abs(tempResult - lastResult) > e);

        y = Math.Pow(3, x);

        Console.WriteLine($"X= {x:f4} SN= {SN:f4} SE= {SE:f4} Y= {y:f4}");
        //Console.Write(" счётчик прохода для цикла SE: " + counter);
      }
    }
  }
}