using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunner.Program
{
    /// <summary>
    /// contains the entire non code state of gridrunner
    /// </summary>
    public class State
    {
        internal Mode mode;


        //public for draw functions out of this program
        public List<Position> path;
        public Position guy;
        public Direction dir;
        public World world;
        public bool Collided;
        public RunError? error;
        public string output = "";

        internal Position startPosition;
        internal Direction startDirection;
        internal bool finished = false;

        internal State()
        {
            mode = new PathfindingExerciseMode(new Position(1, 0));
            startPosition = new(0,0);
            startDirection = new(1);
            this.world = new World(4, 4, new bool[4,4]);
            world.obstructions[1, 2] = true;
            Reset();
        }

        internal State (Mode mode, Position startPos, Direction startDir, World world)
        {
            this.mode = mode;   
            startPosition = startPos;
            startDirection = startDir;
            this.world = world;
            Reset();
        }

        internal void Reset()
        {
            guy = startPosition;
            dir = startDirection;
            path = new();
            path.Add(startPosition);
            output = "";
            Collided = false;
            error = null;
        }

        internal bool Finished()
        {
            return finished = mode.Finished(this);
        }

        public Position Target()
        {
            return mode.goal;
        }

    }
}
