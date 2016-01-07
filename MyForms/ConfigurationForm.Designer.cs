namespace lab4.MyForms
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.funcOfFWtabPage = new System.Windows.Forms.TabPage();
            this.statCheckBox = new System.Windows.Forms.CheckBox();
            this.natCheckBox = new System.Windows.Forms.CheckBox();
            this.filterCheckBox = new System.Windows.Forms.CheckBox();
            this.filterTabPage = new System.Windows.Forms.TabPage();
            this.clearFilterButton = new System.Windows.Forms.Button();
            this.delFilterButton = new System.Windows.Forms.Button();
            this.addFilterButton = new System.Windows.Forms.Button();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NatTabPage = new System.Windows.Forms.TabPage();
            this.clearTabButton = new System.Windows.Forms.Button();
            this.delFromTabButton = new System.Windows.Forms.Button();
            this.addToTabButton = new System.Windows.Forms.Button();
            this.natExternalTextBox = new System.Windows.Forms.TextBox();
            this.natIntraTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ipSrcFiltListBox = new System.Windows.Forms.ListBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.ipDstFiltListBox = new System.Windows.Forms.ListBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.portsFiltListBox = new System.Windows.Forms.ListBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.protoFiltListBox = new System.Windows.Forms.ListBox();
            this.tabNatListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.funcOfFWtabPage.SuspendLayout();
            this.filterTabPage.SuspendLayout();
            this.NatTabPage.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.funcOfFWtabPage);
            this.tabControl1.Controls.Add(this.filterTabPage);
            this.tabControl1.Controls.Add(this.NatTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(510, 221);
            this.tabControl1.TabIndex = 13;
            // 
            // funcOfFWtabPage
            // 
            this.funcOfFWtabPage.BackColor = System.Drawing.SystemColors.Control;
            this.funcOfFWtabPage.Controls.Add(this.statCheckBox);
            this.funcOfFWtabPage.Controls.Add(this.natCheckBox);
            this.funcOfFWtabPage.Controls.Add(this.filterCheckBox);
            this.funcOfFWtabPage.Location = new System.Drawing.Point(4, 22);
            this.funcOfFWtabPage.Name = "funcOfFWtabPage";
            this.funcOfFWtabPage.Padding = new System.Windows.Forms.Padding(3);
            this.funcOfFWtabPage.Size = new System.Drawing.Size(502, 195);
            this.funcOfFWtabPage.TabIndex = 0;
            this.funcOfFWtabPage.Text = "Функции фаервола";
            // 
            // statCheckBox
            // 
            this.statCheckBox.AutoSize = true;
            this.statCheckBox.Location = new System.Drawing.Point(90, 101);
            this.statCheckBox.Name = "statCheckBox";
            this.statCheckBox.Size = new System.Drawing.Size(111, 17);
            this.statCheckBox.TabIndex = 2;
            this.statCheckBox.Text = "Сбор статистики";
            this.statCheckBox.UseVisualStyleBackColor = true;
            this.statCheckBox.CheckedChanged += new System.EventHandler(this.statCheckBox_CheckedChanged);
            // 
            // natCheckBox
            // 
            this.natCheckBox.AutoSize = true;
            this.natCheckBox.Location = new System.Drawing.Point(90, 66);
            this.natCheckBox.Name = "natCheckBox";
            this.natCheckBox.Size = new System.Drawing.Size(132, 17);
            this.natCheckBox.TabIndex = 1;
            this.natCheckBox.Text = "Трансляция адресов";
            this.natCheckBox.UseVisualStyleBackColor = true;
            this.natCheckBox.CheckedChanged += new System.EventHandler(this.natCheckBox_CheckedChanged);
            // 
            // filterCheckBox
            // 
            this.filterCheckBox.AutoSize = true;
            this.filterCheckBox.Location = new System.Drawing.Point(90, 34);
            this.filterCheckBox.Name = "filterCheckBox";
            this.filterCheckBox.Size = new System.Drawing.Size(134, 17);
            this.filterCheckBox.TabIndex = 0;
            this.filterCheckBox.Text = "Фильтрация пакетов";
            this.filterCheckBox.UseVisualStyleBackColor = true;
            this.filterCheckBox.CheckedChanged += new System.EventHandler(this.filterCheckBox_CheckedChanged);
            // 
            // filterTabPage
            // 
            this.filterTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.filterTabPage.Controls.Add(this.tabControl4);
            this.filterTabPage.Controls.Add(this.clearFilterButton);
            this.filterTabPage.Controls.Add(this.delFilterButton);
            this.filterTabPage.Controls.Add(this.addFilterButton);
            this.filterTabPage.Controls.Add(this.filterTextBox);
            this.filterTabPage.Controls.Add(this.label1);
            this.filterTabPage.Location = new System.Drawing.Point(4, 22);
            this.filterTabPage.Name = "filterTabPage";
            this.filterTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.filterTabPage.Size = new System.Drawing.Size(502, 195);
            this.filterTabPage.TabIndex = 1;
            this.filterTabPage.Text = "Настройка фильтра";
            // 
            // clearFilterButton
            // 
            this.clearFilterButton.Location = new System.Drawing.Point(157, 156);
            this.clearFilterButton.Name = "clearFilterButton";
            this.clearFilterButton.Size = new System.Drawing.Size(113, 23);
            this.clearFilterButton.TabIndex = 4;
            this.clearFilterButton.Text = "Сбросить фильтр";
            this.clearFilterButton.UseVisualStyleBackColor = true;
            this.clearFilterButton.Click += new System.EventHandler(this.clearFilterButton_Click);
            // 
            // delFilterButton
            // 
            this.delFilterButton.Location = new System.Drawing.Point(366, 156);
            this.delFilterButton.Name = "delFilterButton";
            this.delFilterButton.Size = new System.Drawing.Size(75, 23);
            this.delFilterButton.TabIndex = 3;
            this.delFilterButton.Text = "Удалить";
            this.delFilterButton.UseVisualStyleBackColor = true;
            this.delFilterButton.Click += new System.EventHandler(this.delFilterButton_Click);
            // 
            // addFilterButton
            // 
            this.addFilterButton.Location = new System.Drawing.Point(366, 127);
            this.addFilterButton.Name = "addFilterButton";
            this.addFilterButton.Size = new System.Drawing.Size(75, 23);
            this.addFilterButton.TabIndex = 2;
            this.addFilterButton.Text = "Добавить";
            this.addFilterButton.UseVisualStyleBackColor = true;
            this.addFilterButton.Click += new System.EventHandler(this.addFilterButton_Click);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(111, 127);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(230, 20);
            this.filterTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фильтр:";
            // 
            // NatTabPage
            // 
            this.NatTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.NatTabPage.Controls.Add(this.tabNatListView);
            this.NatTabPage.Controls.Add(this.clearTabButton);
            this.NatTabPage.Controls.Add(this.delFromTabButton);
            this.NatTabPage.Controls.Add(this.addToTabButton);
            this.NatTabPage.Controls.Add(this.natExternalTextBox);
            this.NatTabPage.Controls.Add(this.natIntraTextBox);
            this.NatTabPage.Controls.Add(this.label3);
            this.NatTabPage.Controls.Add(this.label2);
            this.NatTabPage.Location = new System.Drawing.Point(4, 22);
            this.NatTabPage.Name = "NatTabPage";
            this.NatTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NatTabPage.Size = new System.Drawing.Size(502, 195);
            this.NatTabPage.TabIndex = 2;
            this.NatTabPage.Text = "Настройка NAT";
            // 
            // clearTabButton
            // 
            this.clearTabButton.Location = new System.Drawing.Point(142, 168);
            this.clearTabButton.Name = "clearTabButton";
            this.clearTabButton.Size = new System.Drawing.Size(118, 23);
            this.clearTabButton.TabIndex = 6;
            this.clearTabButton.Text = "Очистить таблицу";
            this.clearTabButton.UseVisualStyleBackColor = true;
            this.clearTabButton.Click += new System.EventHandler(this.clearTabButton_Click);
            // 
            // delFromTabButton
            // 
            this.delFromTabButton.Location = new System.Drawing.Point(328, 145);
            this.delFromTabButton.Name = "delFromTabButton";
            this.delFromTabButton.Size = new System.Drawing.Size(130, 23);
            this.delFromTabButton.TabIndex = 5;
            this.delFromTabButton.Text = "Удалить из таблицы";
            this.delFromTabButton.UseVisualStyleBackColor = true;
            this.delFromTabButton.Click += new System.EventHandler(this.delFromTabButton_Click);
            // 
            // addToTabButton
            // 
            this.addToTabButton.Location = new System.Drawing.Point(328, 114);
            this.addToTabButton.Name = "addToTabButton";
            this.addToTabButton.Size = new System.Drawing.Size(130, 23);
            this.addToTabButton.TabIndex = 4;
            this.addToTabButton.Text = "Добавить в таблицу";
            this.addToTabButton.UseVisualStyleBackColor = true;
            this.addToTabButton.Click += new System.EventHandler(this.addToTabButton_Click);
            // 
            // natExternalTextBox
            // 
            this.natExternalTextBox.Location = new System.Drawing.Point(133, 142);
            this.natExternalTextBox.Name = "natExternalTextBox";
            this.natExternalTextBox.Size = new System.Drawing.Size(176, 20);
            this.natExternalTextBox.TabIndex = 3;
            // 
            // natIntraTextBox
            // 
            this.natIntraTextBox.Location = new System.Drawing.Point(133, 117);
            this.natIntraTextBox.Name = "natIntraTextBox";
            this.natIntraTextBox.Size = new System.Drawing.Size(176, 20);
            this.natIntraTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Внешнесетевой адрес:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Внутрисетевой адрес:";
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage6);
            this.tabControl4.Controls.Add(this.tabPage7);
            this.tabControl4.Controls.Add(this.tabPage8);
            this.tabControl4.Controls.Add(this.tabPage9);
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(499, 125);
            this.tabControl4.TabIndex = 14;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ipSrcFiltListBox);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(491, 99);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "IP-отправителя";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ipSrcFiltListBox
            // 
            this.ipSrcFiltListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipSrcFiltListBox.FormattingEnabled = true;
            this.ipSrcFiltListBox.Location = new System.Drawing.Point(3, 3);
            this.ipSrcFiltListBox.Name = "ipSrcFiltListBox";
            this.ipSrcFiltListBox.Size = new System.Drawing.Size(485, 93);
            this.ipSrcFiltListBox.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.ipDstFiltListBox);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(457, 211);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "IP-получателя";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // ipDstFiltListBox
            // 
            this.ipDstFiltListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipDstFiltListBox.FormattingEnabled = true;
            this.ipDstFiltListBox.Location = new System.Drawing.Point(3, 3);
            this.ipDstFiltListBox.Name = "ipDstFiltListBox";
            this.ipDstFiltListBox.Size = new System.Drawing.Size(451, 205);
            this.ipDstFiltListBox.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.portsFiltListBox);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(457, 211);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "Порты";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // portsFiltListBox
            // 
            this.portsFiltListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portsFiltListBox.FormattingEnabled = true;
            this.portsFiltListBox.Location = new System.Drawing.Point(0, 0);
            this.portsFiltListBox.Name = "portsFiltListBox";
            this.portsFiltListBox.Size = new System.Drawing.Size(457, 211);
            this.portsFiltListBox.TabIndex = 0;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.protoFiltListBox);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(457, 211);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "Протоколы";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // protoFiltListBox
            // 
            this.protoFiltListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.protoFiltListBox.FormattingEnabled = true;
            this.protoFiltListBox.Location = new System.Drawing.Point(0, 0);
            this.protoFiltListBox.Name = "protoFiltListBox";
            this.protoFiltListBox.Size = new System.Drawing.Size(457, 211);
            this.protoFiltListBox.TabIndex = 0;
            // 
            // tabNatListView
            // 
            this.tabNatListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.tabNatListView.Location = new System.Drawing.Point(3, 3);
            this.tabNatListView.Name = "tabNatListView";
            this.tabNatListView.Size = new System.Drawing.Size(498, 105);
            this.tabNatListView.TabIndex = 7;
            this.tabNatListView.UseCompatibleStateImageBehavior = false;
            this.tabNatListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Внутресетевой адрес";
            this.columnHeader1.Width = 226;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Внешнесетевой адрес";
            this.columnHeader2.Width = 261;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 221);
            this.Controls.Add(this.tabControl1);
            this.Name = "ConfigurationForm";
            this.Text = "Configuration";
            this.tabControl1.ResumeLayout(false);
            this.funcOfFWtabPage.ResumeLayout(false);
            this.funcOfFWtabPage.PerformLayout();
            this.filterTabPage.ResumeLayout(false);
            this.filterTabPage.PerformLayout();
            this.NatTabPage.ResumeLayout(false);
            this.NatTabPage.PerformLayout();
            this.tabControl4.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage funcOfFWtabPage;
        private System.Windows.Forms.CheckBox statCheckBox;
        private System.Windows.Forms.CheckBox natCheckBox;
        private System.Windows.Forms.CheckBox filterCheckBox;
        private System.Windows.Forms.TabPage filterTabPage;
        private System.Windows.Forms.Button clearFilterButton;
        private System.Windows.Forms.Button delFilterButton;
        private System.Windows.Forms.Button addFilterButton;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage NatTabPage;
        private System.Windows.Forms.Button clearTabButton;
        private System.Windows.Forms.Button delFromTabButton;
        private System.Windows.Forms.Button addToTabButton;
        private System.Windows.Forms.TextBox natExternalTextBox;
        private System.Windows.Forms.TextBox natIntraTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListBox ipSrcFiltListBox;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ListBox ipDstFiltListBox;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.ListBox portsFiltListBox;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.ListBox protoFiltListBox;
        private System.Windows.Forms.ListView tabNatListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}