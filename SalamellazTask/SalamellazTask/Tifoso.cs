using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamellazTask
{
    public class Tifoso
    {
        public bool Tipo { get; private set; }
        readonly SemaphoreSlim PostiDisponibili;
        static public int PostiOccupati { get; private set; }
        static public TipoTifosi TifosiDentro { get; set; }
        public Tifoso(bool tipo , int posti,  SemaphoreSlim postiDisponibili)
        {
            Tipo = tipo;
            PostiDisponibili = postiDisponibili;
            PostiOccupati = 0;
        }

        public async Task Ordina()
        {
            //int tempo = Random.Shared.Next(1, 6) * 1000;
            PostiOccupati++;
            if (Tipo)
            {
                TifosiDentro = TipoTifosi.Casa;
                int posti = 5 - PostiOccupati; 
                Console.WriteLine($"Il tifoso di casa sta entrando, posti disponibili {posti}");
            }
            else
            {
                TifosiDentro = TipoTifosi.Ospiti;
                int posti = 5 - PostiOccupati;
                Console.WriteLine($"Il tifoso ospite sta entrando, posti disponibili {posti}");
            }
           

            
            await Task.Delay(1500);

            

            PostiDisponibili.Release();
            PostiOccupati--;
            if(PostiOccupati ==0)
            {
                TifosiDentro = TipoTifosi.Nessuno;
            }
            int postii = 5 - PostiOccupati;
            Console.WriteLine($"Il tifoso è uscito, posti disponibili {postii}");
        }
    }
}
