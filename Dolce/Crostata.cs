using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolce
{
    public class Crostata : Dolce
    {
        public Crostata(string n, int p) : base(n, Tipologia.Crostata, p)
        {
        }

        public override string Descrizione()
        {
            return $"Nome: {nome} | Tipologia: {tipologia} | Punteggio: {punteggio}";
        }

        public void provaCroccantezza()
        {
            punteggio -= 4;

            if (punteggio < 0)
                punteggio = 0;
        }
    }
}