using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamellazTask
{
    public  class Barista
    {
        SemaphoreSlim ClientiDentro;
        public bool Chiude;

        public Barista(SemaphoreSlim ClientiDentro)
        {
            Chiude = false;
            this.ClientiDentro = ClientiDentro;
        }


        public async void Aspetta()
        {
            int tempo = Random.Shared.Next(1, 15) * 1000;

            await Task.Delay(tempo);

            Chiude = true;
        }

    }
}
