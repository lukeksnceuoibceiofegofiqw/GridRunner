using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using GridRunner.Program;

namespace GridRunnerProgramTests
{
    public class TestDirection
    {

        [Fact]
        public void CreateTest()
        {
            Assert.True(new Direction(0).direction == "north");
        }

        [Fact]
        public void TurnRight_test()
        {
            Direction dir = new Direction(1);
            Assert.True(dir.TurnRight().direction == "south");
        }

        [Fact]
        public void NegativeTest()
        {
            Assert.True(new Direction(-4).direction == "north");
        }

        [Fact]
        public void MoveTest()
        {
            Assert.True(new Direction(1).Move(new(0, 0)) == new Position(1, 0));
        }

    }
}
