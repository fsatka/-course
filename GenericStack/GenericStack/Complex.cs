using System;

namespace ClassComplex
{
    public class Complex : ICloneable
    {
        private double _Im, _Re;

        public Complex(double x = 0, double y = 0)
        {
            _Re = x;
            _Im = y;
        }

        #region Z = f(Mod, Arg)
        public static Complex CreateByArgMod(double Mod, double Arg)
        {
            if(Mod < 0)
                return null;
            if(Mod == 0)
                return new Complex();
            if(Arg%(2*Math.PI) == Math.PI/2)
                return new Complex(0, Mod);
            if (Arg % (2 * Math.PI) ==  -Math.PI/2)
                return new Complex(0, -Mod);
            if (Arg % (2 * Math.PI) == Math.PI || Arg % (2 * Math.PI) == -Math.PI)
                return new Complex(-Mod, 0);
            return new Complex(Mod/Math.Sqrt(1 + Math.Pow(Math.Tan(Arg),2)), Mod * Math.Tan(Arg) / Math.Sqrt(1 + Math.Pow(Math.Tan(Arg), 2)));
        }
        #endregion


        #region Свойства Z
        public double Im
        {
            get { return _Im; }
            set
            {
                _Im = value;
            }
        }

        public double Re
        {
            get { return _Re; }
            set
            {
                _Re = value;
            }
        }

        public double Arg
        {
            get { return Math.Atan(_Im / _Re); }
        }
        public double Mod
        {
            get { return Math.Sqrt(_Im*_Im +  _Re*_Re); }
        }
        #endregion
        
        #region Красивый вывод Z
        public override string ToString()
        {
            if(_Re == 0 && _Im != 0)
            {
                if (_Im != 1 && _Im != -1)
                    return string.Format("{0}i", _Im);
                if (_Im == 1)
                    return string.Format("{0}i", "");
                if (_Im == -1)
                    return string.Format("{0}i", "-");
            }
            if(_Im == 0 && _Re != 0)
                return _Re.ToString();
            if (_Im == 0 && _Re == 0)
                return "0";
            if (_Im > 0)
            {
                if(_Im == 1)
                    return string.Format("{0}+i", _Re);
                return string.Format("{0}+{1}i", _Re, _Im);
            }
            if (_Im == -1)
                return string.Format("{0}-i", _Re);
            return string.Format("{0}{1}i", _Re, _Im);
        }
        #endregion

        #region Арифметические операции над Z
        public static Complex operator -(Complex z1, Complex z2)
        {
            return new Complex(z1._Re - z2._Re, z1._Im - z2._Im);
        }
        public static Complex operator -(Complex z)
        {
            return new Complex(-z._Re, -z._Im);
        }

        public static Complex operator +(Complex z1, Complex z2)
        {
            return new Complex(z1._Re + z2._Re, z1._Im + z2._Im);
        }
       
        public static Complex operator +(Complex z, double x )
        {
            return new Complex(z._Re + x, z._Im );
        }
        public static Complex operator *(Complex z, double x)
        {
            return new Complex(z._Re * x, z._Im * x);
        }
        public static Complex operator *(Complex z1, Complex z2)
        {
            return new Complex(z1._Re * z2._Re - z1._Im * z2._Im, z1._Re * z2._Im + z1._Im * z2._Re);
        }
        public static Complex operator /(Complex z1, Complex z2)
        {
            return new Complex((z1._Re*z2._Re + z1._Im*z2._Im)/Math.Pow(z2.Mod,2), (z1._Im * z2._Re - z1._Re * z2._Im) / Math.Pow(z2.Mod, 2));
        }
        #endregion

        #region Операции сравнения
        public static bool operator ==(Complex z1, Complex z2)
        {
            if (object.ReferenceEquals(z1, null))
            {
                return ReferenceEquals(z2, null);
            }
            return z1.Equals(z2);
        }
        public static bool operator !=(Complex z1, Complex z2)
        {
            return !(z1 == z2);
        }
        public override int GetHashCode()
        {
            return _Im.GetHashCode() ^ _Re.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Complex z)
                return _Im == z._Im && _Re == z._Re;
            return false;
        }

        object ICloneable.Clone()
        {
            return new Complex(Re, Im);
        }
        #endregion

        #region Приведение типов
        public static implicit operator double(Complex z)
        {
            return z._Re;
        }
        public static implicit operator Complex(double x)
        {
            return new Complex(x);
        }
        #endregion
    }
}
