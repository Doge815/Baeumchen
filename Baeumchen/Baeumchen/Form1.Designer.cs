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
            this.mainholder = new Baeumchen.Treeholder();
            this.lb_deep = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_count)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(334, 107);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 23);
            this.bt_Add.TabIndex = 0;
            this.bt_Add.Text = "Add";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // nUD_min
            // 
            this.nUD_min.Location = new System.Drawing.Point(208, 107);
            this.nUD_min.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nUD_min.Name = "nUD_min";
            this.nUD_min.Size = new System.Drawing.Size(120, 20);
            this.nUD_min.TabIndex = 1;
            this.nUD_min.ValueChanged += new System.EventHandler(this.nUD_Value_Changed);
            // 
            // nUD_max
            // 
            this.nUD_max.Location = new System.Drawing.Point(415, 107);
            this.nUD_max.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_max.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_max.Name = "nUD_max";
            this.nUD_max.Size = new System.Drawing.Size(120, 20);
            this.nUD_max.TabIndex = 2;
            this.nUD_max.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_max.ValueChanged += new System.EventHandler(this.nUD_Value_Changed);
            // 
            // rTB_out
            // 
            this.rTB_out.Location = new System.Drawing.Point(12, 133);
            this.rTB_out.Name = "rTB_out";
            this.rTB_out.ReadOnly = true;
            this.rTB_out.Size = new System.Drawing.Size(327, 305);
            this.rTB_out.TabIndex = 3;
            this.rTB_out.Text = "";
            // 
            // nUD_count
            // 
            this.nUD_count.Location = new System.Drawing.Point(208, 81);
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
            // 
            // mainholder
            // 
            this.mainholder.AutoScroll = true;
            this.mainholder.Location = new System.Drawing.Point(345, 136);
            this.mainholder.Name = "mainholder";
            this.mainholder.Size = new System.Drawing.Size(443, 302);
            this.mainholder.TabIndex = 5;
            // 
            // lb_deep
            // 
            this.lb_deep.AutoSize = true;
            this.lb_deep.Location = new System.Drawing.Point(342, 88);
            this.lb_deep.Name = "lb_deep";
            this.lb_deep.Size = new System.Drawing.Size(13, 13);
            this.lb_deep.TabIndex = 6;
            this.lb_deep.Text = "1";
            // 
            // Baumhaus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_deep);
            this.Controls.Add(this.mainholder);
            this.Controls.Add(this.nUD_count);
            this.Controls.Add(this.rTB_out);
            this.Controls.Add(this.nUD_max);
            this.Controls.Add(this.nUD_min);
            this.Controls.Add(this.bt_Add);
            this.Name = "Baumhaus";
            this.Text = "Baumhaushauer";
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
    }
}

