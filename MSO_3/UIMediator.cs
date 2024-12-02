using GridRunner.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_3
{


    /// <summary>
    /// contains all actions that can be performed with the GUI.
    /// </summary>
    internal class UIMediator
    {
        // Contains all functions that can be used by UI elements.
        // This improves consistency
        ProgramEditor editor = new TextEditor();


        GridRunner.Program.GridRunnerProgram program;
        FileManager fileManager;


        public State state { get { RefreshCode();  return program.State; } }
        public int Depth { get { RefreshCode();  return program.CodeDepth; } }
        public int LineCount { get { return program.CodeLineCount; } }
        
        public UIMediator(GridRunner.Program.GridRunnerProgram grp)
        {
            program = grp;
            fileManager = new();
        }

        public void SetProgramEditor(ProgramEditor pe)
        {

            
            editor = pe;
        }

        public string? OpenTextFile()
        {
            string? s = fileManager.OpenTextFile();
            if (s == null)
            {
                MessageBox.Show("Failed to read file");
            }
            return s;
        }

        public void LoadWorld()
        {
            string? w = OpenTextFile();
            if (w == null) return;
            program.SetWorld(w);
        }

        public void LoadCode()
        {
            string? code = OpenTextFile();
            if (code == null) return;
            editor.SetCode(code);
            program.QuickloadProgram(code);   
        }

        public void LoadExcersize1()
        {
            program.SetWorld("+soo+\r\noo+oo\r\no+++o\r\noo+oo\r\n+ooo+");
        }

        public void LoadExcersize2()
        {
            program.SetWorld("oo+++\r\n+oo++\r\n++o++\r\n++o++\r\n++oox");
        }

        public void Run()
        {
            RefreshCode();
            RunError? re = program.Run();

            if (re == null)
                return;

            MessageBox.Show(re.Print());
        }

        public void Reset()
        {
            program.Reset();
        }

        public void RefreshCode()
        {
            program.QuickloadProgram(editor.GetCode());
        }

    }
}
