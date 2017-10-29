using System;
using ClassComplex;

namespace ComplexNumb
{
    class Program
    {
        static void Main()
        {
            #region Красивый вывод
            Console.WriteLine("Вывод:");
            Complex a = new Complex(1, -1);
            Complex b = new Complex(1, 1);
            Console.Write("z1 = {0}\nz2 = {1}\n", a, b);
            a.Re = 0;
            b.Re = 0;
            Console.Write("z1 = {0}\nz2 = {1}\n",a,b);
            a.Im = 0;
            b.Im = 0;
            b.Re = 5;
            Console.Write("z1 = {0}\nz2 = {1}\n", a, b);
            a.Re = Math.PI;
            a.Im = -Math.E;
            Console.Write("z1 = {0}\nz2 = {1}\n", a, b);
            Console.WriteLine("----------------------------------------------");
            #endregion

            #region Z = f(Mod, Arg)
            Console.WriteLine("Z = f(Mod, Arg)");
            Console.WriteLine("Arg = Pi/4 + 2*Pi   Mod = Sqrt(8)");
            Console.WriteLine("Z = {0}\n" ,Complex.CreateByArgMod(Math.Sqrt(8), Math.PI / 4 + 2*Math.PI));
            Console.WriteLine("Arg = -Pi/4   Mod = Sqrt(20)");
            Console.WriteLine("Z = {0}\n", Complex.CreateByArgMod(Math.Sqrt(50), -Math.PI / 4));
            Console.WriteLine("Arg = 0   Mod = 4");
            Console.WriteLine("Z = {0}\n", Complex.CreateByArgMod(4, 0));
            Console.WriteLine("Arg = Pi   Mod = 4");
            Console.WriteLine("Z = {0}\n", Complex.CreateByArgMod(4, Math.PI));
            Console.WriteLine("Arg = Pi/4   Mod = 0");
            Console.WriteLine("Z = {0}", Complex.CreateByArgMod(0, Math.PI / 4));
            Console.WriteLine("Arg = Pi/4   Mod = -1");
            Console.WriteLine("Z = {0}", Complex.CreateByArgMod(-1, Math.PI / 4));
            Console.WriteLine("----------------------------------------------");
            #endregion

            #region Арифм операции (+, -, *, /)
            Console.WriteLine("Арифм операции:");
            a.Re = 5; a.Im = 13;
            b.Re = 7; b.Im = -15;
            Console.Write("Re(a) = {0},  Im(a) = {1};\nRe(b) = {2},  Im(b) = {3};\n",a.Re,a.Im,b.Re,b.Im);
            Console.WriteLine("a + b = {0}", a + b);
            Console.WriteLine("a - b = {0}", a - b);
            Console.WriteLine("a * b = {0}", a * b);
            Console.WriteLine("a / b = {0}", a / b);
            Console.WriteLine("----------------------------------------------");
            #endregion

            #region Свойства
            a.Re = 7; a.Im = -4;
            Console.WriteLine("Свойства:");
            Console.WriteLine("z = {0}",a);
            Console.WriteLine("z.Re = {1},   z.Im = {0}", -12, 5);
            a.Re = -12; a.Im = 5;
            Console.WriteLine("New z = {0}", a);
            Console.WriteLine("|z| = {0}", a.Mod);
            Console.WriteLine("Arg(z) = {0}", a.Arg);
            Console.WriteLine("----------------------------------------------");
            #endregion

            #region Преобразование типов
            Console.WriteLine("Преобразование типов:");
            Console.WriteLine("1) явное");
            Console.WriteLine("   z = {0}, (double)z = {1}, Type((double)z) = {2};", a, (double)a, ((double)a).GetType());
            Console.WriteLine("2) неявное");
            Console.WriteLine("   x = {0}, Type(x) = {4};\n   z = {1}, (Re(z), Im(z)) = ({2}, {3}), Type(z) = {5}", 17, a = 17, a.Re, a.Im, ((double)17).GetType(), a.GetType());
            Console.WriteLine("----------------------------------------------");
            #endregion

            #region Сравнение
            Console.WriteLine("Сравнение z1 ? z2");
            Console.WriteLine("{0} = {1} ? {2}", a, b, a == b);
            Console.WriteLine("{0} = null ? {1}", a, a == null);
            Console.WriteLine("Одинаковые z равны ? {0}", new Complex(Math.PI, Math.E) == new Complex(Math.PI, Math.E));
            Console.ReadLine();
            Console.WriteLine("----------------------------------------------");
            #endregion

        }
    }
}
