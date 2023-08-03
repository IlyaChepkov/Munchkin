using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    internal class Game
    {
        Player[] players;
        Stack<Card> doors;
        Stack<Card> treasuares;
        Stack<Card> dropDoors;
        Stack<Card> dropTreasuares;
        Player selectedPlayer;

        internal void Drop(Card card)
        {
            if (card.isDoor) 
                dropDoors.Push(card);
            else
                dropTreasuares.Push(card);
        }
    }
}
