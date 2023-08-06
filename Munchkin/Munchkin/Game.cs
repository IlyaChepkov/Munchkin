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
        GameStatusEnum status;

        public Game(byte playersCount, List<Card> cards)
        {
            count++;
            Id = count;
            status = GameStatusEnum.New;
            players = new Player[playersCount];
            cube = new Random();
            doors = new Stack<Card>();
            treasuares = new Stack<Card>();
            dropDoors = new Stack<Card>();
            dropTreasuares = new Stack<Card>();
            while (cards.Count > 0)
            {
                int index = cube.Next(cards.Count);
                if (cards[index].isDoor)
                    doors.Push(cards[index]);
                else
                    treasuares.Push(cards[index]);
                cards.RemoveAt(index);
            }
        }

        public bool AddPlayer(Player player)
        {
            if (status == GameStatusEnum.New)
            {
               int index = players.ToList().FindIndex(t => t == null);
                if (index < 0)
                    return false;
                if (players.ToList().Any(t => t.PlayerName == player.PlayerName))
                    return false;
                players[index] = player;
                if (players.ToList().FindIndex(t => t == null) < 0)
                    StartGame();
                return true;
            }
            return false;
        }

        private void StartGame()
        {
            status = GameStatusEnum.OpenDoor;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < players.Length; j++)
                {
                    players[j].Munchkin.GetCardClouse(doors.Pop());
                    players[j].Munchkin.GetCardClouse(treasuares.Pop());
                }
            }
            selectedPlayer = 0;
        }

        internal void Drop(Card card)
        {
            if (card.isDoor)
                dropDoors.Push(card);
            else
                dropTreasuares.Push(card);
        }
    }
}
