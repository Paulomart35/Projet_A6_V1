﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Camionnette : Vehicule  
    {
        public string usage;

        public Camionnette(string usage) : base()
        {
            this.usage=usage;
        }
    }
}
