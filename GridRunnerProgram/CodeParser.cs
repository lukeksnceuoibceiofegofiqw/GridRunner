using GridRunnerProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridRunner.Program
{
    internal static class CodeParser
    {
        static List<(int indent, string command)> cmds = new();
        static int line = 0;

        internal static Command? Parse(string code)
        {
            //split string on newline tokens
            char[] del = { '\n', '\r' };
            List<string> ss = new(code.Split(del).Where((string s) => s != ""));


            //save command and indentation in new list
            cmds = new();
            foreach (string s in ss)
            {
                List<char> cs = new(s);
                int n = 0;

                for (; 0 < cs.Count && cs[0] == '\t'; n++) { cs.RemoveAt(0); }

                cmds.Add((n, new(cs.ToArray())));
            }

            //parse commands to linked CodeBlocks
            line = 0;

            return ParseCommands(0);

            
        }
        static Command? ParseCommands(int indentation)
        {
            //if line doesn't exist return null to signify the end of a list of commands
            if (line >= cmds.Count)
            {
                return null;
            }

            //the end of an indented block has been reached if the indent doesn't match return null without changing the line
            if (cmds[line].indent != indentation)
            {
                return null;
            }
            string[] cmd = cmds[line].command.Split(' ');
            line++;

            if (cmd.Length == 0)
            {
                return ParseCommands(indentation);
            }
            Command cb = CommandRecognition(cmd, indentation);

            cb.next = ParseCommands(indentation);
            return cb;
        }

        static Command CommandRecognition(string[] cmd, int indentation)
        {
            Command cb;

            switch (cmd[0])
            {
                case ("Move"):
                    {
                        cb = new MoveCommand(int.Parse(cmd[1]));
                    }
                    break;
                case "Turn":
                    {
                        if (cmd[1] == "right")
                        {
                            cb = new TurnCommand(1);
                            break;
                        }
                        if (cmd[1] == "left")
                        {
                            cb = new TurnCommand(-1);
                            break;
                        }
                        throw new Exception("Direction " + cmd[1] + " not recognised. Did you mean right or left?");
                    }
                case "Repeat":
                    {
                        cb = new RepeatCommand(int.Parse(cmd[1]), ParseCommands(indentation + 1));
                    }
                    break;
                case "RepeatUntil":
                    {
                        cb = new UntilCommand(Conditional.Parse(cmd[1]), ParseCommands(indentation + 1));
                    }
                    break;
                case "If":
                    {
                        cb = new IfCommand(Conditional.Parse(cmd[1]), ParseCommands(indentation + 1));
                    }
                    break;
                default:
                    {
                        throw new Exception("command " + cmd[0] + " not recognised");
                    }
            }
            return cb;
        }

    }
}
