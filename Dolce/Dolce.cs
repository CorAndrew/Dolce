using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolce
{
    public enum Tipologia
    {
        Torta,
        Crostata
    }

    public abstract class Dolce
    {
        public string nome { get; set; }
        public Tipologia tipologia { get; set; }
        public int punteggio { get; set; }

        public Dolce(string n, Tipologia t, int p)
        {
            nome = n;
            tipologia = t;
            punteggio = p;
        }

        public abstract string Descrizione();

        public void Raffina()
        {
            Random rnd = new Random();
            int puntiAggiunti = rnd.Next(3, 8);

            if (punteggio + puntiAggiunti > 10)
                punteggio = 10;
            else
                punteggio += puntiAggiunti;
        }
    }
}