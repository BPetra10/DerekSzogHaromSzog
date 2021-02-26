﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
class Novekvohiba : Exception
{
    public Novekvohiba(int sorszam)
    {
        HibaFormat(sorszam);
    }
    public string HibaFormat(int sorszam)
    {
        return String.Format("{0}. sor: Az adatok nincsenek növekvő rendben!", sorszam);
    }
}
class Derekszoghiba : Exception
{
    public Derekszoghiba(int sorszam)
    {
        HibaFormat(sorszam);
    }
    public string HibaFormat(int sorszam)
    {
        return String.Format("{0}. sor: A háromszög nem derékszögű!", sorszam);
    }
}
class Megszerkeszthetohiba : Exception
{
    public Megszerkeszthetohiba(int sorszam)
    {
        HibaFormat(sorszam);
    }
    public string HibaFormat(int sorszam)
    {
        return String.Format("{0}. sor: A háromszöget nem lehet megszerkeszteni!", sorszam);
    }
}
class AOldalhiba : Exception
{
    public AOldalhiba(int sorszam)
    {
        HibaFormat(sorszam);
    }
    public string HibaFormat(int sorszam)
    {
        return String.Format("{0}. sor: Az 'a' oldal nem lehet nulla vagy negatív", sorszam);
    }
}
class BOldalhiba : Exception
{
    public BOldalhiba(int sorszam)
    {
        HibaFormat(sorszam);
    }
    public string HibaFormat(int sorszam)
    {
        return String.Format("{0}. sor: A 'b' oldal nem lehet nulla vagy negatív", sorszam);
    }
}
class COldalhiba : Exception
{
    public COldalhiba(int sorszam)
    {
        HibaFormat(sorszam);
    }
    public string HibaFormat(int sorszam)
    {
        return String.Format("{0}. sor: A 'c' oldal nem lehet nulla vagy negatív", sorszam);
    }
}
namespace haromszog
{
    class DHaromszog
    {
        private double aOldal;
        private double bOldal;
        private double cOldal;
        public double AOldal { get => aOldal; set => aOldal = value; }
        public double BOldal { get => bOldal; set => bOldal = value; }
        public double COldal { get => cOldal; set => cOldal = value; }
        public DHaromszog(string sor, int sorSzáma)
        {
            string[] sorE = sor.Split(' ');
            AOldal = double.Parse(sorE[0]);
            BOldal = double.Parse(sorE[1]);
            COldal = double.Parse(sorE[2]);
            SorSzama = sorSzáma;
            if (AOldal <= 0)
                throw new AOldalhiba(sorSzáma);
            if (BOldal <= 0)
                throw new BOldalhiba(sorSzáma);
            if (COldal <= 0)
                throw new COldalhiba(sorSzáma);
            if (!this.EllNovekvoSorrend)
                throw new Novekvohiba(sorSzáma);
            if (!this.EllMegszerkesztheto)
                throw new Megszerkeszthetohiba(sorSzáma);
            if (!this.EllDerekszogu)
                throw new Derekszoghiba(sorSzáma);
        }
        private bool EllNovekvoSorrend
        {
            get
            {
                if (AOldal <= BOldal && BOldal <= COldal)
                {
                    return true;
                }
                else return false;
            }
        }
        private bool EllMegszerkesztheto
        {
            get
            {
                if (AOldal + BOldal > COldal)
                {
                    return true;
                }
                else return false;
            }
        }
        private bool EllDerekszogu
        {
            get
            {
                double a = Math.Pow(AOldal, 2);
                double b = Math.Pow(BOldal, 2);
                double c = Math.Pow(COldal, 2);

                if (a + b == c)
                {
                    return true;
                }
                else return false;
            }
        }
        public int SorSzama
        {
            get;
            set;
        }
        public double Terulet
        {
            get { return (AOldal * BOldal) / 2; }
        }
        public double Kerulet
        {
            get { return AOldal + BOldal + COldal; }
        }
    }
}

