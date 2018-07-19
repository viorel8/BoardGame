using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public abstract class BaseAction
    {
        protected IActionManager actionManager = null;

        protected IGameEntity currentPlayer = null;

        public BaseAction(IActionManager manager)
        {
            actionManager = manager;
        }

        public abstract ActionResult ExecuteAction(IGameEntity CurrentPlayer);

        internal string ConvertDirection(Cardinal orientation)
        {
            var str = string.Empty;
            switch (orientation)
            {
                case Cardinal.N: str = "M"; break;
                case Cardinal.E: str = "R"; break;
                case Cardinal.S: str = "M"; break;
                case Cardinal.V: str = "L"; break;
                default:
                    str = "M";
                    break;
            }

            return str;
        }
    }
}
