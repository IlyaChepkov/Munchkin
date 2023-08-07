namespace Munchkin
{
    public class Player
    {
        private readonly bool isMale;
        public Game Game { get; }
        public Munchkin Munchkin { get; private set; }
        public byte Level { get; private set; }
        public string PlayerName { get; }

        public Player(string playerName, bool isMale, Game game, string munchkinName)
        {
            PlayerName = playerName;
            this.isMale = isMale;
            Munchkin = new Munchkin(this, isMale, munchkinName);
            Game = game;
        }

        public void DropProfession()
        {
           Game.Drop(Munchkin.DropProfession());
        }

        public void OpenDoor()
        {

        }
    }
}