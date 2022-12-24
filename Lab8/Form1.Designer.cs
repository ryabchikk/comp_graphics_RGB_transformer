namespace Lab8
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.textTranslateX = new System.Windows.Forms.TextBox();
            this.textTranslateY = new System.Windows.Forms.TextBox();
            this.textTranslateZ = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ScaleButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textScaleY = new System.Windows.Forms.TextBox();
            this.textScaleX = new System.Windows.Forms.TextBox();
            this.textScaleZ = new System.Windows.Forms.TextBox();
            this.TranslateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TextureObjectButton = new System.Windows.Forms.Button();
            this.LoadTextureButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Zbuffer = new System.Windows.Forms.Button();
            this.LightButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(635, 550);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(222, 147);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(6, 172);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(85, 23);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(143, 173);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(85, 22);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // textTranslateX
            // 
            this.textTranslateX.Location = new System.Drawing.Point(6, 32);
            this.textTranslateX.Name = "textTranslateX";
            this.textTranslateX.Size = new System.Drawing.Size(37, 20);
            this.textTranslateX.TabIndex = 4;
            this.textTranslateX.Text = "0";
            // 
            // textTranslateY
            // 
            this.textTranslateY.Location = new System.Drawing.Point(49, 32);
            this.textTranslateY.Name = "textTranslateY";
            this.textTranslateY.Size = new System.Drawing.Size(37, 20);
            this.textTranslateY.TabIndex = 5;
            this.textTranslateY.Text = "0";
            // 
            // textTranslateZ
            // 
            this.textTranslateZ.Location = new System.Drawing.Point(92, 32);
            this.textTranslateZ.Name = "textTranslateZ";
            this.textTranslateZ.Size = new System.Drawing.Size(37, 20);
            this.textTranslateZ.TabIndex = 6;
            this.textTranslateZ.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddButton);
            this.groupBox1.Controls.Add(this.DeleteButton);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(653, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 202);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Объекты";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ScaleButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textScaleY);
            this.groupBox2.Controls.Add(this.textScaleX);
            this.groupBox2.Controls.Add(this.textScaleZ);
            this.groupBox2.Controls.Add(this.TranslateButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textTranslateY);
            this.groupBox2.Controls.Add(this.textTranslateX);
            this.groupBox2.Controls.Add(this.textTranslateZ);
            this.groupBox2.Location = new System.Drawing.Point(653, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 99);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Афинные преобразования";
            // 
            // ScaleButton
            // 
            this.ScaleButton.Location = new System.Drawing.Point(135, 69);
            this.ScaleButton.Name = "ScaleButton";
            this.ScaleButton.Size = new System.Drawing.Size(85, 22);
            this.ScaleButton.TabIndex = 16;
            this.ScaleButton.Text = "Масштаб";
            this.ScaleButton.UseVisualStyleBackColor = true;
            this.ScaleButton.Click += new System.EventHandler(this.ScaleButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "X";
            // 
            // textScaleY
            // 
            this.textScaleY.Location = new System.Drawing.Point(49, 71);
            this.textScaleY.Name = "textScaleY";
            this.textScaleY.Size = new System.Drawing.Size(37, 20);
            this.textScaleY.TabIndex = 11;
            this.textScaleY.Text = "1";
            // 
            // textScaleX
            // 
            this.textScaleX.Location = new System.Drawing.Point(6, 71);
            this.textScaleX.Name = "textScaleX";
            this.textScaleX.Size = new System.Drawing.Size(37, 20);
            this.textScaleX.TabIndex = 10;
            this.textScaleX.Text = "1";
            // 
            // textScaleZ
            // 
            this.textScaleZ.Location = new System.Drawing.Point(92, 71);
            this.textScaleZ.Name = "textScaleZ";
            this.textScaleZ.Size = new System.Drawing.Size(37, 20);
            this.textScaleZ.TabIndex = 12;
            this.textScaleZ.Text = "1";
            // 
            // TranslateButton
            // 
            this.TranslateButton.Location = new System.Drawing.Point(135, 32);
            this.TranslateButton.Name = "TranslateButton";
            this.TranslateButton.Size = new System.Drawing.Size(85, 22);
            this.TranslateButton.TabIndex = 4;
            this.TranslateButton.Text = "Переместить";
            this.TranslateButton.UseVisualStyleBackColor = true;
            this.TranslateButton.Click += new System.EventHandler(this.TranslateButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "X";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TextureObjectButton);
            this.groupBox3.Controls.Add(this.LoadTextureButton);
            this.groupBox3.Location = new System.Drawing.Point(653, 411);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 76);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Текстурирование";
            // 
            // TextureObjectButton
            // 
            this.TextureObjectButton.Location = new System.Drawing.Point(29, 47);
            this.TextureObjectButton.Name = "TextureObjectButton";
            this.TextureObjectButton.Size = new System.Drawing.Size(171, 22);
            this.TextureObjectButton.TabIndex = 18;
            this.TextureObjectButton.Text = "Текстурировать выделенное";
            this.TextureObjectButton.UseVisualStyleBackColor = true;
            this.TextureObjectButton.Click += new System.EventHandler(this.TextureObjectButton_Click);
            // 
            // LoadTextureButton
            // 
            this.LoadTextureButton.Location = new System.Drawing.Point(29, 19);
            this.LoadTextureButton.Name = "LoadTextureButton";
            this.LoadTextureButton.Size = new System.Drawing.Size(171, 22);
            this.LoadTextureButton.TabIndex = 17;
            this.LoadTextureButton.Text = "Загрузить текстуру";
            this.LoadTextureButton.UseVisualStyleBackColor = true;
            this.LoadTextureButton.Click += new System.EventHandler(this.LoadTextureButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Zbuffer);
            this.groupBox4.Controls.Add(this.LightButton);
            this.groupBox4.Location = new System.Drawing.Point(653, 325);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(234, 80);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Работа со сценой";
            // 
            // Zbuff
            // 
            this.Zbuffer.Location = new System.Drawing.Point(29, 47);
            this.Zbuffer.Name = "Zbuffer";
            this.Zbuffer.Size = new System.Drawing.Size(171, 22);
            this.Zbuffer.TabIndex = 19;
            this.Zbuffer.Text = "Создать Z-буфер";
            this.Zbuffer.UseVisualStyleBackColor = true;
            this.Zbuffer.Click += new System.EventHandler(this.Zbuffer_Click);
            // 
            // LightButton
            // 
            this.LightButton.Location = new System.Drawing.Point(29, 19);
            this.LightButton.Name = "LightButton";
            this.LightButton.Size = new System.Drawing.Size(171, 22);
            this.LightButton.TabIndex = 17;
            this.LightButton.Text = "Создать освещение";
            this.LightButton.UseVisualStyleBackColor = true;
            this.LightButton.Click += new System.EventHandler(this.LightButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(900, 574);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Visualizer";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox textTranslateX;
        private System.Windows.Forms.TextBox textTranslateY;
        private System.Windows.Forms.TextBox textTranslateZ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ScaleButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textScaleY;
        private System.Windows.Forms.TextBox textScaleX;
        private System.Windows.Forms.TextBox textScaleZ;
        private System.Windows.Forms.Button TranslateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button TextureObjectButton;
        private System.Windows.Forms.Button LoadTextureButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button Zbuffer;
        private System.Windows.Forms.Button LightButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

