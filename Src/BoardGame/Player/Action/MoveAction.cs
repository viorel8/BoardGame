using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public class MoveAction : BaseAction, IAction
    {
        public MoveAction(IActionManager manager)
            : base(manager)
        {

        }

        /// <summary>
        /// We do not change the direction 
        /// We just get to the next step
        /// </summary>
        /// <param name="CurrentPlayer"></param>
        /// <returns></returns>
        public override ActionResult ExecuteAction(IGameEntity CurrentPlayer)
        {
            currentPlayer = CurrentPlayer;

            var player = CurrentPlayer as Player;

            if (player != null)
            {
                player.Move(player.Position.Orientation);
                Console.WriteLine(ConvertDirection(player.Position.Orientation));
            }

            return new ActionResult() { Status = ActionStatus.COMPLETE };
        }


    }
}
