using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teglalap
{
    class Teglalap
    {
        private double a;
        private double b;

        public double A;
        public double B;

        public Teglalap() { }

        public Teglalap(double a, double b)
        {

        }

        public double Kerulet()
        {
            return a * 2 + b;
        }

        public double Terulet()
        {
            return a * b;
        }
    }
}
