﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    internal class Effect : Card
    {
        internal Effect(int? price, string name, bool isDoor, string image, string text)
            : base(price, name, isDoor, image, text)
        {
        }
    }
}
