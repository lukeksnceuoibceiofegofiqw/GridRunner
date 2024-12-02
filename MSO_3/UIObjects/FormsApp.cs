

using System.ComponentModel;
using GridRunner.Program;

namespace MSO_3
{
    /// <summary>
    /// Is responsible for constructing and drawing first level UI elements
    /// </summary>
    internal partial class FormsApp : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gr"></param>
        public FormsApp(UIMediator med)
        {

            Size = new Size(1000, 800);

            AddUI(650, 50, 300, 300,new GridRunnerView(med));
            
            AddUI(650, 400, 300,300, new OutputView(med));

            Controls.Add(new OptionsBar(med));

            ProgramEditor pe = new TextEditor();

            AddUI(50, 50, 550, 650, pe);

            med.SetProgramEditor(pe);

            
        }


        void AddUI(int px, int py, int sx, int sy, Control c)
        {
            Invalidated += (object? o, InvalidateEventArgs ea) => c.Invalidate();
            c.Size = new(sx, sy);
            c.Location = new(px, py);
            Controls.Add(c);
        }

        


    }
}
