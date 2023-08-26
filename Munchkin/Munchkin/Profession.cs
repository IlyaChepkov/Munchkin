using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    public class Profession : Card
    {
        int id;
        internal Profession(int? price, string name, bool isDoor, string image, string text, int id)
            : base(price, name, isDoor, image, text)
        {
            this.id = id;
        }
    }
}
