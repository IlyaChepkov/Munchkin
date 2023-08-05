using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Munchkin
{
    internal class Damn : Effect
    {
        internal Damn(int? price, string name, bool isDoor, string image, string text)
            : base(price, name, isDoor, image, text)
        {
        }
    }
}
