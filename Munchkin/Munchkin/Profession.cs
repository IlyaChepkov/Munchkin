using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    internal class Profession : Card
    {
        internal Profession(int? price, string name, bool isDoor, string image)
            : base(price, name, isDoor, image)
        {
        }
    }
}
