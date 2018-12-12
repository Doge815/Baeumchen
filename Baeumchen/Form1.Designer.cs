namespace Baeumchen
{
    partial class Baumhaus
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_Add = new System.Windows.Forms.Button();
            this.nUD_min = new System.Windows.Forms.NumericUpDown();
            this.nUD_max = new System.Windows.Forms.NumericUpDown();
            this.rTB_out = new System.Windows.Forms.RichTextBox();
            this.nUD_count = new System.Windows.Forms.NumericUpDown();
            this.lb_deep = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cB_rand = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_console = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.mainholder = new Baeumchen.Treeholder();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_count)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(203, 38);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 23);
            this.bt_Add.TabIndex = 0;
            this.bt_Add.Text = "Hinzufügen";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // nUD_min
            // 
            this.nUD_min.Location = new System.Drawing.Point(77, 38);
            this.nUD_min.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_min.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUD_min.Name = "nUD_min";
            this.nUD_min.Size = new System.Drawing.Size(120, 20);
            this.nUD_min.TabIndex = 1;
            this.nUD_min.ValueChanged += new System.EventHandler(this.nUD_Value_Changed);
            // 
            // nUD_max
            // 
            this.nUD_max.Location = new System.Drawing.Point(380, 38);
            this.nUD_max.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_max.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nUD_max.Name = "nUD_max";
            this.nUD_max.Size = new System.Drawing.Size(120, 20);
            this.nUD_max.TabIndex = 2;
            this.nUD_max.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUD_max.Visible = false;
            this.nUD_max.ValueChanged += new System.EventHandler(this.nUD_Value_Changed);
            // 
            // rTB_out
            // 
            this.rTB_out.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rTB_out.BackColor = System.Drawing.Color.White;
            this.rTB_out.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTB_out.Location = new System.Drawing.Point(12, 133);
            this.rTB_out.Name = "rTB_out";
            this.rTB_out.ReadOnly = true;
            this.rTB_out.Size = new System.Drawing.Size(327, 305);
            this.rTB_out.TabIndex = 3;
            this.rTB_out.Text = "";
            // 
            // nUD_count
            // 
            this.nUD_count.Location = new System.Drawing.Point(380, 76);
            this.nUD_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_count.Name = "nUD_count";
            this.nUD_count.Size = new System.Drawing.Size(120, 20);
            this.nUD_count.TabIndex = 4;
            this.nUD_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_count.Visible = false;
            // 
            // lb_deep
            // 
            this.lb_deep.AutoSize = true;
            this.lb_deep.Location = new System.Drawing.Point(12, 117);
            this.lb_deep.Name = "lb_deep";
            this.lb_deep.Size = new System.Drawing.Size(43, 13);
            this.lb_deep.TabIndex = 6;
            this.lb_deep.Text = "Tiefe: 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Anz. der neuen Elemente:";
            this.label1.Visible = false;
            // 
            // cB_rand
            // 
            this.cB_rand.AutoSize = true;
            this.cB_rand.Location = new System.Drawing.Point(12, 12);
            this.cB_rand.Name = "cB_rand";
            this.cB_rand.Size = new System.Drawing.Size(78, 17);
            this.cB_rand.TabIndex = 8;
            this.cB_rand.Text = "Zufall aktiv";
            this.cB_rand.UseVisualStyleBackColor = true;
            this.cB_rand.CheckedChanged += new System.EventHandler(this.cB_rand_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Wert:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "max. Wert:";
            this.label3.Visible = false;
            // 
            // bt_console
            // 
            this.bt_console.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_console.Location = new System.Drawing.Point(716, 12);
            this.bt_console.Name = "bt_console";
            this.bt_console.Size = new System.Drawing.Size(121, 23);
            this.bt_console.TabIndex = 11;
            this.bt_console.Text = "zeige Konsole";
            this.bt_console.UseVisualStyleBackColor = true;
            this.bt_console.Click += new System.EventHandler(this.bt_console_Click);
            // 
            // bt_save
            // 
            this.bt_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_save.Location = new System.Drawing.Point(716, 41);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(121, 23);
            this.bt_save.TabIndex = 12;
            this.bt_save.Text = "Baum speichern unter";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // mainholder
            // 
            this.mainholder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainholder.AutoScroll = true;
            this.mainholder.Location = new System.Drawing.Point(345, 133);
            this.mainholder.Name = "mainholder";
            this.mainholder.Size = new System.Drawing.Size(492, 329);
            this.mainholder.TabIndex = 5;
            // 
            // Baumhaus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 477);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_console);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cB_rand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_deep);
            this.Controls.Add(this.mainholder);
            this.Controls.Add(this.nUD_count);
            this.Controls.Add(this.rTB_out);
            this.Controls.Add(this.nUD_max);
            this.Controls.Add(this.nUD_min);
            this.Controls.Add(this.bt_Add);
            this.MinimumSize = new System.Drawing.Size(865, 516);
            this.Name = "Baumhaus";
            this.ShowIcon = false;
            this.Text = "Baumhaushauer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Baumhaus_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.NumericUpDown nUD_min;
        private System.Windows.Forms.NumericUpDown nUD_max;
        private System.Windows.Forms.RichTextBox rTB_out;
        private System.Windows.Forms.NumericUpDown nUD_count;
        private Treeholder mainholder;
        private System.Windows.Forms.Label lb_deep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cB_rand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_console;
        private System.Windows.Forms.Button bt_save;
    }
}

