using GridRunner.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunnerProgramTests
{
    public class TestPosition
    {
        [Fact]
        public void TestEquality()
        {
            Assert.True(new Position(1,0) == new Position(1,0));
        }
    }
}
