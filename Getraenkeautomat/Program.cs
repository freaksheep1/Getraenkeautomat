using System;
using System.Collections.Generic;
using System.Text;

namespace Getraenkeautomat
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Schalter = true;
            int Auswahl;
            int Länge = -1;
            Getränk[] AuswahListe = new Getränk[15];
            Getränk Wahl;

            // Erstellen des Getränke Automatens und Aufüllen mit Getränken
            Getränkeautomat ColaAutomat = new Getränkeautomat();
            Getränk[] Inhalt = ColaAutomat.Auffüllen();

            // Festlegung der Länge des Arrays Inhalt
            foreach (Getränk i in Inhalt)
            {
                Länge++;
            }

            //Auswahal von Getränken und Bezalvorgang.
            while (Schalter)
            {
                Console.WriteLine("Herzlich Wilkommen: \n"
                    + "Bitte wählen sie ihr Getränk:");
                for (int i = 0; i < Inhalt.Length; i++)
                {
                    Console.WriteLine("[" + i + "]" + Inhalt[i].printArt() + " Preis: {0:0.00} Euro", Inhalt[i].printPreis());
                }

                Console.WriteLine("Bitte Auswahl treffen: ");
                Auswahl = Convert.ToInt16(Console.ReadLine());


                if ((Auswahl >= 0) && (Auswahl <= Länge))
                {
                    Wahl = Inhalt[Auswahl];
                    Console.WriteLine("Sie haben " + Wahl.printArt() + " Gewählt bitte Werfen sie {0:0.00} Euro in den Automaten.", Wahl.printPreis());
                    ColaAutomat.Bezahlen(Wahl);
                }

                //Beenden des Automatens

                else if (Auswahl == 100)
                {
                    Schalter = false;
                    Console.WriteLine("Automat wird Beendet");
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("Sie haben kein Getränk geaählt Vorgang Abgebrochen.");
                    Console.ReadKey();
                }
                Console.Clear();
            }

        }

    }
}
