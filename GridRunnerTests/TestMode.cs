using GridRunner.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunnerProgramTests
{
    public class TestMode
    {
        [Fact]
        public void TestShapeEcersizeModeFinished()
        {
            State s = WorldParser.Parse("ooo\n++s");

            s.path = new List<Position> { new(0, 0), new(2, 0), new(2, 1) };
            Assert.True(s.mode.Finished(s), "false negative");
            s.path = new List<Position> { new(1, 0), new(2, 0), new(2, 1) };
            Assert.False(s.mode.Finished(s), "false positive");



        }
    }
}
