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
        //Wer das folgende nicht versteht: Hallo Lucas bzw. Herr Dorn
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
            for(int i = 0; i < ((cB_rand.Checked) ? (nUD_count.Value) : (1)); i++) my_tree.Add(Convert.ToInt32((!cB_rand.Checked)?(nUD_min.Value):(rand.Next(Convert.ToInt32(nUD_min.Value), Convert.ToInt32(nUD_max.Value + 1)))));
            rTB_out.Text = string.Join(", ", my_tree.Deep().ToArray());
            lb_deep.Text = "Tiefe: " + my_tree.GetDeep().ToString();
        }

        private void cB_rand_CheckedChanged(object sender, EventArgs e)
        {
            nUD_max.Visible = cB_rand.Checked;
            label1.Visible = cB_rand.Checked;
            label3.Visible = cB_rand.Checked;
            nUD_count.Visible = cB_rand.Checked;
            label2.Text = ((cB_rand.Checked) ? ("min. ") : ("")) + "Wert:";
        }
    }
}
