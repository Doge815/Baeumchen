﻿using System;
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
        #region Konsolenstuff
        //Konsole anzeigen/verstecken, Konsole nicht schließbar, Readline() abbrechen
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("User32.Dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        const int MF_BYCOMMAND = 0x00000000;
        const int SC_CLOSE = 0xF060;

        const int VK_RETURN = 0x0D;
        const int WM_KEYDOWN = 0x100;

        public static IntPtr ConsoleWindowHnd;
        
        bool live = true;
        Thread Consolethread;

        private void Baumhaus_FormClosing(object sender, FormClosingEventArgs e)
        {
            live = false;
            PostMessage(ConsoleWindowHnd, WM_KEYDOWN, VK_RETURN, 0);
        }
        #endregion

        //Wer das folgende nicht versteht: Hallo Lucas bzw. Herr Dorn
        Bäumchen my_tree;
        Baummaler my_maler;
        public Baumhaus()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            Consolethread = new Thread(IchBinDieKonsole);
            Consolethread.Start();

            InitializeComponent();
            my_tree = new Bäumchen(50);
            my_maler = new Baummaler(my_tree);
            mainholder.SetBaummaler(my_maler);
            rTB_out.Text = string.Join(", ", my_tree.Deep().ToArray());  
        }

        private void nUD_Value_Changed(object sender, EventArgs e)
        {
            if ((NumericUpDown)sender == nUD_max && nUD_max.Value < nUD_min.Value) nUD_max.Value = nUD_min.Value;
            else if ((NumericUpDown)sender == nUD_min && nUD_min.Value > nUD_max.Value && nUD_max.Visible) nUD_min.Value = nUD_max.Value;
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < ((cB_rand.Checked) ? (nUD_count.Value) : (1)); i++) { my_tree.Add(Convert.ToInt32((!cB_rand.Checked) ? (nUD_min.Value) : (rand.Next(Convert.ToInt32(nUD_min.Value), Convert.ToInt32(nUD_max.Value + 1)))), false); }
            my_tree.ForceRedraw();
            resetdeep(string.Join(", ", my_tree.Deep().ToArray()));
        }

        private void resetdeep(string text)
        {
            lb_deep.Text = "Tiefe: " + my_tree.GetDeep().ToString();
            rTB_out.Text = text;
        }

        private void cB_rand_CheckedChanged(object sender, EventArgs e)
        {
            nUD_max.Visible = cB_rand.Checked;
            label1.Visible = cB_rand.Checked;
            label3.Visible = cB_rand.Checked;
            nUD_count.Visible = cB_rand.Checked;
            label2.Text = ((cB_rand.Checked) ? ("min. ") : ("")) + "Wert:";
            if (nUD_min.Value > nUD_max.Value) nUD_min.Value = nUD_max.Value;
        }

        private void bt_console_Click(object sender, EventArgs e)
        {
            var handle = GetConsoleWindow();
            if (bt_console.Text == "zeige Konsole")
            {
                bt_console.Text = "verstecke Konsole";
                ShowWindow(handle, SW_SHOW);
                Console.Clear();

            }
            else
            {
                void Invoset() { bt_console.Text = "zeige Konsole"; }
                try { bt_console.Text = "zeige Konsole"; } catch { Invoke((MethodInvoker)delegate { Invoset(); }); }
                ShowWindow(handle, SW_HIDE);
            }
        }

        private void IchBinDieKonsole()
        {
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
            for (; live ; )
            {
                string code = Console.ReadLine();
                string[] codeparts = code.Split();
                switch(codeparts[0].ToLower())
                {
                    case "reset": try { my_tree.Reset(Convert.ToInt32(codeparts[1])); } catch { my_tree.Reset(50); } Invoke((MethodInvoker)delegate { resetdeep(codeparts[1]); }); break;
                    case "add": try { my_tree.Add(Convert.ToInt32(codeparts[1]), false); } catch { Console.WriteLine("Second argument is missing or wrong. :/"); } my_tree.ForceRedraw(); Invoke((MethodInvoker)delegate { resetdeep(my_tree.Deep().Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}")); }); break;
                    case "addlist":
                        #region
                        for (int i = 1; i< codeparts.Length; i++) my_tree.Add(Convert.ToInt32(codeparts[i]), false);
                        my_tree.ForceRedraw();
                        Invoke((MethodInvoker)delegate { resetdeep(my_tree.Deep().Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}")); });
                        break;
                    #endregion
                    case "close": bt_console_Click(new object(), new EventArgs()); break;
                    case "fill":
                        #region fill
                        int elementscount = 16;
                        try { elementscount = Convert.ToInt32(Math.Pow(2, Convert.ToInt32(codeparts[1]))); } catch { }
                        List<int> final = new List<int>();
                        List<int?> elements = new List<int?>();
                        for (int i = 0; i < elementscount; i++) elements.Add(i);
                        for (int i = 2; i <= elementscount; i *=2)
                        {
                            for(int u = elementscount/i; u<elementscount; u+= elementscount/i)
                            {
                                if(elements[u] != null)
                                {
                                    final.Add(Convert.ToInt32(elements[u]));
                                    elements[u] = null;
                                }
                            }
                        }
                        //Console.WriteLine(final.Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}"));
                        my_tree.Reset(final[0]);
                        for(int i = 1; i < final.Count; i++)
                        {
                            my_tree.Add(final[i], false);
                        }
                        Invoke((MethodInvoker)delegate { resetdeep(final.Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}")); });
                        my_tree.ForceRedraw();
                        break;
                    #endregion
                    case "redraw": my_tree.ForceRedraw(); break;
                    case "remove": try { my_tree.Remove(Convert.ToInt32(codeparts[1])); } catch { Console.WriteLine("Second argument is missing or wrong. :/"); } Invoke((MethodInvoker)delegate { resetdeep(my_tree.Deep().Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}")); }); break;
                    default: Console.WriteLine("unknown command"); break;
                }
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            Image I = mainholder.GetImage();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png|JPG Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Icon (WIP)|*.ico";
            sfd.Title = "Save da image";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Imaging.ImageFormat IF = null;
                System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();
                switch (sfd.FilterIndex)
                {
                    case 1: IF = System.Drawing.Imaging.ImageFormat.Png; break;
                    case 2: IF = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                    case 3: IF = System.Drawing.Imaging.ImageFormat.Bmp; break;
                    case 4: IF = System.Drawing.Imaging.ImageFormat.Gif; break;
                    case 5: IF = System.Drawing.Imaging.ImageFormat.Icon; break;
                }
                I.Save(fs, IF);
                fs.Close();
            }
        }
    }
}
