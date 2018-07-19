using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public class Tile : IGameEntity
    {
        public Coordonates Position { get; private set; }

        public void UpdatePosition(Coordonates position)
        {
            Position = position;
        }
    }
}
