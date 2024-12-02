using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunner.Program
{
    public class World
    {
        public int width;
        public int height;

        public bool[,] obstructions;

        public World(int x, int y, bool[,] obstructions)
        {
            this.width = x;
            this.height = y;
            this.obstructions = obstructions;

        }

    }
}
