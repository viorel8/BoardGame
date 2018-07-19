using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public class RightAction : BaseAction, IAction
    {
        public RightAction(IActionManager manager)
            : base(manager)
        {

        }
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
