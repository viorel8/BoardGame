using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public class GameSettings : IGameSettings
    {
        public string GameName { get; set; }

        public int BoardWidth { get; set; }

        public int BoardHeight { get; set; }

        public void Load()
        {
            GameName = "Revolutionary new game";
            BoardWidth = 5;
            BoardHeight = 5;

            Console.WriteLine("Settings Loaded!");
        }
    }
}
