using System;
using ClassComplex;
namespace GenericStack
{
    
    class Program
    {
        
        static void CreateByArray<T>(Stack<T> stack, T[] mass)
            where T: ICloneable
        {
            foreach (T elem in mass)
                stack.Push(elem);
        }

        

        static void Main()
        {
            Stack<string> StackStr = new Stack<string>();
            Stack<Complex> StackComplex = new Stack<Complex>();

            Complex[] Z = {
                new Complex(1, -1), 
                new Complex(1, 1), 
                new Complex(-1, 1), 
                new Complex(-1, -1)
            };

            CreateByArray(StackComplex, Z);
            Console.WriteLine("Выводим стэк из Complex:");
            StackComplex.Print();

            Complex z1 = StackComplex.Top();
            Complex z2 = StackComplex.Pop();
            z1.Re = 0;
            Console.WriteLine("z1 = {0},  z2 = {1} => ссылки разные на объекты;", z1, z2);
            Console.WriteLine("Pop:");
            StackComplex.Print();
            Console.WriteLine("-------------");

            string[] Str = {
                "Лаковое покрытие",
                "Внешене эрозиностойкое покрытие", 
                "Кварцевая плитка", "Клеевой слой", 
                "Металлическая обшивка", 
                "Уносимая теплозащита (ПКТ-ФЛ)", 
                "Металлическая рама"
            };
            CreateByArray(StackStr, Str);
            StackStr.Print();
            Console.WriteLine("Колличество компонентов обшивки = {0}", StackStr.Count());
            Console.ReadLine();
        }
    }
}
