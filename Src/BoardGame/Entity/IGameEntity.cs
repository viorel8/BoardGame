using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public interface IGameEntity
    {
        Coordonates Position { get; }
        void UpdatePosition(Coordonates state);
    }
}
