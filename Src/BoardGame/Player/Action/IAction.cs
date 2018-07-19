﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public interface IAction
    {
        ActionResult ExecuteAction(IGameEntity CurrentPlayer);
    }
}
