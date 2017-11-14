using System;
using ClassShape;

namespace Shape
{
    class Program
    {
        static void Main()
        {
            RecPar A = new RecPar(2, 3, 4);
            Sphere B = new Sphere(5);
            TetrHed C = new TetrHed(7);
            Body3D[] Shape = {A, B, C};
            foreach (Body3D item in Shape)
            {
                item.Out();
            }
            Console.ReadLine();
        }
    }
}
