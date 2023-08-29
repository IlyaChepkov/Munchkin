namespace Munchkin
{
    public class Game
    {
        static int countGames;
        private Stack<Card> doors;
        private Stack<Card> treasuares;
        private Stack<Card> dropDoors;
        private Stack<Card> dropTreasuares;
        private Random cube;

        public int Id { get; }
        public Player[] Players { get; }
        public int SelectedPlayer { get; private set; }
        public GameStatusEnum Status { get; private set; }

        public Game(byte playersCount, List<Card> cards)
        {
            countGames++;
            Id = countGames;
            Status = GameStatusEnum.New;
            Players = new Player[playersCount];
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
            if (Status == GameStatusEnum.New)
            {
                int index = Players.ToList().FindIndex(t => t == null);
                if (index < 0)
                    return false;
                if (Players.ToList().Any(t => t != null && t.PlayerName == player.PlayerName))
                    return false;
                Players[index] = player;
                if (Players.ToList().FindIndex(t => t == null) < 0)
                    StartGame();
                return true;
            }
            return false;
        }

        private void StartGame()
        {
            Status = GameStatusEnum.OpenDoor;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < Players.Length; j++)
                {
                    Players[j].Munchkin.GetCardClouse(doors.Pop());
                    Players[j].Munchkin.GetCardClouse(treasuares.Pop());
                }
            }
            SelectedPlayer = 0;
        }

        internal void Drop(Card card)
        {
            if (card.isDoor)
                dropDoors.Push(card);
            else
                dropTreasuares.Push(card);
        }

        internal bool OpenDoor(Player player)
        {
            if (Status == GameStatusEnum.OpenDoor && player == Players[SelectedPlayer])
            {
                Card door = doors.Pop();
                if (door is Monster)
                {
                    Status = GameStatusEnum.Batle;
                    return true;
                }
                else if (door is Damn)
                {
                    Status = GameStatusEnum.FreeTime;
                    return true;
                }
                else
                {
                    Status = GameStatusEnum.FreeTime;
                    return true;
                }
            }
            return false;
        }

        public List<PlayerDto> GetDto()
        {
            List<PlayerDto> playerDtos = new List<PlayerDto>();
            foreach (var player in Players)
            {
                playerDtos.Add(PlayerDto.GetPlayerDto(player));
            }
            return playerDtos;
        }
    }
}
