using GridRunner.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunnerProgramTests
{
    public class TestWorldParser
    {
        [Fact]
        public void SizeWidtTest()
        {
            int width = WorldParser.Parse("o++\n++x").world.width;
            Assert.True(width == 3);
        }
        [Fact]
        public void SizeHeightTest()
        {
            Assert.True(WorldParser.Parse("o+\n+x\n++").world.height == 3);
        }


        [Fact]
        public void ShapeModeTest()
        {
            Assert.True(WorldParser.Parse("s+\n+0").mode.GetType() == typeof(ShapeExcrciseMode));
        }
        [Fact]
        public void PathfindingModeTest()
        {
            Assert.True(WorldParser.Parse("x+\n+0").mode.GetType() == typeof(PathfindingExerciseMode));
        }
    }
}
