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
        ClothConditions conditions;
        readonly bool isbig;
        readonly byte bonus;
        (ClothConditions, byte)[] bonusConditions;

        internal Cloth(int? price, string name, bool isDoor, string image,
                            ClothTypeEnum type, ClothConditions conditions,
                            bool isbig, byte bonus, (ClothConditions, byte)[] bonusConditions)
            : base(price, name, isDoor, image)
        {
            this.type = type;
            this.conditions = conditions;
            this.bonus = bonus;
            this.bonusConditions = bonusConditions;
            this.isbig = isbig;
        }
    }
}
