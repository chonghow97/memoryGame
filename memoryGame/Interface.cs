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
        int Width { get; set; }
        //height
        int H { get; set; }
    }

    interface ICardPanel
    {
        //row
        int Row { get; set; }
        //column
        int Column { get; set; }
        //Margin
        int M { get; set; }
        //List Location Point
        List<System.Drawing.Point> Xy { get; set; }
        //List Animal Image
        List<System.Drawing.Image> AnimalImage { get; set; }

        //Method
        void Init_Card(System.Windows.Forms.Form x);
        List<System.Drawing.Point>Init_Xy(int W, int H, int Row, int Column, int M);
    }

    interface IPanelButton
    {
        //Execute
        void Execute(System.Windows.Forms.Form x);
        //Undo
        void Undo();
    }
}
