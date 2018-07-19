using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public interface IPlayerBoard
    {

        GameSettings Settings { get; }

        /// <summary>
        /// Generate the tiles
        /// </summary>
        /// <returns></returns>
        bool UpdateBoard();

        /// <summary>
        /// Update a tile with a new value that it toock from the player state
        /// </summary>
        /// <param name="playerCoordonates"></param>
        void UpdateTile(Tuple<Tuple<int, int>, Coordonates> state);
    }
}
