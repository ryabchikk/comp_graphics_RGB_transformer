namespace Lab2
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.PB_HDTV = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PB_DIFF = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PB_YUV = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_HDTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_DIFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_YUV)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.OldLace;
            this.label9.Location = new System.Drawing.Point(5, 12);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 19);
            this.label9.TabIndex = 26;
            this.label9.Text = "HDTV";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PB_HDTV
            // 
            this.PB_HDTV.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PB_HDTV.Location = new System.Drawing.Point(6, 12);
            this.PB_HDTV.Name = "PB_HDTV";
            this.PB_HDTV.Size = new System.Drawing.Size(240, 260);
            this.PB_HDTV.TabIndex = 25;
            this.PB_HDTV.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.OldLace;
            this.label10.Location = new System.Drawing.Point(497, 12);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 19);
            this.label10.TabIndex = 28;
            this.label10.Text = "Diff";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PB_DIFF
            // 
            this.PB_DIFF.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PB_DIFF.Location = new System.Drawing.Point(498, 12);
            this.PB_DIFF.Name = "PB_DIFF";
            this.PB_DIFF.Size = new System.Drawing.Size(240, 260);
            this.PB_DIFF.TabIndex = 27;
            this.PB_DIFF.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.OldLace;
            this.label8.Location = new System.Drawing.Point(251, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 19);
            this.label8.TabIndex = 30;
            this.label8.Text = "PAL";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PB_YUV
            // 
            this.PB_YUV.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PB_YUV.Location = new System.Drawing.Point(252, 12);
            this.PB_YUV.Name = "PB_YUV";
            this.PB_YUV.Size = new System.Drawing.Size(240, 260);
            this.PB_YUV.TabIndex = 29;
            this.PB_YUV.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 550);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 29);
            this.button1.TabIndex = 31;
            this.button1.Text = "Draw histograms";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(744, 591);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PB_YUV);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PB_DIFF);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PB_HDTV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.PB_HDTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_DIFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_YUV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox PB_HDTV;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox PB_DIFF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox PB_YUV;
        private System.Windows.Forms.Button button1;
    }
}