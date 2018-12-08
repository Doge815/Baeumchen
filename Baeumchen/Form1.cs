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
    public partial class Baumhaus : Form
    {
        Bäumchen my_tree;
        Baummaler my_maler;
        public Baumhaus()
        {
            InitializeComponent();
            my_tree = new Bäumchen(50);
            my_maler = new Baummaler(my_tree);
            mainholder.SetBaummaler(my_maler);
            rTB_out.Text = string.Join(", ", my_tree.Deep().ToArray());  
        }

        private void nUD_Value_Changed(object sender, EventArgs e)
        {
            if ((NumericUpDown)sender == nUD_max && nUD_max.Value < nUD_min.Value) nUD_max.Value = nUD_min.Value;
            else if ((NumericUpDown)sender == nUD_min && nUD_min.Value > nUD_max.Value) nUD_min.Value = nUD_max.Value;
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for(int i = 0; i < nUD_count.Value; i++) my_tree.Add(rand.Next(Convert.ToInt32(nUD_min.Value), Convert.ToInt32(nUD_max.Value + 1)));
            rTB_out.Text = string.Join(", ", my_tree.Deep().ToArray());
            lb_deep.Text = my_tree.GetDeep().ToString();
        }
    }
}
