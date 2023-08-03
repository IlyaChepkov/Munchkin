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

        public void DropProfession()
        {
           game.Drop(munchkin.DropProfession());
        }
    }
}