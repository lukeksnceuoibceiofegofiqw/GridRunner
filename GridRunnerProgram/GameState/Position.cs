﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GridRunner.Program
{
    public struct Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator == (Position p1, Position p2)
        {
            return (p1.x == p2.x && p1.y == p2.y);
        }

        public static bool operator != (Position p1, Position p2)
        {
            return !(p1 == p2); 
        }
    }


}
