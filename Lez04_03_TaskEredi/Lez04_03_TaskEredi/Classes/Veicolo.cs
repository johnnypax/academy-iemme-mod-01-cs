﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_03_TaskEredi.Classes
{
    internal abstract class Veicolo
    {
        public int Telaio { get; set; }

        public abstract void metodoLocomozione();

    }
}
