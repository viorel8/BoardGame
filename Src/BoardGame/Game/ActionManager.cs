using System;
using System.Collections.Generic;

namespace BoardGame
{
    public class ActionManager: IActionManager
    {
        public bool CurrentActionChanged { get; private set; }

        public IActionValidator ActionValidator { get; private set; }

        public ActionType CurrentAction { get; private set; }

        public IPlayerBoard Board { get; private set; }

        public IGameEntity CurrentPlayer { get; private set; }

        private IDictionary<ActionType, IAction> actionsStrategies;

        public ActionManager(IPlayerBoard board)
        {
            actionsStrategies = new Dictionary<ActionType, IAction>();
            actionsStrategies.Add(ActionType.MOVE, new MoveAction(this));
            actionsStrategies.Add(ActionType.LEFT, new LeftAction(this));
            actionsStrategies.Add(ActionType.RIGHT, new RightAction(this));

            Board = board;
        }

        public void SetCurrentPlayer(IGameEntity currentPlayer)
        {
            CurrentPlayer = currentPlayer;
        }

        public ActionResult ExecuteCurrentAction(ActionType actonType)
        {
            ActionValidator = new ActionValidator(Board);

            var message = string.Empty;
            if (ActionValidator.Validate(CurrentPlayer, out message))
            {
                if ((CurrentAction != actonType) && (actonType != ActionType.MOVE || actonType != ActionType.NONE))
                {
                    CurrentAction = actonType;
                    CurrentActionChanged = true;
                    CurrentPlayer.Position.Orientation = ConvertActionToMove(actonType);
                }

                return actionsStrategies[actonType].ExecuteAction(CurrentPlayer);
            }
            else
                Console.WriteLine(message);

            return new ActionResult() { Status = ActionStatus.FAILURE , Message = message };
        }

        /// <summary>
        /// Map actions
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private Cardinal ConvertActionToMove(ActionType action)
        {
            var card = new Cardinal();

            switch(action)
            {
                case ActionType.LEFT: card = Cardinal.V; break;
                case ActionType.RIGHT: card = Cardinal.E; break;
                default:
                    card = Cardinal.N; break;
            }

            return card;
        }

        public override string ToString()
        {
            //return this.Logic.BoardToString(this.CurrentState);

            return null;
        }


    }

    public interface IActionValidator
    {
        bool Validate(IGameEntity player, out string message);
    }

    public class ActionValidator : IActionValidator
    {
        private IPlayerBoard board;
        public ActionValidator( IPlayerBoard currentBoard)
        {
            this.board = currentBoard;
        }

        public bool Validate(IGameEntity player, out string message)
        {
            message = string.Empty;

            if ((player.Position.X < 0) || (player.Position.X > board.Settings.BoardWidth))
            {
                message = $"User Exeeded the board width limit of the map";
                return false;
            }
            if ((player.Position.Y < 0) || (player.Position.Y > board.Settings.BoardHeight))
            {
                message = $"User Exeeded the board height limit of the map";
                return false;
            }

            return true; 
        }

    }
}
