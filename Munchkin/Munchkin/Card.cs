using System.Xml;

namespace Munchkin
{
    public abstract class Card
    {
        internal readonly int? price;
        internal readonly string name;
        internal readonly bool isDoor;
        internal readonly string image;

        internal Card(int? price, string name, bool isDoor, string image)
        {
            this.price = price;
            this.name = name;
            this.isDoor = isDoor;
            this.image = image;
        }

        public static List<Card> CreateCards(XmlNode node)
        {
            if (node.Name == "Cards")
            {
                List<Card> cards = new List<Card>();
                foreach (XmlNode card in node.ChildNodes)
                {
                    if (card.Name == "Card")
                    {
                        int count = 1;
                        XmlNode countNode = GetFirstXmlNode(card.ChildNodes, "Count");
                        if (countNode != null)
                        {
                            count = int.Parse(countNode.InnerText);
                        }
                        XmlNode imagesNode = GetFirstXmlNode(card.ChildNodes, "Images");
                        if (imagesNode != null && countNode == null)
                        {
                            count = imagesNode.ChildNodes.Count;
                        }
                        string cardType = GetFirstXmlNode(card.ChildNodes, "Type").InnerText;
                        bool isDoor = bool.Parse(GetFirstXmlNode(card.ChildNodes, "IsDoor").InnerText);
                        string name = GetFirstXmlNode(card.ChildNodes, "Name").InnerText;
                        int? price = null;
                        if (GetFirstXmlNode(card.ChildNodes, "Price") != null)
                            price = int.Parse(GetFirstXmlNode(card.ChildNodes, "Price").InnerText);
                        for (int i = 0; i < count; i++)
                        {
                            string image;
                            if (imagesNode == null)
                                image = GetFirstXmlNode(card.ChildNodes, "Image").InnerText;
                            else
                                image = imagesNode.ChildNodes[i % imagesNode.ChildNodes.Count].InnerText;
                            Card resultCard = null;
                            switch (cardType)
                            {
                                case "Class":
                                    resultCard = new Profession(price, name, isDoor, image);
                                    break;
                                case "Effect":
                                    resultCard = new Effect(price, name, isDoor, image);
                                    break;
                                case "Damn":
                                    resultCard = new Damn(price, name, isDoor, image);
                                    break;
                                case "Race":
                                    resultCard = new Race(price, name, isDoor, image);
                                    break;
                                case "Monster":
                                    {
                                        int level = int.Parse(GetFirstXmlNode(card.ChildNodes, "Level").InnerText);
                                        bool isAndead = bool.Parse(GetFirstXmlNode(card.ChildNodes, "IsAndead").InnerText);
                                        int levelCount = int.Parse(GetFirstXmlNode(card.ChildNodes, "LevelCount").InnerText);
                                        int TreasuareCount = int.Parse(GetFirstXmlNode(card.ChildNodes, "TreasuareCount").InnerText);
                                        resultCard = new Monster(price, name, isDoor, image,
                                                                    level, isAndead, levelCount, TreasuareCount);
                                    }
                                    break;
                                case "Cloth":
                                    ClothTypeEnum clothType = (ClothTypeEnum)int.Parse(GetFirstXmlNode(card.ChildNodes, "ClothType").InnerText);
                                    bool isBig = bool.Parse(GetFirstXmlNode(card.ChildNodes, "IsBig").InnerText);
                                    byte bonus = byte.Parse(GetFirstXmlNode(card.ChildNodes, "Bonus").InnerText);
                                    ClothConditions clothConditions = new ClothConditions(GetFirstXmlNode(card.ChildNodes, "Conditions"));
                                    (ClothConditions, byte)[] bonusCondition;
                                    XmlNode bonusConditions = GetFirstXmlNode(card.ChildNodes, "BonusConditions");
                                    if (bonusConditions != null)
                                    {
                                        bonusCondition = new (ClothConditions, byte)[bonusConditions.ChildNodes.Count];
                                        for (int j = 0; j < bonusCondition.Length; j++)
                                        {
                                            bonusCondition[j].Item1 = new ClothConditions(GetFirstXmlNode(bonusConditions.ChildNodes, "Conditions"));
                                        }
                                    }
                                    else
                                        bonusCondition = new (ClothConditions, byte)[0];
                                    resultCard = new Cloth(price, name, isDoor, image,
                                                                clothType, clothConditions, isBig, bonus, bonusCondition);
                                    break;
                            }
                            cards.Add(resultCard);
                        }
                    }
                }
                return cards;
            }
            else
                return null;
        }

        internal static XmlNode GetFirstXmlNode(XmlNodeList list, string name)
        {
            foreach (XmlNode node in list)
            {
                if (node.Name == name)
                    return node;
            }
            return null;
        }
    }
}
