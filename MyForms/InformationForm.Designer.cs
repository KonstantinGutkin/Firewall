namespace lab4.MyForms
{
    partial class InformationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totalCountLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.icmpCountLabel = new System.Windows.Forms.Label();
            this.udpCountLabel = new System.Windows.Forms.Label();
            this.tcpCountLabel = new System.Windows.Forms.Label();
            this.ipCountLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.totalCountLabel);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.icmpCountLabel);
            this.groupBox1.Controls.Add(this.udpCountLabel);
            this.groupBox1.Controls.Add(this.tcpCountLabel);
            this.groupBox1.Controls.Add(this.ipCountLabel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 128);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Количество";
            // 
            // totalCountLabel
            // 
            this.totalCountLabel.AutoSize = true;
            this.totalCountLabel.Location = new System.Drawing.Point(54, 97);
            this.totalCountLabel.Name = "totalCountLabel";
            this.totalCountLabel.Size = new System.Drawing.Size(16, 13);
            this.totalCountLabel.TabIndex = 9;
            this.totalCountLabel.Text = "...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Всего:";
            // 
            // icmpCountLabel
            // 
            this.icmpCountLabel.AutoSize = true;
            this.icmpCountLabel.Location = new System.Drawing.Point(49, 71);
            this.icmpCountLabel.Name = "icmpCountLabel";
            this.icmpCountLabel.Size = new System.Drawing.Size(16, 13);
            this.icmpCountLabel.TabIndex = 7;
            this.icmpCountLabel.Text = "...";
            // 
            // udpCountLabel
            // 
            this.udpCountLabel.AutoSize = true;
            this.udpCountLabel.Location = new System.Drawing.Point(49, 54);
            this.udpCountLabel.Name = "udpCountLabel";
            this.udpCountLabel.Size = new System.Drawing.Size(16, 13);
            this.udpCountLabel.TabIndex = 6;
            this.udpCountLabel.Text = "...";
            // 
            // tcpCountLabel
            // 
            this.tcpCountLabel.AutoSize = true;
            this.tcpCountLabel.Location = new System.Drawing.Point(49, 37);
            this.tcpCountLabel.Name = "tcpCountLabel";
            this.tcpCountLabel.Size = new System.Drawing.Size(16, 13);
            this.tcpCountLabel.TabIndex = 5;
            this.tcpCountLabel.Text = "...";
            // 
            // ipCountLabel
            // 
            this.ipCountLabel.AutoSize = true;
            this.ipCountLabel.Location = new System.Drawing.Point(49, 20);
            this.ipCountLabel.Name = "ipCountLabel";
            this.ipCountLabel.Size = new System.Drawing.Size(16, 13);
            this.ipCountLabel.TabIndex = 4;
            this.ipCountLabel.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "ICMP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "UDP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "TCP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP:";
            // 
            // InformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(147, 128);
            this.Controls.Add(this.groupBox1);
            this.Name = "InformationForm";
            this.Text = "InformationForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label totalCountLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label icmpCountLabel;
        private System.Windows.Forms.Label udpCountLabel;
        private System.Windows.Forms.Label tcpCountLabel;
        private System.Windows.Forms.Label ipCountLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}