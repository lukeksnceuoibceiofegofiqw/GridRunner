using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridRunner.Program;

namespace GridRunnerProgramTests
{
    public class TestGridRunnerProgram
    {
        [Fact]
        public void TestShapeSituation()
        {
            GridRunner.Program.GridRunnerProgram gr = new();
            gr.SetWorld("+soo+\n+++++");

            Assert.NotNull(gr.State);
            Assert.True(gr.State.guy == new Position(1, 0));
            Assert.IsType<ShapeExcrciseMode>(gr.State.mode);
            gr.QuickloadProgram("Move 2\nTurn right\nTurn right\nMove 2");

            gr.Run();

            Assert.True(gr.Finished);
        }


        [Fact]
        public void TestPathWrongAnswer()
        {
            GridRunner.Program.GridRunnerProgram gr = new();
            gr.SetWorld("ooxo+\n+++++");

            Assert.NotNull(gr.State);
            Assert.True(gr.State.guy == new Position(0, 0));
            Assert.IsType<PathfindingExerciseMode>(gr.State.mode);
            gr.QuickloadProgram("Move 3");

            gr.Run();

            Assert.False(gr.Finished);
        }

        [Fact]
        public void TestPathError()
        {
            GridRunner.Program.GridRunnerProgram gr = new();
            gr.SetWorld("o+xo+\n++oo+");

            Assert.NotNull(gr.State);
            Assert.True(gr.State.guy == new Position(0, 0));
            Assert.IsType<PathfindingExerciseMode>(gr.State.mode);
            gr.QuickloadProgram("Move 2");

            RunError? err = gr.Run();

            Assert.NotNull(err);
            Assert.IsType<CollisionError>(err);


            Assert.False(gr.Finished);
        }


    }
}
