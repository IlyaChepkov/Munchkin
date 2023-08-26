using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    public class Race : Card
    {
        readonly int id;
        internal Race(int? price, string name, bool isDoor, string image, string text, int id)
            : base(price, name, isDoor, image, text)
        {
            this.id = id;
        }
    }
}
