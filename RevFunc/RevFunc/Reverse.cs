using System;


namespace RevFunc
{
    public class Reverse
    {
        public delegate double RealFunc(double x); //Делегат, описывающий сигнатуру вещественной функции 
        
        public event EventHandler<GetEps> Print;//Сигнатура события в методе FindReValue,  событие с аргументом
        
       
        public double FindReValue(double a, double b, double val, double eps, RealFunc f)// находим обратное значение
        {
            //Делим отрезок на 10 частей и итерируемся по нему до тех пор пока
            //не сойдёмся с нужной точностью или не перестанем сходится к точке
            //потом берём подотрезок и проходим аналогично по нему
            double h = (b - a) / 10;  
            int n = 0;
            while (Math.Abs(f(a+h) - val) > eps)
            {
                h = (b - a) / 10;
                n = 0;
                while ((Math.Abs(f(a + n * h) - val) > Math.Abs(f(a + (n + 1) * h) - val)) && (Math.Abs(f(a + n * h) - val) > eps))
                {
                    n++;
                    print(Math.Abs(f(a + n * h) - val));// вызов события
                }

                a = a + (n - 1) * h;
                b = a + (n + 1) * h;
                
                
            }
            

            return a+h;
        }

        private void print(double x)//описание самого события (насколько я понял)
        {
            EventHandler<GetEps> handler = Print;
            if (handler != null) handler(this, new GetEps(x));
        }

    }
}
