using System;
using System.IO;
using System.Reflection;
using System.Numerics;

namespace ComplexReflection
{
    class Program
    {
        static void Main()
        {

            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "ClassComplex.dll")))
            {
                Console.WriteLine("Нашли сборку\n");
                
                //загрузка сборки
                Assembly assembly = Assembly.Load("ClassComplex");

                //получим тип
                Type type = assembly.GetType("ClassComplex.Complex");

                //различные методы:
                MethodInfo frompolar = type.GetMethod("CreateByArgMod");
                MethodInfo plus = type.GetMethod("op_Addition", new Type[] { type, type });
                MethodInfo mult = type.GetMethod("op_Multiply", new Type[] { type, type });
                MethodInfo mult2 = type.GetMethod("op_Multiply", new Type[] { type, typeof(double) });
                MethodInfo mod = type.GetMethod("get_Mod");
                MethodInfo arg = type.GetMethod("get_Arg");
                MethodInfo Out = type.GetMethod("ToString");


                //создадим числа [x, y]
                object x = Activator.CreateInstance(type, 2, 3);
                object y = frompolar.Invoke(null, new object[] { 14, Math.PI / 4 });

                //считаем (x + y)^2/12
                object res = mult2.Invoke(null, new object[] { mult.Invoke(null, new object[] { plus.Invoke(null, new object[] { x, y }), plus.Invoke(null, new object[] { x, y }) }), (double)1 / 12 });


                Console.WriteLine("(x + y)^2", res);
                Console.WriteLine("----------   = {0}       (Arg, Mod) = ({1}, {2})", res, arg.Invoke(res, null), mod.Invoke(res, null));
                Console.WriteLine("    12   ");
                Console.ReadLine();

                //dynamic
                dynamic a = Activator.CreateInstance(type, 4, 1);
                dynamic b = frompolar.Invoke(null, new object[] { 14, Math.PI / 4 });

                dynamic c = (a * a + b * b) * (a * a + b * b) / (((double)3) * b);

                Console.WriteLine("(a*a + b*b)^2");
                Console.WriteLine("-------------- = {0}       (Arg, Mod) = ({1}, {2})", c, arg.Invoke(c, null), mod.Invoke(c, null));
                Console.WriteLine("      3b     \n");
                Console.ReadLine();


            }
            else
            {
                Console.WriteLine("Сборка не найдена");
                Complex e = new Complex(1, 2);
                Complex f = Complex.FromPolarCoordinates(2, Math.PI/8);
                Console.WriteLine("34 + e^f = {0}", 34 + Complex.Pow(e, f));
                Console.ReadLine();

            }
        }
    }
}
