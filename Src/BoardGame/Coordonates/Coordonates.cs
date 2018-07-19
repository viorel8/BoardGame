using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{

    public enum Cardinal
    {
        N,E,S,V
    }
    public class Coordonates
    {
        /// <summary>
        /// This is the X coordonate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// This is the Y coordonate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// This is the state of the souroundings if this tile
        /// </summary>
        public Cardinal Orientation { get; set; }


        public Coordonates(int x, int y, Cardinal orientation)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
        }
    }
}
