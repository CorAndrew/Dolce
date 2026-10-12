using System;
using System.Collections.Generic;

namespace Dolce
{
    internal class Program
    {
        private static List<Dolce> dolci = new List<Dolce>();

        static void Main(string[] args)
        {
            dolci.Add(new Torta("Triplocioccolato", 8));
            dolci.Add(new Torta("Vaniglia", 9));
            dolci.Add(new Crostata("Cioccolato", 7));
            dolci.Add(new Crostata("Marmellata", 10));

            bool esci = false;
            while (!esci)
            {
                Console.WriteLine("1. Visualizza stato di tutti i dolci in gara");
                Console.WriteLine("2. Sottoponi una Crostata alla Prova di Croccantezza");
                Console.WriteLine("3. Sottoponi una Torta alla Prova di Sofficenza");
                Console.WriteLine("4. Raffina un dolce a scelta");
                Console.WriteLine("5. Avvia la Finale di Degustazione");

                string scelta = Console.ReadLine();
                Console.WriteLine();

                switch (scelta)
                {
                    case "1":
                        VisualizzaDolci();
                        break;

                    case "2":
                        EseguiProvaCroccantezza();
                        break;

                    case "3":
                        EseguiProvaSofficenza();
                        break;

                    case "4":
                        RaffinaSingoloDolce();
                        break;

                    case "5":
                        AvviaFinale();
                        break;

                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            }
        }


        private static void VisualizzaDolci()
        {
            Console.WriteLine("elenco dolci in gara");
            for (int i = 0; i < dolci.Count; i++)
            {
                Console.WriteLine($"{i} {dolci[i].Descrizione()}");
            }
        }

        private static void EseguiProvaCroccantezza()
        {
            List<Crostata> crostate = new List<Crostata>();
            foreach (var d in dolci)
            {
                if (d is Crostata c) crostate.Add(c);
            }

            if (crostate.Count == 0)
            {
                Console.WriteLine("Non ci sono crostate in gara");
                return;
            }

            Console.WriteLine("Scegli una crostata");
            for (int i = 0; i < crostate.Count; i++)
            {
                Console.WriteLine($"{i} {crostate[i].Descrizione()}");
            }

            Console.WriteLine("Indice crostata");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < crostate.Count)
            {
                Crostata sceltac = crostate[idx];
                int vecchioPunteggio = sceltac.punteggio;

                sceltac.provaCroccantezza();

                Console.WriteLine($"Risultato Prova di Croccantezza");
                Console.WriteLine($"Valore precedente: {vecchioPunteggio} pt");
                Console.WriteLine($"Valore successivo: {sceltac.punteggio} pt");
            }
            else
            {
                Console.WriteLine("Selezione non valida.");
            }
        }

        private static void EseguiProvaSofficenza()
        {
            List<Torta> torte = new List<Torta>();
            foreach (var d in dolci)
            {
                if (d is Torta t) torte.Add(t);
            }

            if (torte.Count == 0)
            {
                Console.WriteLine("Non ci sono torte in gara.");
                return;
            }

            Console.WriteLine("Scegli una torta");
            for (int i = 0; i < torte.Count; i++)
            {
                Console.WriteLine($"{i} {torte[i].Descrizione()}");
            }

            Console.WriteLine("Indice torta");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < torte.Count)
            {
                Torta sceltat = torte[idx];
                int vecchioPunteggio = sceltat.punteggio;

                sceltat.provaSofficenza();

                Console.WriteLine($"Risultato Prova di Sofficenza:");
                Console.WriteLine($"Valore precedente: {vecchioPunteggio} pt");
                Console.WriteLine($"Valore successivo: {sceltat.punteggio} pt");
            }
            else
            {
                Console.WriteLine("Selezione non valida.");
            }
        }

        private static void RaffinaSingoloDolce()
        {
            VisualizzaDolci();
            Console.WriteLine("Inserisci l'indice del dolce da raffinare: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < dolci.Count)
            {
                Dolce d = dolci[idx];
                int vecchioPunteggio = d.punteggio;

                d.Raffina();

                Console.WriteLine($"Raffinazione completata per {d.nome}");
                Console.WriteLine($"Valore precedente: {vecchioPunteggio}");
                Console.WriteLine($"Valore successivo: {d.punteggio}");
            }
            else
            {
                Console.WriteLine("Selezione non valida.");
            }
        }

        private static void AvviaFinale()
        {
            Console.WriteLine("Finale di degustazione");

            foreach (var d in dolci)
            {
                int vecchioPunteggio = d.punteggio;
                d.Raffina();
                Console.WriteLine($"{d.nome} {d.tipologia} nuovo punteggio {d.punteggio} pt");
            }

            Console.WriteLine("Finale terminata");
        }
    }
}