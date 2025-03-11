using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termekek
{
    internal class Termek
    {
		private int egysegAr;
        public int EgysegAr
		{
			get { return egysegAr; }
			set
			{
				if (value > 0) { egysegAr = value; }
				else { egysegAr = 1; }
			}
		}

        private double kedvezmeny;
        public double Kedvezmeny
		{
			get { return kedvezmeny; }
			set
			{
				if (value > 0) { kedvezmeny = value; }
			}
		}

		private int raktarKeszlet;
		public int RaktarKeszlet
		{
			get { return raktarKeszlet; }
			set
			{
				if (value > 0) { raktarKeszlet = value; }
			}
		}

        public string Nev { get; init; }

        public Termek(string nev, int ar)
        {
			Nev = nev;
			EgysegAr = ar;
			raktarKeszlet = 1;
        }

        public Termek(int egysegAr, int raktarKeszlet, string nev)
        {
            EgysegAr = egysegAr;
            RaktarKeszlet = raktarKeszlet;
            Nev = nev;
			kedvezmeny = 0;
        }

		public string Informacio()
		{
			return $"Termék neve: {Nev}, ára: {egysegAr}, {raktarKeszlet}";
		}

		public bool Eladas(int db)
		{
			if (raktarKeszlet >= db && db > 0)
			{
				raktarKeszlet -= db;
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Beszerzes(int db)
		{
			if (db > 0)
			{
				raktarKeszlet += db;
			}
		}
    }
}
