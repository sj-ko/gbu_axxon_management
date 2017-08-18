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
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.textBox_add_latitude = new System.Windows.Forms.TextBox();
            this.textBox_add_longgitude = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_cameraNAME = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_cameraID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_model = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 24);
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
            this.comboBox_maker.Location = new System.Drawing.Point(95, 15);
            this.comboBox_maker.Name = "comboBox_maker";
            this.comboBox_maker.Size = new System.Drawing.Size(145, 20);
            this.comboBox_maker.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "IP";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(95, 45);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(145, 21);
            this.textBox_IP.TabIndex = 1;
            this.textBox_IP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_IP_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "username";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(95, 105);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(145, 21);
            this.textBox_username.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "PassWord";
            // 
            // textBox_PW
            // 
            this.textBox_PW.Location = new System.Drawing.Point(95, 135);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.Size = new System.Drawing.Size(145, 21);
            this.textBox_PW.TabIndex = 4;
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_ok.Location = new System.Drawing.Point(327, 195);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 10;
            this.button_ok.Text = "확인";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_cancel.Location = new System.Drawing.Point(430, 195);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 11;
            this.button_cancel.Text = "취소";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(295, 114);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 12);
            this.label33.TabIndex = 19;
            this.label33.Text = "Latitude";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(284, 144);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(60, 12);
            this.label40.TabIndex = 20;
            this.label40.Text = "Longitude";
            // 
            // textBox_add_latitude
            // 
            this.textBox_add_latitude.Location = new System.Drawing.Point(360, 105);
            this.textBox_add_latitude.Name = "textBox_add_latitude";
            this.textBox_add_latitude.Size = new System.Drawing.Size(145, 21);
            this.textBox_add_latitude.TabIndex = 8;
            this.textBox_add_latitude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_add_latitude_KeyPress);
            // 
            // textBox_add_longgitude
            // 
            this.textBox_add_longgitude.Location = new System.Drawing.Point(360, 135);
            this.textBox_add_longgitude.Name = "textBox_add_longgitude";
            this.textBox_add_longgitude.Size = new System.Drawing.Size(145, 21);
            this.textBox_add_longgitude.TabIndex = 9;
            this.textBox_add_longgitude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_add_longgitude_KeyPress);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(95, 75);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(145, 21);
            this.textBox_port.TabIndex = 2;
            this.textBox_port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_port_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "Port";
            // 
            // textBox_cameraNAME
            // 
            this.textBox_cameraNAME.Location = new System.Drawing.Point(360, 75);
            this.textBox_cameraNAME.Name = "textBox_cameraNAME";
            this.textBox_cameraNAME.Size = new System.Drawing.Size(145, 21);
            this.textBox_cameraNAME.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "Camera Name";
            // 
            // textBox_cameraID
            // 
            this.textBox_cameraID.Location = new System.Drawing.Point(360, 45);
            this.textBox_cameraID.Name = "textBox_cameraID";
            this.textBox_cameraID.Size = new System.Drawing.Size(145, 21);
            this.textBox_cameraID.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "Camera ID";
            // 
            // textBox_model
            // 
            this.textBox_model.Location = new System.Drawing.Point(360, 15);
            this.textBox_model.Name = "textBox_model";
            this.textBox_model.Size = new System.Drawing.Size(145, 21);
            this.textBox_model.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "모델명";
            // 
            // Form_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 242);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_cameraNAME);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_cameraID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_model);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_add_longgitude);
            this.Controls.Add(this.textBox_add_latitude);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_PW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_maker);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form_add";
            this.Text = "Device Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_maker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label40;
        public System.Windows.Forms.TextBox textBox_add_latitude;
        public System.Windows.Forms.TextBox textBox_add_longgitude;
        public System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_cameraNAME;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_cameraID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_model;
        private System.Windows.Forms.Label label9;
    }
}