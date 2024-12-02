using GridRunner.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_3
{
    internal class OutputView : Label
    {
        UIMediator mediator;
        public OutputView(UIMediator mediator)
        {
            BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.AntiqueWhite;
            this.mediator = mediator;
            
            Paint += (object? o, PaintEventArgs pea) => { Draw(pea.Graphics); };
        }


        void Draw(Graphics g)
        {
            Text = mediator.state.output;
        }
    }
}
