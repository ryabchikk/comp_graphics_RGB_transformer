namespace lab7
{
    partial class Form2
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
            this.PerspectiveBox = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown11 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown12 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown13 = new System.Windows.Forms.NumericUpDown();
            this.ApplyRotationCenter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ApplyScaleCenter = new System.Windows.Forms.Button();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ApplyReflection = new System.Windows.Forms.Button();
            this.ReflectionComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ApplyPrimitive = new System.Windows.Forms.Button();
            this.PrimitiveLabel = new System.Windows.Forms.Label();
            this.PrimitiveComboBox = new System.Windows.Forms.ComboBox();
            this.PerspectiveLabel = new System.Windows.Forms.Label();
            this.ApplyPerspective = new System.Windows.Forms.Button();
            this.PerspectiveComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PerspectiveBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // PerspectiveBox
            // 
            this.PerspectiveBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PerspectiveBox.Location = new System.Drawing.Point(329, 90);
            this.PerspectiveBox.Name = "PerspectiveBox";
            this.PerspectiveBox.Size = new System.Drawing.Size(688, 551);
            this.PerspectiveBox.TabIndex = 0;
            this.PerspectiveBox.TabStop = false;
            this.PerspectiveBox.Click += new System.EventHandler(this.PerspectiveBox_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1050, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 17);
            this.label9.TabIndex = 78;
            this.label9.Text = "Вращение по центру";
            // 
            // numericUpDown11
            // 
            this.numericUpDown11.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown11.Location = new System.Drawing.Point(1053, 314);
            this.numericUpDown11.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown11.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown11.Name = "numericUpDown11";
            this.numericUpDown11.Size = new System.Drawing.Size(54, 22);
            this.numericUpDown11.TabIndex = 77;
            // 
            // numericUpDown12
            // 
            this.numericUpDown12.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown12.Location = new System.Drawing.Point(1122, 314);
            this.numericUpDown12.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown12.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown12.Name = "numericUpDown12";
            this.numericUpDown12.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown12.TabIndex = 76;
            // 
            // numericUpDown13
            // 
            this.numericUpDown13.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown13.Location = new System.Drawing.Point(1190, 314);
            this.numericUpDown13.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown13.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown13.Name = "numericUpDown13";
            this.numericUpDown13.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown13.TabIndex = 75;
            // 
            // ApplyRotationCenter
            // 
            this.ApplyRotationCenter.Location = new System.Drawing.Point(1056, 355);
            this.ApplyRotationCenter.Name = "ApplyRotationCenter";
            this.ApplyRotationCenter.Size = new System.Drawing.Size(190, 34);
            this.ApplyRotationCenter.TabIndex = 74;
            this.ApplyRotationCenter.Text = "Применить";
            this.ApplyRotationCenter.UseVisualStyleBackColor = true;
            this.ApplyRotationCenter.Click += new System.EventHandler(this.ApplyRotationCenter_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(105, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 17);
            this.label8.TabIndex = 73;
            this.label8.Text = "Масштаб отн-но центра";
            // 
            // ApplyScaleCenter
            // 
            this.ApplyScaleCenter.Location = new System.Drawing.Point(108, 395);
            this.ApplyScaleCenter.Name = "ApplyScaleCenter";
            this.ApplyScaleCenter.Size = new System.Drawing.Size(190, 34);
            this.ApplyScaleCenter.TabIndex = 72;
            this.ApplyScaleCenter.Text = "Применить";
            this.ApplyScaleCenter.UseVisualStyleBackColor = true;
            this.ApplyScaleCenter.Click += new System.EventHandler(this.ApplyScaleCenter_Click);
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.DecimalPlaces = 1;
            this.numericUpDown10.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown10.Location = new System.Drawing.Point(108, 367);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown10.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(190, 22);
            this.numericUpDown10.TabIndex = 71;
            this.numericUpDown10.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1053, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 70;
            this.label7.Text = "Отражение";
            // 
            // ApplyReflection
            // 
            this.ApplyReflection.Location = new System.Drawing.Point(1056, 182);
            this.ApplyReflection.Name = "ApplyReflection";
            this.ApplyReflection.Size = new System.Drawing.Size(190, 34);
            this.ApplyReflection.TabIndex = 69;
            this.ApplyReflection.Text = "Применить";
            this.ApplyReflection.UseVisualStyleBackColor = true;
            this.ApplyReflection.Click += new System.EventHandler(this.ApplyReflection_Click);
            // 
            // ReflectionComboBox
            // 
            this.ReflectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReflectionComboBox.FormattingEnabled = true;
            this.ReflectionComboBox.Items.AddRange(new object[] {
            "Отражение по X",
            "Отражение по Y",
            "Отражение по Z"});
            this.ReflectionComboBox.Location = new System.Drawing.Point(1056, 142);
            this.ReflectionComboBox.Name = "ReflectionComboBox";
            this.ReflectionComboBox.Size = new System.Drawing.Size(186, 24);
            this.ReflectionComboBox.TabIndex = 68;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 572);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 67;
            this.label6.Text = "Масштаб";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 532);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 66;
            this.label5.Text = "Поворот";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.DecimalPlaces = 1;
            this.numericUpDown7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown7.Location = new System.Drawing.Point(111, 570);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown7.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(54, 22);
            this.numericUpDown7.TabIndex = 65;
            this.numericUpDown7.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.DecimalPlaces = 1;
            this.numericUpDown8.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown8.Location = new System.Drawing.Point(177, 570);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown8.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown8.TabIndex = 64;
            this.numericUpDown8.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.DecimalPlaces = 1;
            this.numericUpDown9.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown9.Location = new System.Drawing.Point(245, 570);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown9.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown9.TabIndex = 63;
            this.numericUpDown9.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown4.Location = new System.Drawing.Point(111, 530);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(54, 22);
            this.numericUpDown4.TabIndex = 62;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown5.Location = new System.Drawing.Point(177, 530);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown5.TabIndex = 61;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown6.Location = new System.Drawing.Point(245, 530);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown6.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 489);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 59;
            this.label4.Text = "Смещение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 58;
            this.label3.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 57;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 56;
            this.label1.Text = "X";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 2;
            this.numericUpDown3.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown3.Location = new System.Drawing.Point(247, 487);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(54, 22);
            this.numericUpDown3.TabIndex = 55;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown2.Location = new System.Drawing.Point(179, 487);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown2.TabIndex = 54;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(111, 487);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown1.TabIndex = 53;
            // 
            // ApplyPrimitive
            // 
            this.ApplyPrimitive.Location = new System.Drawing.Point(109, 123);
            this.ApplyPrimitive.Name = "ApplyPrimitive";
            this.ApplyPrimitive.Size = new System.Drawing.Size(192, 34);
            this.ApplyPrimitive.TabIndex = 52;
            this.ApplyPrimitive.Text = "Применить";
            this.ApplyPrimitive.UseVisualStyleBackColor = true;
            this.ApplyPrimitive.Click += new System.EventHandler(this.ApplyPrimitive_Click);
            // 
            // PrimitiveLabel
            // 
            this.PrimitiveLabel.AutoSize = true;
            this.PrimitiveLabel.Location = new System.Drawing.Point(105, 132);
            this.PrimitiveLabel.Name = "PrimitiveLabel";
            this.PrimitiveLabel.Size = new System.Drawing.Size(100, 17);
            this.PrimitiveLabel.TabIndex = 51;
            this.PrimitiveLabel.Text = "Многогранник";
            // 
            // PrimitiveComboBox
            // 
            this.PrimitiveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrimitiveComboBox.FormattingEnabled = true;
            this.PrimitiveComboBox.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр",
            "Икосаэдр"});
            this.PrimitiveComboBox.Location = new System.Drawing.Point(109, 90);
            this.PrimitiveComboBox.Name = "PrimitiveComboBox";
            this.PrimitiveComboBox.Size = new System.Drawing.Size(190, 24);
            this.PrimitiveComboBox.TabIndex = 50;
            // 
            // PerspectiveLabel
            // 
            this.PerspectiveLabel.AutoSize = true;
            this.PerspectiveLabel.Location = new System.Drawing.Point(111, 206);
            this.PerspectiveLabel.Name = "PerspectiveLabel";
            this.PerspectiveLabel.Size = new System.Drawing.Size(143, 17);
            this.PerspectiveLabel.TabIndex = 93;
            this.PerspectiveLabel.Text = "Выберите проекцию";
            // 
            // ApplyPerspective
            // 
            this.ApplyPerspective.Location = new System.Drawing.Point(111, 261);
            this.ApplyPerspective.Name = "ApplyPerspective";
            this.ApplyPerspective.Size = new System.Drawing.Size(190, 34);
            this.ApplyPerspective.TabIndex = 92;
            this.ApplyPerspective.Text = "Применить";
            this.ApplyPerspective.UseVisualStyleBackColor = true;
            this.ApplyPerspective.Click += new System.EventHandler(this.ApplyPerspective_Click);
            // 
            // PerspectiveComboBox
            // 
            this.PerspectiveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PerspectiveComboBox.FormattingEnabled = true;
            this.PerspectiveComboBox.Items.AddRange(new object[] {
            "Перспективная",
            "Изометрическая"});
            this.PerspectiveComboBox.Location = new System.Drawing.Point(111, 228);
            this.PerspectiveComboBox.Name = "PerspectiveComboBox";
            this.PerspectiveComboBox.Size = new System.Drawing.Size(190, 24);
            this.PerspectiveComboBox.TabIndex = 91;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 612);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 34);
            this.button1.TabIndex = 94;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ApplyAffin_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(106, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 17);
            this.label14.TabIndex = 95;
            this.label14.Text = "Выберите многогранник";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1056, 475);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(190, 34);
            this.SaveButton.TabIndex = 96;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1056, 532);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 34);
            this.button3.TabIndex = 97;
            this.button3.Text = "Загрузить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 734);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PerspectiveLabel);
            this.Controls.Add(this.ApplyPerspective);
            this.Controls.Add(this.PerspectiveComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDown11);
            this.Controls.Add(this.numericUpDown12);
            this.Controls.Add(this.numericUpDown13);
            this.Controls.Add(this.ApplyRotationCenter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ApplyScaleCenter);
            this.Controls.Add(this.numericUpDown10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ApplyReflection);
            this.Controls.Add(this.ReflectionComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown7);
            this.Controls.Add(this.numericUpDown8);
            this.Controls.Add(this.numericUpDown9);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.numericUpDown6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.ApplyPrimitive);
            this.Controls.Add(this.PrimitiveLabel);
            this.Controls.Add(this.PrimitiveComboBox);
            this.Controls.Add(this.PerspectiveBox);
            this.Name = "Form2";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PerspectiveBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PerspectiveBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown11;
        private System.Windows.Forms.NumericUpDown numericUpDown12;
        private System.Windows.Forms.NumericUpDown numericUpDown13;
        private System.Windows.Forms.Button ApplyRotationCenter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ApplyScaleCenter;
        private System.Windows.Forms.NumericUpDown numericUpDown10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ApplyReflection;
        private System.Windows.Forms.ComboBox ReflectionComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.NumericUpDown numericUpDown8;
        private System.Windows.Forms.NumericUpDown numericUpDown9;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button ApplyPrimitive;
        private System.Windows.Forms.Label PrimitiveLabel;
        private System.Windows.Forms.ComboBox PrimitiveComboBox;
        private System.Windows.Forms.Label PerspectiveLabel;
        private System.Windows.Forms.Button ApplyPerspective;
        private System.Windows.Forms.ComboBox PerspectiveComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button button3;
    }
}

