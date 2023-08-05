namespace Munchkin
{
    public class Player
    {
        readonly string playerName;
        readonly bool isMale;
        byte level = 1;
        Munchkin munchkin;
        Game game;
        public byte Level => level;

        public Player(string playerName, bool isMale, Game game, string munchkinName)
        {
            this.playerName = playerName;
            this.isMale = isMale;
            munchkin = new Munchkin(this, isMale, munchkinName);
            this.game = game;
        }

        public void DropProfession()
        {
           game.Drop(munchkin.DropProfession());
        }
    }
}