using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamellazTask
{
    public class Bar
    {
        static int posti = 5;
        //public TipoTifosi TifosiDentro;
        public SemaphoreSlim PostiDisponibili;
        public SemaphoreSlim ClientiDentro;
        Tifoso[] Clienti;
        Barista Barman;

        public Bar()
        {
            PostiDisponibili = new SemaphoreSlim(posti);
            ClientiDentro = new SemaphoreSlim(0);
            Tifoso.TifosiDentro = TipoTifosi.Nessuno;
            Barman = new Barista(ClientiDentro);

            Clienti = new Tifoso[10];
            for(int i=0; i<10; i++)
            {
                bool squadra = Random.Shared.Next(1, 3) % 2 == 0 ? true : false;
                Clienti[i] = new Tifoso(squadra, posti , PostiDisponibili);
            }
        }


        
        public async Task ApriBar()
        {

            for(int i=0; i<10; i++)
            {
                if (!Barman.Chiude)
                {
                    //se il tifoso è ospite e nel bar non ci sono tifosi di casa
                    if (!Clienti[i].Tipo && Tifoso.TifosiDentro != TipoTifosi.Casa) //nel mi caso tipo è true se è di casa
                    {
                        await PostiDisponibili.WaitAsync();

                        Clienti[i].Ordina(); //ordina è un metodo async void che aspetta un tempo random per simulare il servizio 
                    } else if(Clienti[i].Tipo && Tifoso.TifosiDentro != TipoTifosi.Ospiti) // se è di casa e non ci sono ospiti
                    {
                        await PostiDisponibili.WaitAsync();

                        Clienti[i].Ordina();
                    }
                }

                await Task.Delay(700);
            }


        }
    }
}
