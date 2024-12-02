using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_3
{
    
    internal class OptionsBar : ToolStrip
    {
        UIMediator med;

        public OptionsBar(UIMediator med)
        {
            CreateFileoptions();
            CreateExcersizeOptions();
            CreateProgramOptions();
            CreateRunButtons();
            this.med = med; 
        }

        void CreateFileoptions()
        {
            ToolStripDropDownButton fileDrop = new ToolStripDropDownButton();
            
            fileDrop.ShowDropDownArrow = false;
            fileDrop.Text = "File";

            ToolStripButton openWorld = new ToolStripButton();
            openWorld.Text = "LoadWorld";
            openWorld.Size = new(70, 30);
            openWorld.Click += (object? o, EventArgs ea) => med.LoadWorld();
            fileDrop.DropDownItems.Add(openWorld);

            ToolStripButton openCode = new ToolStripButton();
            openCode.Text = "LoadCode";
            openCode.Click += (object? o, EventArgs ea) => med.LoadCode();
            fileDrop.DropDownItems.Add(openCode);


            this.Items.Add(fileDrop);
        }

        void CreateExcersizeOptions()
        {
            ToolStripDropDownButton ExerciseDrop = new ToolStripDropDownButton();

            ExerciseDrop.ShowDropDownArrow = false;
            ExerciseDrop.Text = "Exercises";

            ToolStripButton Load1 = new ToolStripButton();
            Load1.Text = "Excersize 1";
            Load1.Size = new(70, 30);
            Load1.Click += (object? o, EventArgs ea) => med.LoadExcersize1();
            ExerciseDrop.DropDownItems.Add(Load1);

            ToolStripButton Load2 = new ToolStripButton();
            Load2.Text = "Excersize 2";
            Load2.Click += (object? o, EventArgs ea) => med.LoadExcersize2();
            ExerciseDrop.DropDownItems.Add(Load2);


            this.Items.Add(ExerciseDrop);
        }



        void CreateProgramOptions()
        {
            ToolStripDropDownButton ExerciseDrop = new ToolStripDropDownButton();

            ExerciseDrop.ShowDropDownArrow = false;
            ExerciseDrop.Text = "Program";

            ToolStripButton Analyse = new ToolStripButton();
            Analyse.Text = "Analyze";
            Analyse.Size = new(70, 30);
            Analyse.Click += (object? o, EventArgs ea) => MessageBox.Show($"Line Count = {med.LineCount}\n\rCode Depth = {med.Depth}");
            ExerciseDrop.DropDownItems.Add(Analyse);



            this.Items.Add(ExerciseDrop);
        }

        void CreateRunButtons()
        {
            ToolStripButton RunButton = new ToolStripButton();

            RunButton.Text = "Run";

            RunButton.Click += (object? o, EventArgs ea) => med.Run();

            this.Items.Add(RunButton);

            ToolStripButton ResetButton = new ToolStripButton();

            ResetButton.Text = "Reset";

            ResetButton.Click += (object? o, EventArgs ea) => med.Reset();

            this.Items.Add(ResetButton);

        }

    }




}
