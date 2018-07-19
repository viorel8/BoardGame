using System;

namespace BoardGame
{


    public class GameStatus
    {
        public GameStatus()
        {
            GameState = GameProgress.ONGOING;
        }

        public void SetStatus(GameProgress state)
        {
            GameState = state;
            Console.WriteLine($"State modified: {state}");
        }

        public GameProgress GameState { get; set; }

        public string Message { get; set; }
    }
}
