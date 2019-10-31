using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memoryGame
{
    class Card : System.Windows.Forms.PictureBox, ICard
    {
        public int W { get; set; }
        public int H { get; set; }
    }

    class CardPanel : System.Windows.Forms.Panel, ICardPanel
    {

    }

    class PanelButton : IPanelButton
    {
        readonly ICardPanel cardPanel;
        public PanelButton(ICardPanel x)
        {
            this.cardPanel = x;
        }
    }

    class PanelRemote
    {
        public static CardPanel GetPanel()
        {
            return new CardPanel();
        }
    }
}
