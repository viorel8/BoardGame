using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public interface IMoveStrategy
    {
        void ExecuteMove(Coordonates coordonates);
    }


    public class Player : IGameEntity
    {

        private IDictionary<Cardinal, IMoveStrategy> moveStrategies;

        public Coordonates Position { get; private set; }

        public string Name { get; set; }
        public Player(Coordonates position)
        {
            this.Position = position;

            moveStrategies = new Dictionary<Cardinal, IMoveStrategy>();
            moveStrategies.Add(Cardinal.N, new UpMoveStrategy());
            moveStrategies.Add(Cardinal.S, new DownMoveStrategy());
            moveStrategies.Add(Cardinal.V, new LeftMoveStrategy());
            moveStrategies.Add(Cardinal.E, new RightMoveStrategy());
        }


        public void Move(Cardinal direction)
        {
            moveStrategies[direction].ExecuteMove(Position);
        }

        public void UpdatePosition(Coordonates position)
        {
            Position = position;
        }
    }

    public class UpMoveStrategy : IMoveStrategy
    {
        public void ExecuteMove(Coordonates coordonates)
        {
            coordonates.Y++;
            Console.WriteLine("M");
        }
    }

    public class DownMoveStrategy : IMoveStrategy
    {
        public void ExecuteMove(Coordonates coordonates)
        {
            coordonates.Y--;
            Console.WriteLine("D");
        }
    }

    public class LeftMoveStrategy : IMoveStrategy
    {
        public void ExecuteMove(Coordonates coordonates)
        {
            coordonates.X--;
            Console.WriteLine("L");
        }
    }

    public class RightMoveStrategy : IMoveStrategy
    {
        public void ExecuteMove(Coordonates coordonates)
        {
            coordonates.X++;
            Console.WriteLine("R");
        }

    }
}
