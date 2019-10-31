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

        public int Value { get; set; }
        #region constructor
        public Card()
        {
            this.Width = 100;
            this.Height = 150;
            this.BackColor = Color.Red;
            this.Value = Value;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        #endregion

    }

    class CardPanel : System.Windows.Forms.Panel, ICardPanel
    {

        #region Properties
        private readonly int row, column, m;

        //panel row
        public int Row { get; set; }
        //panel column
        public int Column { get; set; }
        //panel margin
        public int M { get; set; }
        //random
        Random rng = new Random();
        Boolean firsttry;
        Card compare = new Card();
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
            temp = temp.Select(x => { x.X = (x.X * W + x.X + 3); x.Y = (x.Y * H + x.Y + 3); return x; }).OrderBy(x => rng.Next()).ToList();
            return temp;
        }
        #endregion

        #region
        public List<Image> Animalz(int Row, int Column)
        {
            List<Image> temp = new List<Image>();
            for (int i = 97; i < Row*Column+97; i++)
            {
                temp.Add((Image)Properties.Resources.ResourceManager.GetObject(((char)i).ToString()));
                temp.Add((Image)Properties.Resources.ResourceManager.GetObject(((char)i).ToString()));
            }
            return temp;
        }
        #endregion

        #region Initialize Card
        
        public void Init_Card(System.Windows.Forms.Form x)
        {
            
            Card card = new Card();
            List<Point> tempLocation = Init_Xy(card.Width, card.Height, Row, Column, M);
            List<Image> Animal = Animalz(Row, Column);
            for (int i = 0; i < Row * Column; i++)
            {
                x.Width = this.Width + 23;
                x.Height = this.Height + 49;
                #region properties
                Card temp = new Card();
                temp.Location = tempLocation[i];
                temp.Image = (Image)Animal[i];
                temp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                if(i%2 == 0)
                {
                    temp.Value = i;
                }
                else
                {
                    temp.Value = i-1;
                }
                
                #endregion
                #region Click Event
                temp.Click += delegate(object sender, EventArgs e)
                {
                    #region Compare
                    Card cardTemp = (Card)sender;
                    if (!firsttry)
                    {
                        compare = cardTemp;
                        firsttry = true;
                    }
                    else if (firsttry && compare != cardTemp)
                    {
                        Console.WriteLine($"{compare.Value},{cardTemp.Value}");
                        compare = null;
                        firsttry = false;
                    }
                    #endregion

                    #region Level
                    if (Controls.Count == 0)
                    {
                        if (Column < 4)
                        {
                            Column++;
                            Height += 151;
                        }
                        else if (Row < 6)
                        {
                            Row++;
                            Width += 101;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("You Win");
                            x.Close();
                            this.Row = 4;
                            this.Column = 1;
                            this.Width = (100 * Row) + (M * M);
                            this.Height = (150 * Column) + M * M;
                        }
                        Init_Card(x);
                        #endregion
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
            Card card = new Card();
            this.M = 3;
            this.Row = 4;
            this.Column = 1;
            this.Width = (100 * Row) + (M * M);
            this.Height = (150 * Column) + 6;

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
            x.Width = temp.Width +23;
            x.Height = temp.Height + 48;
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
