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
    }

    public class Baummaler : PictureBox
    {
        private Bäumchen my_Baum;

        public Bäumchen Baum { get { return my_Baum; } set => my_Baum = value; }
        public Baummaler()
        {
        }
    }
}