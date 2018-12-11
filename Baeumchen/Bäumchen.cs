using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Baeumchen
{
    public class Bäumchen   //Die Baum-Hauptklasse
    {
        #region vars
        private  int my_int;    //Eigener Wert
        private List<Bäumchen> sons = new List<Bäumchen> { null, null };    //Jerder Baum KANN 2 Kinder haben
        internal Bäumchen geschlechtslosesElternteil = null;    //aka Vater
        private Baummaler my_maler = null;

        public int Value { get { return my_int; } }
        public List<Bäumchen> Sons {  get { return sons; } }
        #endregion

        public Bäumchen(int value)  //Konstruktor füe den Haupt-Baum 
        {
            my_int = value;
        }

        internal Bäumchen(int value, Bäumchen father)   //Konstruktor der nur genutzt wird, um Kinder zu erzeugen, aber nicht den Haupt-Baum 
        {
            my_int = value;
            geschlechtslosesElternteil = father;
        }

        public void Add(int value) => Add(value, true);

        public void Add(int value, bool redraw)  //Fügt neue Werte hinzu 
        {
            if (value == my_int) goto Skip; //Wenn der Wert gleich dem eigenen ist, wird geskipt
            int pos = (value < my_int) ? (0) : (1);
            if (sons[pos] == null) sons[pos] = new Bäumchen(value, this);   //Wenn kein Sohn an der Position existiert, wird ein neuer erstellt 
            else sons[pos].Add(value);  //wenn einer existiert, wird der Wert weitergegeben
            //if (my_maler != null && redraw) my_maler.UpdateImage();
            Skip:;
        }

        public void ForceRedraw()
        {
            if (my_maler != null) my_maler.UpdateImage();
        }

        public List<int> Deep() //Gibt alle Elemente von sich Söhnen, deren Söhnen, usw. aus 
        {
            List<int> output = new List<int>();
            if (sons[0] != null) output.AddRange(sons[0].Deep());   //wenn ein Sohn existiert, rekursive Ausführung
            output.Add(my_int); //eigenen Wert hinzufügeb
            if (sons[1] != null) output.AddRange(sons[1].Deep());
            return output;
        }

        internal int GetDeep()  //Gibt die Tiefe des Baumes aus 
        {
            int deeper = (sons[0] != null) ? (sons[0].GetDeep()) : (0); //Tiefe vom linken Ast
            deeper = (sons[1] != null) ? ((sons[1].GetDeep()> deeper) ? (sons[1].GetDeep()) : ( deeper)) : (deeper);
            return deeper + 1;  // +1 für die eigene Tiefe
        }

        internal void GetMaler(Baummaler maler) => my_maler = maler;    //Todo: change to prop

        public void Reset (int value)
        {
            my_int = value;
            sons[0] = sons[1] = null;
            if (my_maler != null) my_maler.UpdateImage();
        } 
    }

    public class Baummaler
    {
        #region vars
        private readonly Bäumchen my_Baum;  //Zu zeichnender Baum
        private Bitmap b;   //Bild
        private Graphics g; //Graphik
        private Treeholder t;   //Bildausgabe, benötigt für automatisches Update
        public Bäumchen Baum { get { return my_Baum; } }
        #endregion

        public Baummaler(Bäumchen Baum) //Konstruktor 
        {
            my_Baum = Baum;
            my_Baum.GetMaler(this);
        }

        public void UpdateImage()   //Aktualisiert das angezeigte Bild 
        {
            b = new Bitmap(Convert.ToInt32(Math.Pow(2, my_Baum.GetDeep()) * 50 - 50), my_Baum.GetDeep() * 50);
            //Breite: 2^Tiefe * x; Höhe: Tiefe * x
            //Grund für so große Breite: Abstand von Ästen in tiefster Verzweigung unabhängig von Tiefe
            //Vorteil: alles in jeder Situation gut lesbar
            //Nachteil: extreme Platzverschwendung, da Platz nur bei Ausgeglichenen Bäumen benötigt
            g = Graphics.FromImage(b);
            g.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(0, 0, b.Width, b.Height)); 
            foreach(PunktTextComboAlsTupelErsatz p in GetPoints(my_Baum, g))
            {
                //An allen Knoten Punkt und deren Wert zeichnen
                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(p.Point.X - 20, p.Point.Y - 25 - 20, 40, 40));
                g.DrawString(p.Text, new Font("Impact", 20), new SolidBrush(Color.Black), new Point(p.Point.X, p.Point.Y - 25), new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
            }
            if (t != null) t.SetImage(b);   //Bild aktualisieren
        }

        private List<PunktTextComboAlsTupelErsatz> GetPoints(Bäumchen Baum, Graphics g) //Errechnet die Knotenpunltpunkte und die Knotenpunktwerte 
        {
            List<PunktTextComboAlsTupelErsatz> points = new List<PunktTextComboAlsTupelErsatz>(); //finale Liste
            Dictionary<Bäumchen, Point> daddys = new Dictionary<Bäumchen, Point>();
            List<Bäumchen> possibles = new List<Bäumchen> { Baum };
            //Nein, das will ich nicht erklären, es funktioniert und das reicht
            //Es ist SEHR ineffizient, was die Speichernutzung angeht, hat aber eine nur quadratische Laufzeit
            for (int i = 0; i < my_Baum.GetDeep(); i++)
            {
                List<Bäumchen> news = new List<Bäumchen>();
                Dictionary<Bäumchen, Point> daddy_news = new Dictionary<Bäumchen, Point>();
                for(int u = 1; u <= possibles.Count; u++)
                {
                    if (possibles[u - 1] != null)
                    {
                        Point p = new Point(Convert.ToInt16(b.Width / 2 * (u * 2 - 1) / Math.Pow(2, i)), (i + 1) * 50);
                        points.Add(new PunktTextComboAlsTupelErsatz(p, possibles[u - 1].Value.ToString()));
                        daddy_news.Add(possibles[u - 1], new Point(p.X, p.Y - 25));
                        try { g.DrawLine(new Pen(Color.Black, 5), new Point(p.X, p.Y - 25), daddys[possibles[u - 1].geschlechtslosesElternteil]); } catch { }
                    }
                    try { news.Add(possibles[u - 1].Sons[0]); } catch { news.Add(null); }
                    try { news.Add(possibles[u - 1].Sons[1]); } catch { news.Add(null); }
                }
                daddys = daddy_news;
                possibles = news;
            }
            return points;
        }

        public void SetTreeholder(Treeholder treeholder)    //Setzt die Anzeige 
        {
            t = treeholder;
            UpdateImage();
        }
    }

    public class Treeholder : FlowLayoutPanel
    {
        #region vars
        private PictureBox p = new PictureBox();    //Bilderrahmen
        private Baummaler b;    //Bildbereitsteller
        #endregion

        public Treeholder() //Konstruktor 
        {
            p.SizeMode = PictureBoxSizeMode.AutoSize; //Bilderrahmen nimmt immer Bildgröße ein
            this.AutoScroll = true; //Scrollbar nach bedarf
            this.Controls.Add(p);
        }

        //public void SetImage(Bitmap image) => p.Image = image;  //Bekommt ein Bild und füllt mit ihm den Rahmen

        public void SetImage(Bitmap image)
        {
            try { p.Image = image; }
            catch { p.Invoke((MethodInvoker)delegate { Invoset(image); }); }
        }
        private void Invoset(Bitmap image) { p.Image = image; }

        public void SetBaummaler(Baummaler baummaler)   //Setzt den Maler 
        {
            b = baummaler;
            b.SetTreeholder(this);
        }
    }

    public class PunktTextComboAlsTupelErsatz   //Container, weil Tupel schlimm sind und Structs zu wenig Speicher brauchen
    {
        #region vars
        private Point p;
        string t;
        public Point Point { get { return p; } set => p = value; }
        public string Text { get { return t; } set => t = value; }
        #endregion

        public PunktTextComboAlsTupelErsatz(Point p, string t)  //Konstruktor 
        {
            this.p = p;
            this.t = t;
        }
    }
}