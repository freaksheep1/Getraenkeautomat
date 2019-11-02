using System;
using System.Collections.Generic;
using System.Text;

namespace Getraenkeautomat
{
    class Getränk
    {
        private string Art;
        private double Preis;

        public Getränk(string Art1 = "", double Preis1 = 0.0)
        {
            Art = Art1;
            Preis = Preis1;
        }

        public string printArt()
        {
            return Art;
        }

        public double printPreis()
        {
            return Preis;
        }

    }
}
