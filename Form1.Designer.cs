
namespace Lab2
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
            this.PB_HIST_1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.PB_SOURCE = new System.Windows.Forms.PictureBox();
            this.PB_DIFF = new System.Windows.Forms.PictureBox();
            this.PB_YUV = new System.Windows.Forms.PictureBox();
            this.PB_HDTV = new System.Windows.Forms.PictureBox();
            this.PB_HIST_2 = new System.Windows.Forms.PictureBox();
            this.PB_HIST_3 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_HIST_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_SOURCE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_DIFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_YUV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_HDTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_HIST_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_HIST_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_HIST_1
            // 
            this.PB_HIST_1.Location = new System.Drawing.Point(279, 427);
            this.PB_HIST_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PB_HIST_1.Name = "PB_HIST_1";
            this.PB_HIST_1.Size = new System.Drawing.Size(368, 427);
            this.PB_HIST_1.TabIndex = 0;
            this.PB_HIST_1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 81);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Upload photo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 134);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "PAL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 197);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 3;
            this.button3.Text = "HDTV";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PB_SOURCE
            // 
            this.PB_SOURCE.Location = new System.Drawing.Point(279, 31);
            this.PB_SOURCE.Margin = new System.Windows.Forms.Padding(4);
            this.PB_SOURCE.Name = "PB_SOURCE";
            this.PB_SOURCE.Size = new System.Drawing.Size(285, 390);
            this.PB_SOURCE.TabIndex = 4;
            this.PB_SOURCE.TabStop = false;
            // 
            // PB_DIFF
            // 
            this.PB_DIFF.Location = new System.Drawing.Point(1228, 31);
            this.PB_DIFF.Margin = new System.Windows.Forms.Padding(4);
            this.PB_DIFF.Name = "PB_DIFF";
            this.PB_DIFF.Size = new System.Drawing.Size(285, 390);
            this.PB_DIFF.TabIndex = 5;
            this.PB_DIFF.TabStop = false;
            // 
            // PB_YUV
            // 
            this.PB_YUV.Location = new System.Drawing.Point(616, 31);
            this.PB_YUV.Margin = new System.Windows.Forms.Padding(4);
            this.PB_YUV.Name = "PB_YUV";
            this.PB_YUV.Size = new System.Drawing.Size(285, 390);
            this.PB_YUV.TabIndex = 6;
            this.PB_YUV.TabStop = false;
            // 
            // PB_HDTV
            // 
            this.PB_HDTV.Location = new System.Drawing.Point(923, 31);
            this.PB_HDTV.Margin = new System.Windows.Forms.Padding(4);
            this.PB_HDTV.Name = "PB_HDTV";
            this.PB_HDTV.Size = new System.Drawing.Size(285, 390);
            this.PB_HDTV.TabIndex = 7;
            this.PB_HDTV.TabStop = false;
            // 
            // PB_HIST_2
            // 
            this.PB_HIST_2.Location = new System.Drawing.Point(740, 427);
            this.PB_HIST_2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PB_HIST_2.Name = "PB_HIST_2";
            this.PB_HIST_2.Size = new System.Drawing.Size(368, 427);
            this.PB_HIST_2.TabIndex = 8;
            this.PB_HIST_2.TabStop = false;
            // 
            // PB_HIST_3
            // 
            this.PB_HIST_3.Location = new System.Drawing.Point(1192, 427);
            this.PB_HIST_3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PB_HIST_3.Name = "PB_HIST_3";
            this.PB_HIST_3.Size = new System.Drawing.Size(368, 427);
            this.PB_HIST_3.TabIndex = 9;
            this.PB_HIST_3.TabStop = false;
            this.PB_HIST_3.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 304);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 10;
            this.button4.Text = "Histogram";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 253);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 28);
            this.button5.TabIndex = 11;
            this.button5.Text = "Diff";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(16, 362);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 28);
            this.button6.TabIndex = 12;
            this.button6.Text = "HSV";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(16, 445);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(145, 56);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(16, 544);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(145, 56);
            this.trackBar2.TabIndex = 14;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(16, 640);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(145, 56);
            this.trackBar3.TabIndex = 15;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "H";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "S";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 593);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "V";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1592, 891);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.PB_HIST_3);
            this.Controls.Add(this.PB_HIST_2);
            this.Controls.Add(this.PB_HDTV);
            this.Controls.Add(this.PB_YUV);
            this.Controls.Add(this.PB_DIFF);
            this.Controls.Add(this.PB_SOURCE);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PB_HIST_1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_HIST_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_SOURCE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_DIFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_YUV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_HDTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_HIST_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_HIST_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_HIST_1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox PB_SOURCE;
        private System.Windows.Forms.PictureBox PB_DIFF;
        private System.Windows.Forms.PictureBox PB_YUV;
        private System.Windows.Forms.PictureBox PB_HDTV;
        private System.Windows.Forms.PictureBox PB_HIST_2;
        private System.Windows.Forms.PictureBox PB_HIST_3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

