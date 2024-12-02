using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GridRunnerProgramTests")]

namespace GridRunner.Program

{
    
    public class GridRunnerProgram
    {
        Command? entry;
        
        State state;

        public event EventHandler Changed;

        


        public GridRunnerProgram()
        {
            state = new State();

        }

        public void QuickloadProgram (string s)
        {
            entry = CodeParser.Parse(s);
        }

        public void SetWorld(string s)
        {
            state = WorldParser.Parse(s);
            Changed?.Invoke(null, new());
        }


        public RunError? Run()
        {
            state.Reset();
            if (entry == null)
                return new NoCodeError(); 
            if (entry.Run(state))
            {
                Changed?.Invoke(this, new());
                return state.error;
            }
            Changed?.Invoke(this, new());
            state.Finished();
            return null;
        }

        public void Reset()
        {
            state.Reset();
            Changed?.Invoke(this, new());
        }

        public int CodeDepth
        {
            get
            {
                if (entry == null)
                    return 0;
                return entry.Depth();
            }
        }

        public int CodeLineCount
        {
            get
            {
                if (entry == null)
                    return 0;
                return entry.LineCount();
            }
        }

        public bool Finished
        {
            get
            {
                return state.finished;
            }
        }

        public State State
        {
            get
            { 
                return state; 
            }
        }


    }

}
