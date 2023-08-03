using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    internal class Munchkin
    {
        Profession profession;
        Race race;
        List<Card> hand = new List<Card>();
        List<Cloth> inventory = new List<Cloth>();
        List<Effect> effects = new List<Effect>();
        Player player;
        short Power => player.Level;
        bool isMale;
        string name;

        internal Profession DropProfession()
        {
            Profession profession = this.profession;
            this.profession = null;
            return profession;
        }
    }
}
