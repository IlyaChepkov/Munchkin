using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Munchkin
{
    internal struct ClothConditions
    {
       internal int[] profession;
       internal int[] races;
       internal bool? isBoy;

        internal ClothConditions(XmlNode conditions)
        {
            XmlNode professions = Card.GetFirstXmlNode(conditions.ChildNodes, "Professions");
            int[] profession = new int[professions.ChildNodes.Count];
            for (int i = 0; i < profession.Length; i++)
            {
                profession[i] = int.Parse(professions.ChildNodes[i].InnerText);
            }
            XmlNode race = Card.GetFirstXmlNode(conditions.ChildNodes, "races");
            int[] races = new int[conditions.ChildNodes.Count];
            for (int i = 0; i < races.Length; i++)
            {
                races[i] = int.Parse(race.ChildNodes[i].InnerText);
            }
            bool? isBoy;
            if (Card.GetFirstXmlNode(conditions.ChildNodes, "IsBoy").InnerText != "Null")
                isBoy = bool.Parse(Card.GetFirstXmlNode(conditions.ChildNodes, "IsBoy").InnerText);
            else
                isBoy = null;
            this.profession = profession;
            this.races = races;
            this.isBoy = isBoy;
        }
    }
}
