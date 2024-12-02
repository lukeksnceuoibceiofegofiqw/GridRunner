using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunner.Program
{
    /// <summary>
    /// The type of excersize.
    /// </summary>
    internal abstract class Mode
    {
        internal Position goal;
        internal abstract bool Finished(State state);
    }

    internal class PathfindingExerciseMode : Mode
    {
        
        internal PathfindingExerciseMode(Position goal)
        {
            this.goal = goal;
        }

        internal override bool Finished(State state)
        {
            if (state.guy == goal)
            {
                state.output += "Completed Excersize";
                return true;
            }
            state.output += "Guy is not on goal :(";
            return state.guy == goal;
        }


    }

    internal class ShapeExcrciseMode : Mode
    {
        
        //also the start
        internal ShapeExcrciseMode(Position start)
        {
            this.goal = start;
        }

        internal override bool Finished(State state)
        {
            bool[,] obstructions = (bool[,])state.world.obstructions.Clone();

            Position last = state.path[0]; 

            foreach (Position p in state.path)
            {
                for (int x = last.x; x <= p.x; x++)
                {
                    for (int y = last.y; y <= p.y; y++)
                    {
                        obstructions[x, y] = true;
                    }
                }

            }

            foreach (bool b in obstructions)
            {
                if (b)
                    continue;
                state.output += "didNotFillShape! :(";
                return false;
            }
            if (state.guy == goal)
            {
                state.output += "Completed Excersize";
                return true;
            }
            state.output += "Guy is not back at start :(";
            return state.guy == goal;
        }
    }

}
