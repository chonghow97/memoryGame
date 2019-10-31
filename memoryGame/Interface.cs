using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memoryGame
{
    interface ICard
    {
        //width
        int W { get; set; }
        //height
        int H { get; set; }
    }

    interface ICardPanel
    {
        //row
        //column
        //List Location Point
        //List Animal Image
    }

    interface IPanelButton
    {
        //Execute
        //Undo
    }
}
