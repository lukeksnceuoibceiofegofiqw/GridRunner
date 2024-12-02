using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO_3;
using Xunit;
using GridRunner.Program;

namespace MSO_3Tests
{
   class FakeGridRunner : GridRunner.Program.GridRunnerProgram
    {

    }


    public class TestUIMediator
    {

        

        [Fact]
        public void Test()
        {
            UIMediator m = new(new());
            Assert.NotNull(m);



        }



    }
}
