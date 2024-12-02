using GridRunnerProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunner.Program
{
    internal abstract class Command
    {
        internal Command? next;

        /// <summary>
        /// returns new command point
        /// </summary>
        /// <returns></returns>
        
        internal virtual bool Run(State s)
        {
            bool err = ChangeState(s);
            
            if (err)
            {
                return err;
            }


            if (next == null)
                return false;
            return next.Run(s);

        }
        
        internal virtual int LineCount()
        {
            if (next == null)
                return 1;
            return next.LineCount()+1;
        }

        internal virtual int Depth()
        {
            return 1;
        }

        protected virtual bool ChangeState(State s)
        {
            return false;
        }



    }

    internal class MoveCommand : Command
    {
        int num;
        internal MoveCommand(int i)
        {
            num = i;
        }

        protected override bool ChangeState(State s)
        {
            for(int i = 0; i<num;i++)
            {
                Position np = s.dir.Move(s.guy);
                if (np.x<0||np.x>=s.world.width||np.y<0||np.y>=s.world.height)
                {
                    s.error = new CollisionError(s.guy, s.dir);
                    s.output += "Collided";
                    s.path.Add(s.guy);
                    return true;
                }

                if (s.world.obstructions[np.x, np.y])
                {
                    s.error = new CollisionError(s.guy, s.dir);
                    s.output += "Collided";
                    s.path.Add(s.guy);
                    return true;
                }
                s.guy = s.dir.Move(s.guy);
            }
            s.output += $"Move {num}, ";

            s.path.Add(s.guy);


            return false;
        }
    }

    internal class TurnCommand : Command
    {
        int num;
        internal TurnCommand(int i)
        {
            num = i;
        }
        protected override bool ChangeState(State s)
        {
            s.dir = s.dir.Turn(num);
            for (int i = num; i > 0; i--)
                s.output += "Turned right, ";
            for (int i = num; i < 0; i++)
                s.output += "Turned left, ";
            return false;
        }
    }

    internal class RepeatCommand : Command
    {
        int num;
        Command? internals;

        public RepeatCommand(int i, Command? block)
        {
            internals = block;
            num = i;
        }

        internal override bool Run(State s)
        {
            if (internals != null)
            {
                for (int i = 0; i < num; i++)
                {
                    if (internals.Run(s))
                        return true;
                }
            }
            return base.Run(s);
        }

        internal override int Depth()
        {
            if (internals == null)
                return 1;
            return internals.Depth()+1;
        }

        internal override int LineCount()
        {
            if (internals == null)
                return base.LineCount();
            return internals.LineCount()+base.LineCount();
        }

    }

    internal class UntilCommand : Command
    {
        Conditional cond;
        Command? internals;

        public UntilCommand(Conditional i, Command? block)
        {
            internals = block;
            cond = i;
        }

        internal override bool Run(State s)
        {
            if (internals != null)
            {
                int failsafe = 100;
                while(!cond.Test(s))
                {
                    failsafe--;
                    if (failsafe == 0)
                    {
                        s.error = new LoopError();
                        return true;
                    }
                    if (internals.Run(s))
                        return true;
                }
            }
            return base.Run(s);
        }

        internal override int Depth()
        {
            if (internals == null)
                return 1;
            return internals.Depth() + 1;
        }

        internal override int LineCount()
        {
            if (internals == null)
                return base.LineCount();
            return internals.LineCount() + base.LineCount();
        }

    }

    internal class IfCommand : Command
    {
        Conditional cond;
        Command? internals;

        public IfCommand(Conditional i, Command? block)
        {
            internals = block;
            cond = i;
        }

        internal override bool Run(State s)
        {
            if (internals != null)
            {
                if (cond.Test(s))
                {
                    if (internals.Run(s))
                        return true;
                }
            }
            return base.Run(s);
        }

        internal override int Depth()
        {
            if (internals == null)
                return 1;
            return internals.Depth() + 1;
        }

        internal override int LineCount()
        {
            if (internals == null)
                return base.LineCount();
            return internals.LineCount() + base.LineCount();
        }

    }

}
