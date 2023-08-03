using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    public class Game
    {
        public int Id { get; }
        static int count;
        Player[] players;
        Stack<Card> doors;
        Stack<Card> treasuares;
        Stack<Card> dropDoors;
        Stack<Card> dropTreasuares;
        int selectedPlayer;
        Random cube;

        internal void Drop(Card card)
        {
            if (card.isDoor) 
                dropDoors.Push(card);
            else
                dropTreasuares.Push(card);
        }

        public Game(byte playersCount, List<Card> cards)
        {
            count++;
            Id = count;
            players = new Player[playersCount];
            cube = new Random();
            doors = new Stack<Card>();
            treasuares = new Stack<Card>();
            dropDoors = new Stack<Card>();
            dropTreasuares = new Stack<Card>();
            int index = cube.Next(cards.Count);
            while (cards.Count > 0)
            {
                if (cards[index].isDoor)
                    doors.Push(cards[index]);
                else
                    treasuares.Push(cards[index]);
                cards.RemoveAt(index);
            }
        }
    }
}
