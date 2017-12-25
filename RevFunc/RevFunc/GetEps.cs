using System;
//класс для аргумента события
namespace RevFunc
{
    public class GetEps: EventArgs
    {
        public GetEps(double eps)
        {
            Eps = eps;
        }
        public double Eps { get; private set; }
    }
}
