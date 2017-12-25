using System;
using System.Threading;

namespace RevFunc
{
    class Program
    {
        static void Main(string[] args)
        {

            Reverse F = new Reverse();
            F.Print += PrintEps;//подписка
            Console.WriteLine("sin({0}) = 0,5",F.FindReValue(0.1, 1.3, 0.5, 0.0001, Math.Sin));//как делегат
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("{0}^2 + sin({0}) = 8", F.FindReValue(2.5, 3.5, 8, 0.0001, delegate (double x) { return Math.Pow(x, 2) + Math.Sin(x - 2); })); //анонимный метод
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("{0} * {0}  = 1", F.FindReValue(0, 2, 1, 0.0001, (double x) => x*x));//lamda выражение

            Console.ReadLine();
        }
  
        private static void PrintEps(object sender, GetEps EPS)// обработчик события
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("eps = {0}", EPS.Eps);
            Thread.Sleep(500);
            
        }
    }
}
