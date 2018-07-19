using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGame
{
    public class PlayerBoard: IPlayerBoard
    {
        /// <summary>
        /// This contains the dumensions of the board ans some basic settings
        /// </summary>
        public GameSettings Settings { get; private set; }
        
        /// <summary>
        /// This is a collection with all board Tiles
        /// </summary>
        public IReadOnlyDictionary<Tuple<int, int>, Tile> BoardTiles { get; private set; }

        /// <summary>
        /// Set initial players that will be loaded on the board
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="players"></param>
        public PlayerBoard(IGameSettings settings)
        {
            Settings = settings as GameSettings;

            var errStr = settings != null ? settings.ToString() : "setting suposed not to be null!";
            if (Settings == null)
                throw new ArgumentNullException($"Msg|Settings loading error!||Error| + {errStr}");
        }

        /// <summary>
        /// Creata the  game Board
        /// </summary>
        /// <returns></returns>
        public bool UpdateBoard()
        {
            var tiles = new Dictionary<Tuple<int, int>, Tile>();
            for (int i = 0; i <= Settings.BoardHeight; i++)
            {
                for (int j = 0; j <= Settings.BoardWidth; j++)
                {

                    var tile = new Tile();
                    tile.UpdatePosition(new Coordonates(i, j, Cardinal.N));
                    tiles.Add(new Tuple<int, int>(i, j), tile);
                }
            }

            BoardTiles = tiles;

            return true;
        }
        
        public void UpdateTile(Tuple<Tuple<int, int>, Coordonates> coordonates)
        {
            var tile = new Tile();
            if(BoardTiles.TryGetValue(coordonates.Item1, out tile))
                tile.UpdatePosition(coordonates.Item2);
        }

        /// <summary>
        /// Display the players
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var rows = this.BoardTiles.Partition(Settings.BoardWidth);

            var combinedRows = rows.Reverse().Select(row => { return string.Concat(row); });

            return string.Join("\r\n", combinedRows);
        }
    }
}
