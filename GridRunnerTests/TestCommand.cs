using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridRunner.Program;

namespace GridRunnerProgramTests
{
    public class TestCommand
    {
        [Fact]
        public void TestEmptyMove()
        {
            State s = WorldParser.Parse("oox\n");
            Command c = CodeParser.Parse("Move 2");

            c.Run(s);

            Assert.True(s.guy == new Position(2, 0));
        }

        [Fact]
        public void TestCollisionMove()
        {
            State s = WorldParser.Parse("oo+ox\n");
            Command c = CodeParser.Parse("Move 4");

            bool errored = c.Run(s);

            

            Assert.True(s.guy == new Position(1, 0));

            RunError error = s.error;
            Assert.True(errored);
            Assert.True(error.GetType() == typeof(CollisionError));

            Assert.True(((CollisionError)error).beforeCollisionPosition == new Position(1, 0));
            Assert.True(((CollisionError)error).beforeCollisionDirection.direction == "east");


        }


        [Fact]
        public void TestOutOfBoundsMove()
        {
            State s = WorldParser.Parse("o0\nox\noo");
            Command c = CodeParser.Parse("Move 4");

            bool errored = c.Run(s);



            Assert.True(s.guy == new Position(1, 0));

            RunError error = s.error;
            Assert.True(errored);
            Assert.True(error.GetType() == typeof(CollisionError));

            Assert.True(((CollisionError)error).beforeCollisionPosition == new Position(1, 0));
            Assert.True(((CollisionError)error).beforeCollisionDirection.direction == "east");


        }



        [Fact]
        public void TestMoveNTurn()
        {
            State s = WorldParser.Parse("ooo\nx+o\nooo");
            Command c = CodeParser.Parse("Move 2\nTurn right\nMove 2\nTurn right\nMove 2\nTurn left\nTurn left\nTurn left\nMove 1");

            c.Run(s);

            Assert.True(s.Finished());
        }

        [Fact]
        public void TestRepeat()
        {
            State s = WorldParser.Parse("ooo\nx+o\nooo");
            Command c = CodeParser.Parse("Move 2\nTurn right\nMove 2\nTurn right\nMove 2\nRepeat 3\n\tTurn left\nMove 1");

            c.Run(s);

            Assert.True(s.Finished());
        }



    }
}
