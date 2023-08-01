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
        List<Card> effect = new List<Card>();
        Player player;
        short Power => player.Level;
        bool isMale;
        string name;
    }
}
