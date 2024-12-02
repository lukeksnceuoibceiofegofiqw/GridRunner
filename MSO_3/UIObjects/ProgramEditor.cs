using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_3
{
    internal abstract class ProgramEditor : Label
    {
        public abstract string GetCode();
        public abstract void SetCode(string code);  
    }

    internal class TextEditor : ProgramEditor
    {
        RichTextBox textBox;

        public TextEditor()
        {
            textBox = new RichTextBox();
            SizeChanged += (object? o, EventArgs ea) => textBox.Size = Size;
            Controls.Add(textBox);
            textBox.BackColor = Color.AliceBlue;
            textBox.AcceptsTab = true;
        }

        public override string GetCode()
        {
            return textBox.Text;
        }

        public override void SetCode(string code)
        {
            textBox.Text = code;
        }
    }


}
