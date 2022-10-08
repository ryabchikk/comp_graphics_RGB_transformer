
namespace lab4
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MoveRadioButton = new System.Windows.Forms.RadioButton();
            this.ScalingRadioButton = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DotRadioButton = new System.Windows.Forms.RadioButton();
            this.LineRadioButton = new System.Windows.Forms.RadioButton();
            this.PolygonRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.RotateRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(228, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(761, 533);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Точка пересечения:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Принадлежит полигону:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 516);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Положение точки:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 248);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(37, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 245);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(37, 22);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "x";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "y";
            // 
            // MoveRadioButton
            // 
            this.MoveRadioButton.AutoSize = true;
            this.MoveRadioButton.Location = new System.Drawing.Point(26, 182);
            this.MoveRadioButton.Name = "MoveRadioButton";
            this.MoveRadioButton.Size = new System.Drawing.Size(98, 21);
            this.MoveRadioButton.TabIndex = 8;
            this.MoveRadioButton.TabStop = true;
            this.MoveRadioButton.Text = "Смещение";
            this.MoveRadioButton.UseVisualStyleBackColor = true;
            this.MoveRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ScalingRadioButton
            // 
            this.ScalingRadioButton.AutoSize = true;
            this.ScalingRadioButton.Location = new System.Drawing.Point(26, 209);
            this.ScalingRadioButton.Name = "ScalingRadioButton";
            this.ScalingRadioButton.Size = new System.Drawing.Size(152, 21);
            this.ScalingRadioButton.TabIndex = 9;
            this.ScalingRadioButton.TabStop = true;
            this.ScalingRadioButton.Text = "Масштабирование";
            this.ScalingRadioButton.UseVisualStyleBackColor = true;
            this.ScalingRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 318);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(116, 21);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Вокруг точки";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Поворот";
            // 
            // DotRadioButton
            // 
            this.DotRadioButton.AutoSize = true;
            this.DotRadioButton.Location = new System.Drawing.Point(26, 30);
            this.DotRadioButton.Name = "DotRadioButton";
            this.DotRadioButton.Size = new System.Drawing.Size(69, 21);
            this.DotRadioButton.TabIndex = 12;
            this.DotRadioButton.TabStop = true;
            this.DotRadioButton.Text = "Точка";
            this.DotRadioButton.UseVisualStyleBackColor = true;
            // 
            // LineRadioButton
            // 
            this.LineRadioButton.AutoSize = true;
            this.LineRadioButton.Location = new System.Drawing.Point(26, 67);
            this.LineRadioButton.Name = "LineRadioButton";
            this.LineRadioButton.Size = new System.Drawing.Size(85, 21);
            this.LineRadioButton.TabIndex = 13;
            this.LineRadioButton.TabStop = true;
            this.LineRadioButton.Text = "Отрезок";
            this.LineRadioButton.UseVisualStyleBackColor = true;
            // 
            // PolygonRadioButton
            // 
            this.PolygonRadioButton.AutoSize = true;
            this.PolygonRadioButton.Location = new System.Drawing.Point(26, 107);
            this.PolygonRadioButton.Name = "PolygonRadioButton";
            this.PolygonRadioButton.Size = new System.Drawing.Size(84, 21);
            this.PolygonRadioButton.TabIndex = 14;
            this.PolygonRadioButton.TabStop = true;
            this.PolygonRadioButton.Text = "Полигон";
            this.PolygonRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "Очистить сцену";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(75, 281);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(37, 22);
            this.textBox3.TabIndex = 16;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 36);
            this.button2.TabIndex = 17;
            this.button2.Text = "Применить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RotateRadioButton
            // 
            this.RotateRadioButton.AutoSize = true;
            this.RotateRadioButton.Location = new System.Drawing.Point(26, 155);
            this.RotateRadioButton.Name = "RotateRadioButton";
            this.RotateRadioButton.Size = new System.Drawing.Size(85, 21);
            this.RotateRadioButton.TabIndex = 18;
            this.RotateRadioButton.TabStop = true;
            this.RotateRadioButton.Text = "Поворот";
            this.RotateRadioButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 571);
            this.Controls.Add(this.RotateRadioButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PolygonRadioButton);
            this.Controls.Add(this.LineRadioButton);
            this.Controls.Add(this.DotRadioButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ScalingRadioButton);
            this.Controls.Add(this.MoveRadioButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton MoveRadioButton;
        private System.Windows.Forms.RadioButton ScalingRadioButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton DotRadioButton;
        private System.Windows.Forms.RadioButton LineRadioButton;
        private System.Windows.Forms.RadioButton PolygonRadioButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton RotateRadioButton;
    }
}

