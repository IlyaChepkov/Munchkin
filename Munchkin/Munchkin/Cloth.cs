using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    internal class Cloth : Card
    {
        ClothTypeEnum type;
        ClothConditions Conditions;
        readonly bool isbig;
        readonly byte bonus;
        (ClothConditions, byte)[] bonusConditions;
    }
}
