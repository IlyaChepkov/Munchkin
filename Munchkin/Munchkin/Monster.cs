using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    internal class Monster : Card
    {
        readonly bool isAndead;
        readonly int level;
        readonly int levelcount;
        readonly int treasuarecount;

        internal Monster(int? price, string name, bool isDoor, string image,
                            int level, bool isAndead, int levelcount, int treasuarecount)
            : base(price, name, isDoor, image)
        {

        }
    }
}
