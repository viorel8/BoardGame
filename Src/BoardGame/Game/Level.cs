using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public class Level : ILevel
    {
        public ReadOnlyDictionary<string, IGameEntity> Players { get; private set; }
        public IPlayerBoard Board { get; private set; }
        public IActionManager ActionManager { get; private set; }

        public Level(IGameSettings settings, ReadOnlyDictionary<string, IGameEntity> players)
        {
            Board = new PlayerBoard(settings);
            Players = players;

            ActionManager = new ActionManager(Board);
        }

        /// <summary>
        /// Initialise the game setup
        /// </summary>
        /// <returns></returns>
        public bool Initialise()
        {
            if (InitialiseBoard())
                return InitialisePlayers();

            return false;
        }

        /// <summary>
        /// construct the board using some settings
        /// </summary>
        /// <returns></returns>
        public bool InitialiseBoard()
        {
            try
            {
                Board.UpdateBoard();
                OnBoadLoaded(new BoardLoadedEventArgs() { Board = this.Board, TimeReached = DateTime.Now });
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                OnBoadLoadedError(new BoardLoadedEventArgs() { Board = this.Board, TimeReached = DateTime.Now });
            }

            return false;
        }

        /// <summary>
        /// Add the players in the Board
        /// Refactor app is harcoded for only one player
        /// </summary>
        /// <returns></returns>
        public bool InitialisePlayers()
        {
            try
            {
                Players.ToList().ForEach(player =>
                    {
                        var coord = new Tuple<int, int>(player.Value.Position.X, player.Value.Position.Y);
                        UpdateTileOnTheBoard(new Tuple<Tuple<int, int>, Coordonates>(coord, player.Value.Position));
                    });

                ActionManager.SetCurrentPlayer(Players.FirstOrDefault().Value);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public ActionResult ActionReceived(ActionType actionType)
        {
            return ActionManager.ExecuteCurrentAction(actionType);
        }

        public void UpdateTileOnTheBoard(Tuple<Tuple<int, int>, Coordonates> tileData)
        {
            Board.UpdateTile(tileData);
        }

        protected virtual void OnBoadLoaded(BoardLoadedEventArgs e)
        {
            EventHandler<BoardLoadedEventArgs> handler = BoadLoaded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<BoardLoadedEventArgs> BoadLoaded;

        public event EventHandler<BoardLoadedEventArgs> BoadLoadedError;

        protected virtual void OnBoadLoadedError(BoardLoadedEventArgs e)
        {
            EventHandler<BoardLoadedEventArgs> handler = BoadLoadedError;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class BoardLoadedEventArgs : EventArgs
    {
        public IPlayerBoard Board { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
