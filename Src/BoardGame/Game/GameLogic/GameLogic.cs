using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BoardGame
{
    public class GameLogic : IGameLogic
    {
        public IGameSettings Settings { get; private set; }

        public ILevel Level { get; private set; }

        public static IReadOnlyDictionary<char, string> KeyMap = new Dictionary<char, string>
        {
            { char.Parse("l"), "LEFT" },
            { char.Parse("r"), "RIGHT" },
            { char.Parse("m"), "MOVE" }
        };

        public GameLogic(IGameSettings settings)
        {
            Settings = settings;

            Level = new Level(settings, LoadPlayers());
            Level.Initialise();
        }

        /// <summary>
        /// Refactor get the players as input 
        /// </summary>
        private ReadOnlyDictionary<string, IGameEntity> LoadPlayers()
        {
            var player = new Player(new Coordonates(0, 0, Cardinal.N));
            return new ReadOnlyDictionary<string, IGameEntity>(new Dictionary<string, IGameEntity>() { { "Player1", player } });
        }

        /// <summary>
        /// Delegate the action to action Manager
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public virtual GameProgress PlayAction(char entry)
        {
            Level.ActionReceived(GetActionFromChar(entry));
            return GameProgress.ONGOING;
        }

        public virtual bool ValidateKey(char key)
        {
            return (KeyMap.ContainsKey(key));
        }

        /// <summary>
        /// Convert char to action
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private ActionType GetActionFromChar(char key)
        {
            if (ValidateKey(key))
            {
                return (ActionType)Enum.Parse(typeof(ActionType), KeyMap[key], true);
            }

            return ActionType.NONE;
        }

    }
}
