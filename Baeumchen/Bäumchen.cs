using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baeumchen
{
    public class Bäumchen
    {
        private readonly int my_int;
        private List<Bäumchen> sons = new List<Bäumchen> { null, null };

        public int Value { get { return my_int; } }
        public List<Bäumchen> Sons {  get { return sons; } }

        public Bäumchen(int value) => my_int = value;

        public void Add(int value)
        {
            if (value == my_int) goto Skip;
            int pos = (value < my_int) ? (0) : (1);
            if (sons[pos] == null) sons[pos] = new Bäumchen(value);
            else sons[pos].Add(value);
            Skip:;
        }

        public List<int> Deep()
        {
            List<int> output = new List<int>();
            if (sons[0] != null) output.AddRange(sons[0].Deep());
            output.Add(my_int);
            if (sons[1] != null) output.AddRange(sons[1].Deep());
            return output;
        }

        internal int GetDeep()
        {
            int deeper = (sons[0] != null) ? (sons[0].GetDeep()) : (0);
            deeper = (sons[1] != null) ? ((sons[1].GetDeep()> deeper) ? (sons[1].GetDeep()) : ( deeper)) : (deeper);
            return deeper + 1;
        }
    }

    public class Baummaler
    {
        private readonly Bäumchen my_Baum;
        private Bitmap b;
        private Graphics g;
        private Treeholder t;

        public Bäumchen Baum { get { return my_Baum; } }
        public Baummaler(Bäumchen Baum)
        {
            my_Baum = Baum;
        }

        public void UpdateImage()
        {
            b = new Bitmap(Convert.ToInt32(Math.Pow(2, my_Baum.GetDeep()) * 50), my_Baum.GetDeep() * 50);
            g = Graphics.FromImage(b);
            //g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(0, 0, b.Width, b.Height));
            SolidBrush brush = new SolidBrush(Color.Red);
            foreach(Point p in GetPoints(my_Baum))
            {
                g.FillRectangle(brush, p.X - 5, p.Y - 5, 10, 10);
            }
            if (t != null) t.SetImage(b);
        }

        private List<Point> GetPoints(Bäumchen Baum)
        {
            List<Point> points = new List<Point>();
            List<Bäumchen> possibles = new List<Bäumchen> { Baum };
            for (int i = 0; i < my_Baum.GetDeep(); i++)
            {
                List<Bäumchen> news = new List<Bäumchen>();
                for(int u = 1; u <= possibles.Count; u++)
                {
                    if (possibles[u - 1] != null) points.Add(new Point(u / possibles.Count * 25, (i + 1) * 50));
                    try { news.Add(possibles[u - 1].Sons[0]); } catch { news.Add(null); }
                    try { news.Add(possibles[u - 1].Sons[1]); } catch { news.Add(null); }
            }
                possibles = news;
            }
            return points;
        }

        public void SetTreeholder(Treeholder treeholder)
        {
            t = treeholder;
            UpdateImage();
        }
    }

    public class Treeholder : FlowLayoutPanel
    {
        private PictureBox p = new PictureBox();
        private Baummaler b;

        public Treeholder()
        {
            p.SizeMode = PictureBoxSizeMode.AutoSize;
            this.AutoScroll = true;
            this.Controls.Add(p);
        }

        public void SetImage(Bitmap image) => p.Image = image;
        public void SetBaummaler(Baummaler baummaler)
        {
            b = baummaler;
            b.SetTreeholder(this);
        }
    }
}