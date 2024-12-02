using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunner.Program
{

    /// <summary>
    /// reads a world and gives a mode and state
    /// </summary>
    internal static class WorldParser
    {

        internal static State Parse(string text)
        {
            char[] del = { '\n', '\r' };
            List<string> lines = new(text.Split(del).Where((string s) => s != ""));

            int height = lines.Count;
            int width = lines[0].Length;

            bool[,] obstructions = new bool[width, height];

            Mode? mode = null;
            Position start = new(0, 0);


            for (int y = 0; y < height; y++)
            {
                string line = lines[y];

                for (int x = 0; x < width; x++)
                {
                    try
                    {
                        obstructions[x, y] = line[x] == '+';
                        if (line[x] == 'x')
                        {
                            mode = new PathfindingExerciseMode(new(x, y));
                        }
                        if (line[x] == 's')
                        {
                            start = new(x, y);  
                            mode = new ShapeExcrciseMode(new(x, y));
                        }
                    }
                    catch
                    {
                        throw new Exception("Given World not readable \n Should be a perfect rectangle");
                    }
                }
            }

            if (mode == null)
            {
                throw new Exception("No start or end are given. Give a start or an end");
            }


            return (
                new State(
                    mode,
                    start, new Direction(1),
                    new World(width, height, obstructions)
                )
            );


        }

    }

}
