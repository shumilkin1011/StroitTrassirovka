namespace StroitTrass
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_pol = new System.Windows.Forms.Label();
            this.lb_st = new System.Windows.Forms.Label();
            this.lb_fin = new System.Windows.Forms.Label();
            this.lb_d = new System.Windows.Forms.Label();
            this.lb_cl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1100, 650);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // lb_pol
            // 
            this.lb_pol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_pol.AutoSize = true;
            this.lb_pol.BackColor = System.Drawing.Color.Transparent;
            this.lb_pol.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_pol.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_pol.Location = new System.Drawing.Point(835, 571);
            this.lb_pol.Name = "lb_pol";
            this.lb_pol.Size = new System.Drawing.Size(257, 12);
            this.lb_pol.TabIndex = 1;
            this.lb_pol.Text = "Режим добавления нового полигона [N]";
            // 
            // lb_st
            // 
            this.lb_st.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_st.AutoSize = true;
            this.lb_st.BackColor = System.Drawing.Color.Transparent;
            this.lb_st.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_st.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_st.Location = new System.Drawing.Point(821, 586);
            this.lb_st.Name = "lb_st";
            this.lb_st.Size = new System.Drawing.Size(271, 12);
            this.lb_st.TabIndex = 2;
            this.lb_st.Text = "Режим добавления точки начала пути [S]";
            // 
            // lb_fin
            // 
            this.lb_fin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_fin.AutoSize = true;
            this.lb_fin.BackColor = System.Drawing.Color.Transparent;
            this.lb_fin.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_fin.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_fin.Location = new System.Drawing.Point(829, 601);
            this.lb_fin.Name = "lb_fin";
            this.lb_fin.Size = new System.Drawing.Size(264, 12);
            this.lb_fin.TabIndex = 3;
            this.lb_fin.Text = "Режим добавления точки конца пути [F]";
            // 
            // lb_d
            // 
            this.lb_d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_d.AutoSize = true;
            this.lb_d.BackColor = System.Drawing.Color.Transparent;
            this.lb_d.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_d.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_d.Location = new System.Drawing.Point(871, 616);
            this.lb_d.Name = "lb_d";
            this.lb_d.Size = new System.Drawing.Size(222, 12);
            this.lb_d.TabIndex = 4;
            this.lb_d.Text = "Построение кратчайшего пути [D]";
            // 
            // lb_cl
            // 
            this.lb_cl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_cl.AutoSize = true;
            this.lb_cl.BackColor = System.Drawing.Color.Transparent;
            this.lb_cl.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_cl.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_cl.Location = new System.Drawing.Point(962, 631);
            this.lb_cl.Name = "lb_cl";
            this.lb_cl.Size = new System.Drawing.Size(131, 12);
            this.lb_cl.TabIndex = 5;
            this.lb_cl.Text = "Очистка экрана [C]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.lb_cl);
            this.Controls.Add(this.lb_d);
            this.Controls.Add(this.lb_fin);
            this.Controls.Add(this.lb_st);
            this.Controls.Add(this.lb_pol);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Строительная трассировка";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_pol;
        private System.Windows.Forms.Label lb_st;
        private System.Windows.Forms.Label lb_fin;
        private System.Windows.Forms.Label lb_d;
        private System.Windows.Forms.Label lb_cl;
    }
}

