using System;

namespace ClassShape
{

    public abstract class Body3D
    {
        public abstract double SurfaceArea();
        public abstract double V();
        public abstract double SumRib();
        public abstract void Out();
    }

    public class RecPar : Body3D
    {
        private double _a, _b, _c;
        public RecPar(double a = 1, double b = 1, double c = 1)
        {
            _a = Math.Abs(a);
            _b = Math.Abs(b);
            _c = Math.Abs(c);
        }
        public override double V()
        {
            return _a * _b * _c;
        }
        public override double SurfaceArea()
        {
            return 2*(_a * _b + _a * _c + _c * _b);
        }
        public override double SumRib()
        {
            return 4 * (_a + _b + _c);
        }

        public override void Out()
        {
            Console.WriteLine("Прямоугольник: \n V = {0} \n Ssurface = {1} \n SumSide = {2}", this.V(), this.SurfaceArea(), this.SumRib());
        }
    }

    public class Sphere: Body3D
    {
        private double R;

        public Sphere(double R = 1)
        {
            this.R = Math.Abs(R);
        }

        public override double V()
        {
            return 4 * Math.PI * Math.Pow(this.R, 3) / 3;
        }

        public override double SumRib()
        {
            return 2 * Math.PI * this.R;
        }

        public override double SurfaceArea()
        {
            return 4 * Math.PI * Math.Pow(this.R, 2);
        }

        public override void Out()
        {
            Console.WriteLine("Сфера: \n V = {0} \n Ssurface = {1} \n SumSide = {2}", this.V(), this.SurfaceArea(), this.SumRib());
        }

    }

    public class TetrHed: Body3D
    {
        private double a;

        public TetrHed(double a = 1)
        {
            this.a = a;
        }

        public override double SumRib()
        {
            return 6 * this.a;
        }

        public override double V()
        {
            return Math.Sqrt(2) * Math.Pow(this.a, 3) / 12;
        }

        public override double SurfaceArea()
        {
            return Math.Sqrt(3) * Math.Pow(this.a, 3);
        }

        public override void Out()
        {
            Console.WriteLine("Тетраэдр: \n V = {0} \n Ssurface = {1} \n SumSide = {2}", this.V(), this.SurfaceArea(), this.SumRib());
        }
    }
}
