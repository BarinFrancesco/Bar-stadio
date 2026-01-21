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
        
        public Tifoso(bool tipo)
        {
            Tipo = tipo;
        }
    }
}
