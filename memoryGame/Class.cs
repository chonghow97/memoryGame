using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memoryGame
{
    class Card : System.Windows.Forms.PictureBox, ICard
    {
        #region Properties
        //width
        public int W { get; set; }
        //height
        public int H { get; set; }
        #endregion

        #region constructor
        public Card()
        {
            this.W = this.Width;
            this.H = this.Height;
            this.BackColor = Color.Red;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        #endregion

    }

    class CardPanel : System.Windows.Forms.Panel, ICardPanel
    {
        #region Properties
        //panel row
        public int Row { get; set; }
        //panel column
        public int Column { get; set; }
        //panel margin
        public int M { get; set; }
        //panel point
        public List<Point> Xy { get; set; }
        //panel Image(Animal)
        public List<Image> AnimalImage { get; set; }
        //random
        Random rng = new Random();
        #endregion

        #region Initialize Xy
        public List<Point> Init_Xy(int W, int H, int Row, int Column, int M)
        {
            List<Point> temp = new List<Point>();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    temp.Add(new Point(i, j));
                }
            }
            temp = temp.Select(x => { x.X = (x.X * W + x.X + 3); x.Y = (x.Y * H + x.Y + 3); return x; }).ToList();
            return temp;
        }
        #endregion

        #region Initialize Card
        public void Init_Card(System.Windows.Forms.Form x)
        {
            for (int i = 0; i < Row * Column; i++)
            {
                #region properties
                Card temp = new Card
                {
                    Name = "Card" + i,
                    W = 100,
                    Height = 150,
                };

                List<Point> tempLocation = Init_Xy(temp.Width, temp.Height, Row, Column, M).OrderBy(x => rng.Next()).ToList();
                temp.Location = tempLocation[i];
                temp.BackColor = Color.Red;
                #endregion
                #region Click Event
                temp.Click += delegate (object sender, EventArgs e)
                {
                    Controls.Clear();
                    if (Controls.Count == 0)
                    {
                        if (Column < 4)
                        {
                            Column++;
                        }
                        else if (Row < 6)
                        {
                            Row++;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("You Win");
                            Column = 1;
                            Row = 4;
                        }
                        Init_Card(x);
                    }
                };
                #endregion
                Controls.Add(temp);
            }
        }
        #endregion

        #region constructor
        public CardPanel()
        {
            #region Properties
            this.Width = 800;
            this.Height = 600;
            this.Row = 4;
            this.Column = 1;
            this.M = 3;
            this.Location = new Point(M, M);
            this.BackColor = Color.Black;
            #endregion
        }
        #endregion

    }

    class PanelButton : IPanelButton
    {
        #region declaration
        readonly ICardPanel cardPanel;
        public PanelButton(ICardPanel x)
        {
            this.cardPanel = x;
        }
        #endregion

        #region Execute()
        public void Execute(System.Windows.Forms.Form x)
        {
            CardPanel temp = new CardPanel();
            temp.Init_Card(x);
            x.Controls.Add(temp);
            x.Width = 1024;
            x.Height = 768;
        }
        #endregion

        #region Undo()
        public void Undo()
        {

        }
        #endregion

    }

    class PanelRemote
    {
        public static CardPanel GetPanel()
        {
            return new CardPanel();
        }
    }
}
