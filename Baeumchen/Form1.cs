using System;
using System.Windows.Forms;
using System.Threading;


using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Baeumchen
{
    public partial class Baumhaus : Form
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        //Wer das folgende nicht versteht: Hallo Lukas mit "c" bzw. Herr Dorn
        Bäumchen my_tree;
        Baummaler my_maler;
        public Baumhaus()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
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

        private void bt_console_Click(object sender, EventArgs e)
        {
            //my_tree.Reset(50);
            Thread Consolethread = new Thread(IchBinDieKonsole);
            Consolethread.Start();
        }

        private void IchBinDieKonsole()
        {
            var handle = GetConsoleWindow();
            /*if (cb_console.Checked)
            {
                ShowWindow(handle, SW_SHOW);
                Console.Clear();
            }
            else
                ShowWindow(handle, SW_HIDE);*/
            ShowWindow(handle, SW_SHOW);
            Console.Clear();
            for(; ; )
            {
                Console.ReadLine();
                Console.WriteLine("Hello, World!");
            }
        }
    }
}
