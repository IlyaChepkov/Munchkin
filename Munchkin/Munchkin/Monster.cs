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
        readonly int levelCount;
        readonly int treasuareCount;

        internal Monster(int? price, string name, bool isDoor, string image, string text,
                            int level, bool isAndead, int levelCount, int treasuareCount)
            : base(price, name, isDoor, image, text)
        {
            this.level = level;
            this.isAndead = isAndead;
            this.levelCount = levelCount;
            this.treasuareCount = treasuareCount;
        }
    }
}
