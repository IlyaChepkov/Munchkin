using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    internal struct ClothConditions
    {
       internal int[] profession;
       internal int[] races;
       internal bool? isBoy;
        internal ClothConditions(int[] profession, int[] races, bool? isBoy)
        {
            this.profession = profession;
            this.races = races;
            this.isBoy = isBoy;
        }
    }
}
