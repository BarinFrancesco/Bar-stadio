using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamellazTask
{
    public  class Barista
    {
        Random generatore;
        public bool Chiuso;
        public Barista()
        {
            generatore = new Random();
        }


        public async void Aspetta()
        {
            int tempo = generatore.Next(1, 15);
            tempo *= 1000;

            await Task.Delay(tempo);
            

        }

    }
}
