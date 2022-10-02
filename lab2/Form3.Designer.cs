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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label9 = new System.Windows.Forms.Label();
            this.PB_HDTV = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PB_DIFF = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PB_YUV = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.PB_HDTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_DIFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_YUV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.OldLace;
            this.label9.Location = new System.Drawing.Point(7, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 23);
            this.label9.TabIndex = 26;
            this.label9.Text = "HDTV";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PB_HDTV
            // 
            this.PB_HDTV.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PB_HDTV.Location = new System.Drawing.Point(8, 15);
            this.PB_HDTV.Margin = new System.Windows.Forms.Padding(4);
            this.PB_HDTV.Name = "PB_HDTV";
            this.PB_HDTV.Size = new System.Drawing.Size(320, 320);
            this.PB_HDTV.TabIndex = 25;
            this.PB_HDTV.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.OldLace;
            this.label10.Location = new System.Drawing.Point(663, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 23);
            this.label10.TabIndex = 28;
            this.label10.Text = "Diff";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PB_DIFF
            // 
            this.PB_DIFF.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PB_DIFF.Location = new System.Drawing.Point(664, 15);
            this.PB_DIFF.Margin = new System.Windows.Forms.Padding(4);
            this.PB_DIFF.Name = "PB_DIFF";
            this.PB_DIFF.Size = new System.Drawing.Size(320, 320);
            this.PB_DIFF.TabIndex = 27;
            this.PB_DIFF.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.OldLace;
            this.label8.Location = new System.Drawing.Point(335, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 23);
            this.label8.TabIndex = 30;
            this.label8.Text = "PAL";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PB_YUV
            // 
            this.PB_YUV.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PB_YUV.Location = new System.Drawing.Point(336, 15);
            this.PB_YUV.Margin = new System.Windows.Forms.Padding(4);
            this.PB_YUV.Name = "PB_YUV";
            this.PB_YUV.Size = new System.Drawing.Size(320, 320);
            this.PB_YUV.TabIndex = 29;
            this.PB_YUV.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(431, 677);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 36);
            this.button1.TabIndex = 31;
            this.button1.Text = "Draw histograms";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart2
            // 
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(348, 355);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(300, 300);
            this.chart2.TabIndex = 33;
            this.chart2.Text = "chart2";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 355);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 34;
            this.chart1.Text = "Difference";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(992, 727);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PB_YUV);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PB_DIFF);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PB_HDTV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.PB_HDTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_DIFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_YUV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
        public System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}