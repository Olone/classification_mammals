namespace WindowsFormsApp5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButtonRegistration = new System.Windows.Forms.Button();
            this.ButtonEntry = new System.Windows.Forms.Button();
            this.TextBoxNik = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.LabelNik = new System.Windows.Forms.Label();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.LabelRepeatPassword = new System.Windows.Forms.Label();
            this.TextBoxRepeatPassword = new System.Windows.Forms.TextBox();
            this.LabelNotSamePasswords = new System.Windows.Forms.Label();
            this.LabelEmptyNik = new System.Windows.Forms.Label();
            this.LabelEmptyPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonRegistration
            // 
            this.ButtonRegistration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ButtonRegistration.AutoSize = true;
            this.ButtonRegistration.BackColor = System.Drawing.Color.Silver;
            this.ButtonRegistration.Location = new System.Drawing.Point(637, 298);
            this.ButtonRegistration.Name = "ButtonRegistration";
            this.ButtonRegistration.Size = new System.Drawing.Size(306, 58);
            this.ButtonRegistration.TabIndex = 3;
            this.ButtonRegistration.Text = "Регистрация";
            this.ButtonRegistration.UseVisualStyleBackColor = false;
            this.ButtonRegistration.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ButtonEntry
            // 
            this.ButtonEntry.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ButtonEntry.AutoSize = true;
            this.ButtonEntry.BackColor = System.Drawing.Color.Silver;
            this.ButtonEntry.Location = new System.Drawing.Point(325, 298);
            this.ButtonEntry.Name = "ButtonEntry";
            this.ButtonEntry.Size = new System.Drawing.Size(306, 58);
            this.ButtonEntry.TabIndex = 2;
            this.ButtonEntry.Text = "Вход";
            this.ButtonEntry.UseVisualStyleBackColor = false;
            this.ButtonEntry.Click += new System.EventHandler(this.Entry_Click);
            // 
            // TextBoxNik
            // 
            this.TextBoxNik.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextBoxNik.ForeColor = System.Drawing.Color.Black;
            this.TextBoxNik.Location = new System.Drawing.Point(570, 171);
            this.TextBoxNik.Name = "TextBoxNik";
            this.TextBoxNik.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxNik.Size = new System.Drawing.Size(183, 22);
            this.TextBoxNik.TabIndex = 0;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextBoxPassword.ForeColor = System.Drawing.Color.Black;
            this.TextBoxPassword.Location = new System.Drawing.Point(570, 220);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(183, 22);
            this.TextBoxPassword.TabIndex = 1;
            this.TextBoxPassword.UseSystemPasswordChar = true;
            // 
            // LabelNik
            // 
            this.LabelNik.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelNik.AutoSize = true;
            this.LabelNik.BackColor = System.Drawing.Color.LightGray;
            this.LabelNik.Location = new System.Drawing.Point(461, 171);
            this.LabelNik.Name = "LabelNik";
            this.LabelNik.Size = new System.Drawing.Size(66, 17);
            this.LabelNik.TabIndex = 4;
            this.LabelNik.Text = "Никнейм";
            // 
            // LabelPassword
            // 
            this.LabelPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.BackColor = System.Drawing.Color.LightGray;
            this.LabelPassword.Location = new System.Drawing.Point(470, 220);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(57, 17);
            this.LabelPassword.TabIndex = 5;
            this.LabelPassword.Text = "Пароль";
            // 
            // LabelRepeatPassword
            // 
            this.LabelRepeatPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelRepeatPassword.AutoSize = true;
            this.LabelRepeatPassword.BackColor = System.Drawing.Color.LightGray;
            this.LabelRepeatPassword.Location = new System.Drawing.Point(397, 270);
            this.LabelRepeatPassword.Name = "LabelRepeatPassword";
            this.LabelRepeatPassword.Size = new System.Drawing.Size(130, 17);
            this.LabelRepeatPassword.TabIndex = 6;
            this.LabelRepeatPassword.Text = "Повторите пароль";
            this.LabelRepeatPassword.Visible = false;
            // 
            // TextBoxRepeatPassword
            // 
            this.TextBoxRepeatPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextBoxRepeatPassword.ForeColor = System.Drawing.Color.Black;
            this.TextBoxRepeatPassword.Location = new System.Drawing.Point(570, 270);
            this.TextBoxRepeatPassword.Name = "TextBoxRepeatPassword";
            this.TextBoxRepeatPassword.Size = new System.Drawing.Size(183, 22);
            this.TextBoxRepeatPassword.TabIndex = 4;
            this.TextBoxRepeatPassword.UseSystemPasswordChar = true;
            this.TextBoxRepeatPassword.Visible = false;
            // 
            // LabelNotSamePasswords
            // 
            this.LabelNotSamePasswords.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelNotSamePasswords.AutoSize = true;
            this.LabelNotSamePasswords.BackColor = System.Drawing.Color.Silver;
            this.LabelNotSamePasswords.ForeColor = System.Drawing.Color.Maroon;
            this.LabelNotSamePasswords.Location = new System.Drawing.Point(774, 275);
            this.LabelNotSamePasswords.Name = "LabelNotSamePasswords";
            this.LabelNotSamePasswords.Size = new System.Drawing.Size(153, 17);
            this.LabelNotSamePasswords.TabIndex = 8;
            this.LabelNotSamePasswords.Text = "Пароли не совпадают";
            this.LabelNotSamePasswords.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.LabelNotSamePasswords.Visible = false;
            // 
            // LabelEmptyNik
            // 
            this.LabelEmptyNik.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelEmptyNik.AutoSize = true;
            this.LabelEmptyNik.BackColor = System.Drawing.Color.Silver;
            this.LabelEmptyNik.ForeColor = System.Drawing.Color.Maroon;
            this.LabelEmptyNik.Location = new System.Drawing.Point(777, 175);
            this.LabelEmptyNik.Name = "LabelEmptyNik";
            this.LabelEmptyNik.Size = new System.Drawing.Size(123, 17);
            this.LabelEmptyNik.TabIndex = 9;
            this.LabelEmptyNik.Text = "Введите никнейм";
            this.LabelEmptyNik.Visible = false;
            // 
            // LabelEmptyPassword
            // 
            this.LabelEmptyPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelEmptyPassword.AutoSize = true;
            this.LabelEmptyPassword.BackColor = System.Drawing.Color.Silver;
            this.LabelEmptyPassword.ForeColor = System.Drawing.Color.Maroon;
            this.LabelEmptyPassword.Location = new System.Drawing.Point(777, 224);
            this.LabelEmptyPassword.Name = "LabelEmptyPassword";
            this.LabelEmptyPassword.Size = new System.Drawing.Size(114, 17);
            this.LabelEmptyPassword.TabIndex = 10;
            this.LabelEmptyPassword.Text = "Введите пароль";
            this.LabelEmptyPassword.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1312, 672);
            this.Controls.Add(this.LabelEmptyPassword);
            this.Controls.Add(this.LabelEmptyNik);
            this.Controls.Add(this.LabelNotSamePasswords);
            this.Controls.Add(this.TextBoxRepeatPassword);
            this.Controls.Add(this.LabelRepeatPassword);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.LabelNik);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxNik);
            this.Controls.Add(this.ButtonEntry);
            this.Controls.Add(this.ButtonRegistration);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Спящий песец";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonRegistration;
        private System.Windows.Forms.Button ButtonEntry;
        private System.Windows.Forms.TextBox TextBoxNik;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label LabelNik;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.Label LabelRepeatPassword;
        private System.Windows.Forms.TextBox TextBoxRepeatPassword;
        private System.Windows.Forms.Label LabelNotSamePasswords;
        private System.Windows.Forms.Label LabelEmptyNik;
        private System.Windows.Forms.Label LabelEmptyPassword;
    }
}

