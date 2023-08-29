using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    public class Munchkin
    {
        public Profession Profession { get; set; }
        public Race Race { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
        public List<Cloth> Inventory { get; set; } = new List<Cloth>();
        public List<Effect> Effects { get; set; } = new List<Effect>();
        public Player Player { get; set; }
        public short Power => Player.Level;
        public bool IsMale { get; set; }
        public string Name { get; set; }

        internal Munchkin(Player player, bool isMale, string name)
        {
            this.Player = player;
            this.IsMale = isMale;
            this.Name = name;
        }

        internal Profession DropProfession()
        {
            Profession profession = this.Profession;
            this.Profession = null;
            return profession;
        }

        internal void GetCardClouse(Card card) => Hand.Add(card);
    }
}
