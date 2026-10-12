using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolce
{
    public class Torta : Dolce
    {
        public Torta(string n, int p) : base(n, Tipologia.Torta, p)
        {
        }

        public override string Descrizione()
        {
            return $"Nome: {nome} | Tipologia: {tipologia} | Punteggio: {punteggio}";
        }

        public void provaSofficenza()
        {
            punteggio -= 6;

            if (punteggio < 0)
                punteggio = 0;
        }
    }
}