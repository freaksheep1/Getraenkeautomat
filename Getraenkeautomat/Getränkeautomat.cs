using System;
using System.Collections.Generic;
using System.Text;

namespace Getraenkeautomat
{
    class Getränkeautomat
    {
        private int Cent1;
        private int Cent2;
        private int Cent5;
        private int Cent10;
        private int Cent20;
        private int Cent50;
        private int Euro1;
        private int Euro2;


        public Getränkeautomat(int Münze001 = 50, int Münze002 = 50, int Münze005 = 50, int Münze010 = 50, int Münze020 = 50, int Münze050 = 50, int Münze100 = 50, int Münze200 = 50)
        {
            Cent1 = Münze001;
            Cent2 = Münze001;
            Cent5 = Münze005;
            Cent10 = Münze010;
            Cent20 = Münze020;
            Cent50 = Münze050;
            Euro1 = Münze100;
            Euro2 = Münze200;


        }

        public Getränk[] Auffüllen()
        {
            int Zähler = 0;

            String[,] GetränkeListe = new string[7, 2]
            {
                { "Cola", "1,50"},
                { "Fanta", "1,20"},
                { "Sprite", "1,20"},
                { "Wasser", "1,00" },
                { "Bier", "2,00" },
                { "Ice Tea", "1,20" },
                {"Kölsch", "1,00" }
            };

            Getränk[] Getränke = new Getränk[GetränkeListe.GetLength(0)];

            for (int i = 0; i < GetränkeListe.GetLength(0); i++)
            {
                for (int j = 0; j < GetränkeListe.GetLength(1); j++)
                {
                    Getränk G = new Getränk(GetränkeListe[i, j], Convert.ToDouble(GetränkeListe[i, j + 1]));
                    Getränke[Zähler] = G;
                    Zähler++;
                    j++;

                }

            }
            return Getränke;
        }


        public void Bezahlen(Getränk Objekt)
        {
            double Preis = Objekt.printPreis();
            int Auswahl = 0;
            int ZaehlerCent1 = 0;
            int ZaehlerCent2 = 0;
            int ZaehlerCent5 = 0;
            int ZaehlerCent10 = 0;
            int ZaehlerCent20 = 0;
            int ZaehlerCent50 = 0;
            int ZaehlerEuro1 = 0;
            int ZaehlerEuro2 = 0;

            Console.WriteLine("Bitte Geld einwerfen: \n"
                + "[1]  1 cent \n"
                + "[2]  2 cent \n"
                + "[3]  5 cent \n"
                + "[4] 10 cent \n"
                + "[5] 20 cent \n"
                + "[6] 50 cent \n"
                + "[7]  1 Euro \n"
                + "[8]  2 Euro \n"
                + "[9] Abbruch");


            while (Preis > 0)
            {
                Auswahl = Convert.ToInt16(Console.ReadLine());


                if (Auswahl == 1)
                {
                    Preis -= 0.01;
                    Preis = Math.Round(Preis, 2);
                    Console.WriteLine(Preis);
                    ZaehlerCent1 += 1;
                }

                else if (Auswahl == 2)
                {
                    Preis -= 0.02;
                    Preis = Math.Round(Preis, 2);
                    Console.WriteLine(Preis);
                    ZaehlerCent2 += 1;
                }

                else if (Auswahl == 3)
                {
                    Preis -= 0.05;
                    Preis = Math.Round(Preis, 2);
                    Console.WriteLine(Preis);
                    ZaehlerCent5 += 1;
                }

                else if (Auswahl == 4)
                {
                    Preis -= 0.1;
                    Preis = Math.Round(Preis, 2);
                    Console.WriteLine(Preis);
                    ZaehlerCent10 += 1;
                }

                else if (Auswahl == 5)
                {
                    Preis -= 0.2;
                    Preis = Math.Round(Preis, 2);
                    Console.WriteLine(Preis);
                    ZaehlerCent20 += 1;
                }

                else if (Auswahl == 6)
                {
                    Preis -= 0.5;
                    Preis = Math.Round(Preis, 2);
                    Console.WriteLine(Preis);
                    ZaehlerCent50 += 1;
                }

                else if (Auswahl == 7)
                {
                    Preis -= 1.0;
                    Preis = Math.Round(Preis, 2);
                    Console.WriteLine(Preis);
                    ZaehlerEuro1 += 1;
                }

                else if (Auswahl == 8)
                {
                    Preis -= 2.0;
                    Preis = Math.Round(Preis, 2);
                    Console.WriteLine(Preis);
                    ZaehlerEuro2 += 1;
                }

                else if (Auswahl == 9)
                {
                    break;
                }
            }

            if (Auswahl != 9)
            {
                Cent1 += ZaehlerCent1;
                Cent2 += ZaehlerCent2;
                Cent5 += ZaehlerCent5;
                Cent10 += ZaehlerCent10;
                Cent20 += ZaehlerCent20;
                Cent50 += ZaehlerCent50;
                Euro1 += ZaehlerEuro1;
                Euro2 += ZaehlerEuro2;

                if (Preis < 0)
                {
                    Wechselgeld(Preis);
                }

                Console.WriteLine("Vielen Dank für ihren Einkauf \n"
                    + Objekt.printArt() + " fällt aus dem Automaten");

                Console.ReadKey();

            }

        }

        private void Wechselgeld(double Preis)
        {
            double Rückgeld = 0;
            Console.WriteLine("Es fallen Folgede Münzen aus dem Automaten:");
            while (Preis != 0)
            {
                if ((Preis <= -2) && (Euro2 > 0))
                {
                    Preis += 2.0;
                    Rückgeld += 2.0;
                    Rückgeld = Math.Round(Rückgeld, 2);
                    Preis = Math.Round(Preis, 2);
                    Euro2--;
                    Console.WriteLine("2 Euro");
                }

                else if ((Preis <= -1) && (Euro1 > 0))
                {
                    Preis += 1.0;
                    Rückgeld += 1.0;
                    Rückgeld = Math.Round(Rückgeld, 2);
                    Preis = Math.Round(Preis, 2);
                    Euro1--;
                    Console.WriteLine("1 Euro");
                }

                else if ((Preis <= -0.5) && (Cent50 > 0))
                {
                    Preis += 0.5;
                    Rückgeld += 0.5;
                    Rückgeld = Math.Round(Rückgeld, 2);
                    Preis = Math.Round(Preis, 2);
                    Cent50--;
                    Console.WriteLine("50 cent");
                }

                else if ((Preis <= -0.2) && (Cent20 > 0))
                {
                    Preis += 0.2;
                    Rückgeld += 0.2;
                    Rückgeld = Math.Round(Rückgeld, 2);
                    Preis = Math.Round(Preis, 2);
                    Cent20--;
                    Console.WriteLine("20 Cent");
                }

                else if ((Preis <= -0.1) && (Cent10 > 0))
                {
                    Preis += 0.1;
                    Rückgeld += 0.1;
                    Rückgeld = Math.Round(Rückgeld, 2);
                    Preis = Math.Round(Preis, 2);
                    Cent10--;
                    Console.WriteLine("10 cent");
                }

                else if ((Preis <= -0.05) && (Cent5 > 0))
                {
                    Preis += 0.05;
                    Rückgeld += 0.05;
                    Rückgeld = Math.Round(Rückgeld, 2);
                    Preis = Math.Round(Preis, 2);
                    Cent5--;
                    Console.WriteLine("5 cent");
                }

                else if ((Preis <= -0.02) && (Cent2 > 0))
                {
                    Preis += 0.02;
                    Rückgeld += 0.02;
                    Rückgeld = Math.Round(Rückgeld, 2);
                    Preis = Math.Round(Preis, 2);
                    Cent2--;
                    Console.WriteLine("2 cent");
                }

                else if ((Preis < 0) && (Cent20 > 0))
                {
                    Preis += 0.01;
                    Preis = Math.Round(Preis, 2);
                    Rückgeld += 0.01;
                    Rückgeld = Math.Round(Rückgeld, 2);
                    Cent20--;
                    Console.WriteLine("1 cent");
                }

                else if (Preis > 0)
                {
                    Console.WriteLine(Preis);
                    Console.WriteLine("Fehler beim bestimmen des Wechselgeldes bitte Support Kontaktieren");
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("Nicht genug Wechselgeld im Automaten bitte Support Kontaktieren");
                    Console.ReadKey();
                }

            }


            Console.WriteLine("Ihr Wächselgeld beträgt: " + Convert.ToString(Rückgeld));

        }

        public void GeldAuffüllen()
        {

        }

    }
}
