using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunner.Program
{
    public abstract class RunError
    {
        public abstract string Print();
    }

    public class CollisionError : RunError
    {
        Position beforeCollision;
        Direction direction;

        public Position beforeCollisionPosition { get { return beforeCollision; } }
        public Direction beforeCollisionDirection { get { return direction; } }

        public CollisionError(Position beforeCollision, Direction direction)
        {
            this.beforeCollision = beforeCollision;
            this.direction = direction;
        }

        public override string Print()
        {
            return $"CollisionError\ncollided at: ({beforeCollision.x},{beforeCollision.y}), facing: {direction.direction}";
        }  
    }

    public class NoCodeError : RunError
    {
        public override string Print()
        {
            return "No code given";
        }
    }

    public class LoopError : RunError
    {
        public override string Print()
        {
            return "Code Stuck in Loop";
        }
    }

}
