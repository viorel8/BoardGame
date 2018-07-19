using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame
{
    public class GameEngine : NeverEndingTask, IGameEngine
    {
        public IGameLogic GameLogic { get; private set; }
        public ConcurrentQueue<char> ConsoleCommand { get; set; }
        
        /// <summary>
        /// This represents the current state of the game
        /// </summary>
        public GameStatus CurrentState { get; private set; }

        public GameEngine(IGameLogic gameLogic)
        {
            ConsoleCommand = new ConcurrentQueue<char>();
            GameLogic = gameLogic;
            this.CurrentState = new GameStatus() { GameState = GameProgress.INIT, Message = $"Game Initialised" };
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Stop()
        {
            base.Stop();
        }

        protected override void ExecutionCore(CancellationToken cancellationToken)
        {
                if (ConsoleCommand.Count == 0)
                    return;

                var entry = new char();
                ConsoleCommand.TryDequeue(out entry);
                CurrentState.GameState = GameLogic.PlayAction(entry);


            if (CurrentState.GameState == GameProgress.WIN)
            {
                var message = "You Win !";
                CurrentState.Message = message;
                Console.WriteLine(message);
                Stop();
            }
            else if (CurrentState.GameState == GameProgress.LOSE)
            {
                var message = "You Lose !";
                CurrentState.Message = message;
                Console.WriteLine(message);
                Stop();
            }
            else
            {
                Console.WriteLine("Next move please!");
            }

        }
    }
}
