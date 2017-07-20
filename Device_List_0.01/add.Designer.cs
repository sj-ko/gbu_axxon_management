namespace Device_List_0._01
{
    partial class Form_add
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_maker = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "제조사";
            // 
            // comboBox_maker
            // 
            this.comboBox_maker.FormattingEnabled = true;
            this.comboBox_maker.Items.AddRange(new object[] {
            "A사",
            "B사",
            "C사",
            "D사",
            "E사",
            "F사",
            "G사"});
            this.comboBox_maker.Location = new System.Drawing.Point(96, 15);
            this.comboBox_maker.Name = "comboBox_maker";
            this.comboBox_maker.Size = new System.Drawing.Size(145, 20);
            this.comboBox_maker.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "IP";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(96, 47);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(145, 21);
            this.textBox_IP.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "ID";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(96, 81);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(145, 21);
            this.textBox_ID.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "PassWord";
            // 
            // textBox_PW
            // 
            this.textBox_PW.Location = new System.Drawing.Point(96, 113);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.Size = new System.Drawing.Size(145, 21);
            this.textBox_PW.TabIndex = 16;
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_ok.Location = new System.Drawing.Point(63, 153);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 17;
            this.button_ok.Text = "확인";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_cancel.Location = new System.Drawing.Point(166, 153);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 18;
            this.button_cancel.Text = "취소";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 195);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_PW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_maker);
            this.Controls.Add(this.label1);
            this.Name = "Form_add";
            this.Text = "Device Add";
            this.Load += new System.EventHandler(this.Form_add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_maker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}