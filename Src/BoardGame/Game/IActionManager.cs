using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public interface IActionManager
    {
        bool CurrentActionChanged { get; }

        void SetCurrentPlayer(IGameEntity currentPlayer);

        ActionResult ExecuteCurrentAction(ActionType actonType);
    }
}
