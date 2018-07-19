using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public enum GameProgress
    {
        /// <summary>
        /// Initialise game
        /// </summary>
        INIT,
        /// <summary>
        /// When wining the game
        /// </summary>
        WIN,
        /// <summary>
        /// when losing the game
        /// </summary>
        LOSE,
        /// <summary>
        /// when plaing the game
        /// </summary>
        ONGOING
    }
}
