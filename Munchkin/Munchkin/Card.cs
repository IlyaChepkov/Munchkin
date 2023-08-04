using System.Xml;

namespace Munchkin
{
    public abstract class Card
    {
        readonly int? price;
        readonly string name;
        internal readonly bool isDoor;
        readonly string image;

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

                        }
                    }
                }
                return cards;
            }
            else
                return null;
        }

        private static XmlNode GetFirstXmlNode(XmlNodeList list, string name)
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
