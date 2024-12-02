using GridRunner.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunnerProgramTests
{
    public class TestCodeParser
    {
        [Fact]
        public void TestEmpty()
        {
            Assert.True(CodeParser.Parse("") == null);
        }
        [Fact]
        public void TestMove()
        {
            Assert.True(CodeParser.Parse("Move 2").GetType() == typeof(MoveCommand));
        }
        [Fact]
        public void TestTurn()
        {
            Assert.True(CodeParser.Parse("Turn right").GetType() == typeof(TurnCommand));
        }

        [Fact]
        public void TestRepeat()
        {
            RepeatCommand c = (RepeatCommand)CodeParser.Parse("Repeat 2\n\tMove 1");
            Assert.True(c.GetType() == typeof(RepeatCommand));

            //the correctness of the internal code is tested in GridRunner tests
        }

    }
}
