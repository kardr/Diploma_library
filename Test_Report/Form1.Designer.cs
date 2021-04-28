
namespace Test_Report
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.работаСФорматамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовыйФорматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСоСтрокойПодключенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСТекстомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСИзображениемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выборФонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеФонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(21, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.работаСФорматамиToolStripMenuItem,
            this.работаСоСтрокойПодключенияToolStripMenuItem,
            this.работаСТекстомToolStripMenuItem,
            this.работаСИзображениемToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(826, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // работаСФорматамиToolStripMenuItem
            // 
            this.работаСФорматамиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьНовыйФорматToolStripMenuItem});
            this.работаСФорматамиToolStripMenuItem.Name = "работаСФорматамиToolStripMenuItem";
            this.работаСФорматамиToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.работаСФорматамиToolStripMenuItem.Text = "Работа с форматами";
            // 
            // добавитьНовыйФорматToolStripMenuItem
            // 
            this.добавитьНовыйФорматToolStripMenuItem.Name = "добавитьНовыйФорматToolStripMenuItem";
            this.добавитьНовыйФорматToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.добавитьНовыйФорматToolStripMenuItem.Text = "Добавить новый формат";
            this.добавитьНовыйФорматToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовыйФорматToolStripMenuItem_Click);
            // 
            // работаСоСтрокойПодключенияToolStripMenuItem
            // 
            this.работаСоСтрокойПодключенияToolStripMenuItem.Name = "работаСоСтрокойПодключенияToolStripMenuItem";
            this.работаСоСтрокойПодключенияToolStripMenuItem.Size = new System.Drawing.Size(200, 20);
            this.работаСоСтрокойПодключенияToolStripMenuItem.Text = "Работа со строкой подключения";
            this.работаСоСтрокойПодключенияToolStripMenuItem.Click += new System.EventHandler(this.работаСоСтрокойПодключенияToolStripMenuItem_Click);
            // 
            // работаСТекстомToolStripMenuItem
            // 
            this.работаСТекстомToolStripMenuItem.Name = "работаСТекстомToolStripMenuItem";
            this.работаСТекстомToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.работаСТекстомToolStripMenuItem.Text = "Работа с текстом";
            // 
            // работаСИзображениемToolStripMenuItem
            // 
            this.работаСИзображениемToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выборФонаToolStripMenuItem,
            this.добавлениеФонаToolStripMenuItem});
            this.работаСИзображениемToolStripMenuItem.Name = "работаСИзображениемToolStripMenuItem";
            this.работаСИзображениемToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.работаСИзображениемToolStripMenuItem.Text = "Работа с изображением";
            // 
            // выборФонаToolStripMenuItem
            // 
            this.выборФонаToolStripMenuItem.Name = "выборФонаToolStripMenuItem";
            this.выборФонаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выборФонаToolStripMenuItem.Text = "Выбор фона";
            // 
            // добавлениеФонаToolStripMenuItem
            // 
            this.добавлениеФонаToolStripMenuItem.Name = "добавлениеФонаToolStripMenuItem";
            this.добавлениеФонаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.добавлениеФонаToolStripMenuItem.Text = "Добавление фона";
            this.добавлениеФонаToolStripMenuItem.Click += new System.EventHandler(this.добавлениеФонаToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 309);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem работаСФорматамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовыйФорматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаСоСтрокойПодключенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаСТекстомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаСИзображениемToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выборФонаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавлениеФонаToolStripMenuItem;
    }
}

