using GridRunner.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunnerProgram
{
    internal abstract class Conditional
    {
        internal abstract bool Test(State s);

        internal static Conditional Parse(string s)
        {
            switch (s)
            {
                case "SpaceAhead":
                    {
                        return new SpaceAhead();
                    }
                case "WallAhead":
                    {
                        return new BlockAhead();
                    }
                case "GridEdge":
                    {
                        return new GridEdge();
                    }
                case "OnTarget":
                    {
                        return new OnTarget();
                    }
                default:
                    {
                        throw new Exception("conditional not recognised");
                    }
            }
        }

    }

    internal class SpaceAhead : Conditional
    {
        internal override bool Test(State s)
        {
            Position np = s.dir.Move(s.guy);
            if (np.x < 0 || np.x >= s.world.width || np.y < 0 || np.y >= s.world.height)
            {
                return false;
            }

            if (s.world.obstructions[np.x, np.y])
            {
                return false;
            }
            return true;
        }
    }

    internal class BlockAhead : Conditional
    {
        internal override bool Test(State s)
        {
            Position np = s.dir.Move(s.guy);
            if (np.x < 0 || np.x >= s.world.width || np.y < 0 || np.y >= s.world.height)
            {
                return true;
            }

            if (s.world.obstructions[np.x, np.y])
            {
                return true;
            }
            return true;
        }
    }

    internal class GridEdge : Conditional
    {
        internal override bool Test(State s)
        {
            Position np = s.dir.Move(s.guy);
            if (np.x == 0 || np.x == s.world.width - 1 || np.y == 0 || np.y == s.world.height - 1) 
            {
                return true;
            }

            return false;
        }
    }

    internal class OnTarget : Conditional
    {
        internal override bool Test(State s)
        {
            return s.guy == s.Target();
        }
    }

}
