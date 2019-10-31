using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memoryGame
{
    class ScorePanel : System.Windows.Forms.Panel
    {
        public ScorePanel(System.Windows.Forms.Form x)
        {
            Width = 100;
            Height = 100;
            BackColor = System.Drawing.Color.LightBlue;
            Location = new System.Drawing.Point(x.Width-300, x.Height -175);
        }

    }
}
