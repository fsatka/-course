using System;
using ClassComplex;

namespace ComplexQueue
{
    class Program
    {
        static void Main()
        {
            Complex z1 = new Complex(1, 1);
            Complex z2 = new Complex(3, 5);
            Complex z3 = new Complex(2, 3);
                    
            Queue L1 = new Queue();
            L1.Engueue(z1);
            L1.Engueue(z2);
            L1.Engueue(z3);
            L1.Engueue(z1);

            Console.WriteLine("Вывод с ToString в последнем элементе");
            L1.Print1();
            Console.WriteLine("Вывод без ToString в последнем элементе");
            L1.Print2();

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\nN(L) = {0}",L1.Count());
            Console.WriteLine("L1.Peek() = {0}", L1.Peek());
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("L1.Dequeue()");
            L1.Dequeue();
            L1.Print1();
            Console.WriteLine("\nN(L) = {0}", L1.Count());

            Console.WriteLine("----------------------------------------------------------");
            z2.Re = 0;
            L1.Print1();
            Console.ReadLine();
           
        }
    }
}
