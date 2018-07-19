namespace BoardGame
{
    public interface IGameLogic
    {
        bool ValidateKey(char key);

        GameProgress PlayAction(char entry);

    }
}
