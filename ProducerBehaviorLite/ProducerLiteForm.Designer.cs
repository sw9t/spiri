namespace ProducerLite
{
    partial class ProducerForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Степень эластичности функции", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Функция издержек C(y)", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Предельные производительности ресурсов", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Нормы замещения ресурсов", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("Оптимальный выбор производителя по критерию максимальной прибыли", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("Реакции производителя при изменении цен", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Коэффициенты эластичности по ценам", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProducerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.answersList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAppTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.roundNUD = new System.Windows.Forms.NumericUpDown();
            this.clearBtn = new System.Windows.Forms.Button();
            this.solveBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.q1Tb = new System.Windows.Forms.TextBox();
            this.pTb = new System.Windows.Forms.TextBox();
            this.x2Tb = new System.Windows.Forms.TextBox();
            this.x1Tb = new System.Windows.Forms.TextBox();
            this.A_Tb = new System.Windows.Forms.TextBox();
            this.alphaTb = new System.Windows.Forms.TextBox();
            this.betaTb = new System.Windows.Forms.TextBox();
            this.q2Tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.U_Tb = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Ans1Label = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundNUD)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Количество знаков после запятой:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.Ans1Label);
            this.groupBox3.Controls.Add(this.answersList);
            this.groupBox3.Location = new System.Drawing.Point(280, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(589, 545);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Решение задачи";
            // 
            // answersList
            // 
            this.answersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.answersList.FullRowSelect = true;
            this.answersList.GridLines = true;
            listViewGroup8.Header = "Степень эластичности функции";
            listViewGroup8.Name = "gr1";
            listViewGroup9.Header = "Функция издержек C(y)";
            listViewGroup9.Name = "gr2";
            listViewGroup10.Header = "Предельные производительности ресурсов";
            listViewGroup10.Name = "gr3";
            listViewGroup11.Header = "Нормы замещения ресурсов";
            listViewGroup11.Name = "gr5";
            listViewGroup12.Header = "Оптимальный выбор производителя по критерию максимальной прибыли";
            listViewGroup12.Name = "gr6";
            listViewGroup13.Header = "Реакции производителя при изменении цен";
            listViewGroup13.Name = "gr8";
            listViewGroup14.Header = "Коэффициенты эластичности по ценам";
            listViewGroup14.Name = "elast";
            this.answersList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup8,
            listViewGroup9,
            listViewGroup10,
            listViewGroup11,
            listViewGroup12,
            listViewGroup13,
            listViewGroup14});
            this.answersList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.answersList.Location = new System.Drawing.Point(6, 146);
            this.answersList.Name = "answersList";
            this.answersList.Size = new System.Drawing.Size(577, 396);
            this.answersList.TabIndex = 0;
            this.answersList.UseCompatibleStateImageBehavior = false;
            this.answersList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Величина";
            this.columnHeader1.Width = 282;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Значение";
            this.columnHeader2.Width = 267;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.HelpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAppTSMI});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(48, 20);
            this.FileMenu.Text = "Файл";
            // 
            // closeAppTSMI
            // 
            this.closeAppTSMI.Name = "closeAppTSMI";
            this.closeAppTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeAppTSMI.Size = new System.Drawing.Size(162, 22);
            this.closeAppTSMI.Text = "Закрыть";
            this.closeAppTSMI.Click += new System.EventHandler(this.CloseTSMI_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpTSMI,
            this.aboutTSMI});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(65, 20);
            this.HelpMenu.Text = "Справка";
            // 
            // HelpTSMI
            // 
            this.HelpTSMI.Name = "HelpTSMI";
            this.HelpTSMI.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.HelpTSMI.Size = new System.Drawing.Size(175, 22);
            this.HelpTSMI.Text = "Вызов справки";
            this.HelpTSMI.Click += new System.EventHandler(this.HelpTSMI_Click);
            // 
            // aboutTSMI
            // 
            this.aboutTSMI.Name = "aboutTSMI";
            this.aboutTSMI.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.aboutTSMI.Size = new System.Drawing.Size(175, 22);
            this.aboutTSMI.Text = "О программе";
            this.aboutTSMI.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // roundNUD
            // 
            this.roundNUD.Location = new System.Drawing.Point(203, 101);
            this.roundNUD.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.roundNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roundNUD.Name = "roundNUD";
            this.roundNUD.Size = new System.Drawing.Size(46, 20);
            this.roundNUD.TabIndex = 8;
            this.roundNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.roundNUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // clearBtn
            // 
            this.clearBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.clearBtn.Location = new System.Drawing.Point(156, 127);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(92, 39);
            this.clearBtn.TabIndex = 9;
            this.clearBtn.Text = "Очистить данные";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // solveBtn
            // 
            this.solveBtn.Location = new System.Drawing.Point(4, 127);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(146, 39);
            this.solveBtn.TabIndex = 0;
            this.solveBtn.Text = "Показать решение";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(98, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "β";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "q1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "α";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "x1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(98, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "x2";
            // 
            // q1Tb
            // 
            this.q1Tb.Location = new System.Drawing.Point(116, 43);
            this.q1Tb.MaxLength = 5;
            this.q1Tb.Name = "q1Tb";
            this.q1Tb.Size = new System.Drawing.Size(46, 20);
            this.q1Tb.TabIndex = 4;
            this.q1Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.q1Tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyPress);
            // 
            // pTb
            // 
            this.pTb.Location = new System.Drawing.Point(26, 43);
            this.pTb.MaxLength = 5;
            this.pTb.Name = "pTb";
            this.pTb.Size = new System.Drawing.Size(46, 20);
            this.pTb.TabIndex = 3;
            this.pTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyPress);
            // 
            // x2Tb
            // 
            this.x2Tb.Location = new System.Drawing.Point(116, 67);
            this.x2Tb.MaxLength = 5;
            this.x2Tb.Name = "x2Tb";
            this.x2Tb.Size = new System.Drawing.Size(46, 20);
            this.x2Tb.TabIndex = 7;
            this.x2Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.x2Tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyPress);
            // 
            // x1Tb
            // 
            this.x1Tb.Location = new System.Drawing.Point(26, 67);
            this.x1Tb.MaxLength = 5;
            this.x1Tb.Name = "x1Tb";
            this.x1Tb.Size = new System.Drawing.Size(46, 20);
            this.x1Tb.TabIndex = 6;
            this.x1Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.x1Tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyPress);
            // 
            // A_Tb
            // 
            this.A_Tb.Location = new System.Drawing.Point(202, 19);
            this.A_Tb.MaxLength = 5;
            this.A_Tb.Name = "A_Tb";
            this.A_Tb.Size = new System.Drawing.Size(46, 20);
            this.A_Tb.TabIndex = 2;
            this.A_Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.A_Tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyPress);
            // 
            // alphaTb
            // 
            this.alphaTb.Location = new System.Drawing.Point(26, 19);
            this.alphaTb.MaxLength = 5;
            this.alphaTb.Name = "alphaTb";
            this.alphaTb.Size = new System.Drawing.Size(46, 20);
            this.alphaTb.TabIndex = 1;
            this.alphaTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.alphaTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyPress);
            // 
            // betaTb
            // 
            this.betaTb.Location = new System.Drawing.Point(116, 19);
            this.betaTb.MaxLength = 5;
            this.betaTb.Name = "betaTb";
            this.betaTb.Size = new System.Drawing.Size(46, 20);
            this.betaTb.TabIndex = 1;
            this.betaTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.betaTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyPress);
            // 
            // q2Tb
            // 
            this.q2Tb.Location = new System.Drawing.Point(202, 43);
            this.q2Tb.MaxLength = 5;
            this.q2Tb.Name = "q2Tb";
            this.q2Tb.Size = new System.Drawing.Size(46, 20);
            this.q2Tb.TabIndex = 5;
            this.q2Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.q2Tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "p";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.U_Tb);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 340);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Постановка задачи";
            // 
            // U_Tb
            // 
            this.U_Tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.U_Tb.BackColor = System.Drawing.Color.White;
            this.U_Tb.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U_Tb.Location = new System.Drawing.Point(6, 270);
            this.U_Tb.Multiline = true;
            this.U_Tb.Name = "U_Tb";
            this.U_Tb.ReadOnly = true;
            this.U_Tb.Size = new System.Drawing.Size(248, 64);
            this.U_Tb.TabIndex = 3;
            this.U_Tb.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(248, 247);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.q1Tb);
            this.groupBox1.Controls.Add(this.roundNUD);
            this.groupBox1.Controls.Add(this.pTb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.clearBtn);
            this.groupBox1.Controls.Add(this.solveBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.x2Tb);
            this.groupBox1.Controls.Add(this.x1Tb);
            this.groupBox1.Controls.Add(this.A_Tb);
            this.groupBox1.Controls.Add(this.alphaTb);
            this.groupBox1.Controls.Add(this.betaTb);
            this.groupBox1.Controls.Add(this.q2Tb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 176);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ввод исходных данных";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "q2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "A";
            // 
            // Ans1Label
            // 
            this.Ans1Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ans1Label.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ans1Label.Location = new System.Drawing.Point(6, 19);
            this.Ans1Label.Name = "Ans1Label";
            this.Ans1Label.Size = new System.Drawing.Size(577, 124);
            this.Ans1Label.TabIndex = 1;
            // 
            // ProducerForm
            // 
            this.AcceptButton = this.solveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProducerBehaviorLite.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.clearBtn;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ProducerForm";
            this.Text = "Оптимальное поведение производителя (Итоговые вычисления)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundNUD)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem closeAppTSMI;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem HelpTSMI;
        private System.Windows.Forms.ToolStripMenuItem aboutTSMI;
        private System.Windows.Forms.NumericUpDown roundNUD;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button solveBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox q1Tb;
        private System.Windows.Forms.TextBox pTb;
        private System.Windows.Forms.TextBox x2Tb;
        private System.Windows.Forms.TextBox x1Tb;
        private System.Windows.Forms.TextBox A_Tb;
        private System.Windows.Forms.TextBox alphaTb;
        private System.Windows.Forms.TextBox betaTb;
        private System.Windows.Forms.TextBox q2Tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox U_Tb;
        private System.Windows.Forms.ListView answersList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label Ans1Label;
    }
}

