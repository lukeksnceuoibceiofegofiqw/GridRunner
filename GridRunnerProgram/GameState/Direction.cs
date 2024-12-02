using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace GridRunner.Program
{
    public struct Direction
    {
        byte dir;


        public Direction (int i)
        {
            dir = (byte)((i % 4 + 4) % 4); 
        }

        public string direction
        {
            get
            {
                switch (dir)
                {
                    case 0:
                        return "north";
                    case 1:
                        return "east";
                    case 2:
                        return "south";
                    case 3:
                        return "west";
                    default:
                        return "";
                        
                }
            }
        }

        internal Direction TurnRight()
        {
            return new Direction(dir + 1); 
        }
        internal Direction TurnLeft()
        {
            return new Direction(dir - 1);
        }

        /// <summary>
        /// Creates new Direction turned i times to the right
        /// </summary>
        /// <param name="i">1: right, -1: left</param>
        /// <returns></returns>
        internal Direction Turn(int i)
        {
            return new Direction(dir + i);
        }


        internal Position Move(Position p)
        {
            switch (dir)
            {
                case 0:
                    return new Position(p.x, p.y - 1);
                case 1:
                    return new Position(p.x + 1, p.y);
                case 2:
                    return new Position(p.x, p.y + 1);
                case 3:
                    return new Position(p.x - 1, p.y);
                default:
                    return p;
            }
        }


    }
}
