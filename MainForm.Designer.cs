namespace WindowsFormsApp5
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LabelNik = new System.Windows.Forms.Label();
            this.TreeTaxonomy = new System.Windows.Forms.TreeView();
            this.ButtonAddElement = new System.Windows.Forms.Button();
            this.TextBoxInputName = new System.Windows.Forms.TextBox();
            this.LabelInputName = new System.Windows.Forms.Label();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonInfo = new System.Windows.Forms.Button();
            this.WebBrowserInfo = new System.Windows.Forms.WebBrowser();
            this.ButtonSort = new System.Windows.Forms.Button();
            this.ButtonChange = new System.Windows.Forms.Button();
            this.ButtonToUsers = new System.Windows.Forms.Button();
            this.LabelNewNik = new System.Windows.Forms.Label();
            this.TextBoxNik = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelNik
            // 
            this.LabelNik.AutoSize = true;
            this.LabelNik.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LabelNik.Location = new System.Drawing.Point(12, 513);
            this.LabelNik.Name = "LabelNik";
            this.LabelNik.Size = new System.Drawing.Size(101, 17);
            this.LabelNik.TabIndex = 0;
            this.LabelNik.Text = "Пользователь";
            this.LabelNik.Visible = false;
            // 
            // TreeTaxonomy
            // 
            this.TreeTaxonomy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeTaxonomy.BackColor = System.Drawing.Color.LightGray;
            this.TreeTaxonomy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TreeTaxonomy.HideSelection = false;
            this.TreeTaxonomy.Location = new System.Drawing.Point(167, 0);
            this.TreeTaxonomy.Name = "TreeTaxonomy";
            this.TreeTaxonomy.Size = new System.Drawing.Size(439, 616);
            this.TreeTaxonomy.TabIndex = 1;
            // 
            // ButtonAddElement
            // 
            this.ButtonAddElement.BackColor = System.Drawing.Color.LightGray;
            this.ButtonAddElement.Location = new System.Drawing.Point(-4, 92);
            this.ButtonAddElement.Name = "ButtonAddElement";
            this.ButtonAddElement.Size = new System.Drawing.Size(169, 23);
            this.ButtonAddElement.TabIndex = 3;
            this.ButtonAddElement.Text = "Добавить тип";
            this.ButtonAddElement.UseVisualStyleBackColor = false;
            this.ButtonAddElement.Click += new System.EventHandler(this.ButtonAddElement_Click);
            // 
            // TextBoxInputName
            // 
            this.TextBoxInputName.Location = new System.Drawing.Point(0, 70);
            this.TextBoxInputName.Name = "TextBoxInputName";
            this.TextBoxInputName.Size = new System.Drawing.Size(165, 22);
            this.TextBoxInputName.TabIndex = 4;
            this.TextBoxInputName.Visible = false;
            // 
            // LabelInputName
            // 
            this.LabelInputName.AutoSize = true;
            this.LabelInputName.Location = new System.Drawing.Point(-3, 50);
            this.LabelInputName.Name = "LabelInputName";
            this.LabelInputName.Size = new System.Drawing.Size(168, 17);
            this.LabelInputName.TabIndex = 5;
            this.LabelInputName.Text = "Введите название типа:";
            this.LabelInputName.Visible = false;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(0, 134);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(165, 23);
            this.ButtonDelete.TabIndex = 6;
            this.ButtonDelete.Text = "Удалить тип";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonInfo
            // 
            this.ButtonInfo.Location = new System.Drawing.Point(0, 155);
            this.ButtonInfo.Name = "ButtonInfo";
            this.ButtonInfo.Size = new System.Drawing.Size(165, 44);
            this.ButtonInfo.TabIndex = 7;
            this.ButtonInfo.Text = "Информация о типе";
            this.ButtonInfo.UseVisualStyleBackColor = true;
            this.ButtonInfo.Click += new System.EventHandler(this.ButtonInfo_Click);
            // 
            // WebBrowserInfo
            // 
            this.WebBrowserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebBrowserInfo.Location = new System.Drawing.Point(604, 0);
            this.WebBrowserInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowserInfo.Name = "WebBrowserInfo";
            this.WebBrowserInfo.Size = new System.Drawing.Size(564, 616);
            this.WebBrowserInfo.TabIndex = 8;
            this.WebBrowserInfo.Url = new System.Uri("https://ru.wikipedia.org/wiki/Млекопитающие", System.UriKind.Absolute);
            // 
            // ButtonSort
            // 
            this.ButtonSort.Location = new System.Drawing.Point(0, 196);
            this.ButtonSort.Name = "ButtonSort";
            this.ButtonSort.Size = new System.Drawing.Size(165, 44);
            this.ButtonSort.TabIndex = 9;
            this.ButtonSort.Text = "Сортировать по алфавиту";
            this.ButtonSort.UseVisualStyleBackColor = true;
            this.ButtonSort.Click += new System.EventHandler(this.ButtonSort_Click);
            // 
            // ButtonChange
            // 
            this.ButtonChange.Location = new System.Drawing.Point(0, 112);
            this.ButtonChange.Name = "ButtonChange";
            this.ButtonChange.Size = new System.Drawing.Size(165, 23);
            this.ButtonChange.TabIndex = 10;
            this.ButtonChange.Text = "Изменить тип";
            this.ButtonChange.UseVisualStyleBackColor = true;
            this.ButtonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // ButtonToUsers
            // 
            this.ButtonToUsers.Location = new System.Drawing.Point(0, 237);
            this.ButtonToUsers.Name = "ButtonToUsers";
            this.ButtonToUsers.Size = new System.Drawing.Size(165, 43);
            this.ButtonToUsers.TabIndex = 11;
            this.ButtonToUsers.Text = "Перейти к списку пользователей";
            this.ButtonToUsers.UseVisualStyleBackColor = true;
            this.ButtonToUsers.Visible = false;
            this.ButtonToUsers.Click += new System.EventHandler(this.ButtonToUsers_Click);
            // 
            // LabelNewNik
            // 
            this.LabelNewNik.AutoSize = true;
            this.LabelNewNik.Location = new System.Drawing.Point(-4, 0);
            this.LabelNewNik.Name = "LabelNewNik";
            this.LabelNewNik.Size = new System.Drawing.Size(127, 17);
            this.LabelNewNik.TabIndex = 12;
            this.LabelNewNik.Text = "Введите никнейм:";
            this.LabelNewNik.Visible = false;
            // 
            // TextBoxNik
            // 
            this.TextBoxNik.Location = new System.Drawing.Point(0, 21);
            this.TextBoxNik.Name = "TextBoxNik";
            this.TextBoxNik.Size = new System.Drawing.Size(165, 22);
            this.TextBoxNik.TabIndex = 13;
            this.TextBoxNik.Visible = false;
            // 
            // MainForm
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1167, 616);
            this.Controls.Add(this.TextBoxNik);
            this.Controls.Add(this.LabelNewNik);
            this.Controls.Add(this.ButtonToUsers);
            this.Controls.Add(this.ButtonChange);
            this.Controls.Add(this.ButtonSort);
            this.Controls.Add(this.WebBrowserInfo);
            this.Controls.Add(this.ButtonInfo);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.LabelInputName);
            this.Controls.Add(this.TextBoxInputName);
            this.Controls.Add(this.ButtonAddElement);
            this.Controls.Add(this.TreeTaxonomy);
            this.Controls.Add(this.LabelNik);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Спящий песец";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelNik;
        private System.Windows.Forms.TreeView TreeTaxonomy;
        private System.Windows.Forms.Button ButtonAddElement;
        private System.Windows.Forms.TextBox TextBoxInputName;
        private System.Windows.Forms.Label LabelInputName;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonInfo;
        private System.Windows.Forms.WebBrowser WebBrowserInfo;
        private System.Windows.Forms.Button ButtonSort;
        private System.Windows.Forms.Button ButtonChange;
        private System.Windows.Forms.Button ButtonToUsers;
        private System.Windows.Forms.Label LabelNewNik;
        private System.Windows.Forms.TextBox TextBoxNik;
    }
}
