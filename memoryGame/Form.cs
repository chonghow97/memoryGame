using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memoryGame
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            CardPanel cardPanel = PanelRemote.GetPanel();

            PanelButton panel = new PanelButton(cardPanel);
            panel.Execute(this);
        }
    }
}