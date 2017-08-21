namespace Device_List_0._01
{
    partial class Form_Search
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
            this.comboBox_search_TYPE = new System.Windows.Forms.ComboBox();
            this.textBox_search_KEYWORD = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.button_fin = new System.Windows.Forms.Button();
            this.textBox_fullname = new System.Windows.Forms.TextBox();
            this.label_type = new System.Windows.Forms.Label();
            this.button_before = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "검색 방법";
            // 
            // comboBox_search_TYPE
            // 
            this.comboBox_search_TYPE.FormattingEnabled = true;
            this.comboBox_search_TYPE.Items.AddRange(new object[] {
            "카메라 ID",
            "카메라 이름"});
            this.comboBox_search_TYPE.Location = new System.Drawing.Point(127, 30);
            this.comboBox_search_TYPE.Name = "comboBox_search_TYPE";
            this.comboBox_search_TYPE.Size = new System.Drawing.Size(173, 20);
            this.comboBox_search_TYPE.TabIndex = 0;
            this.comboBox_search_TYPE.SelectedIndexChanged += new System.EventHandler(this.comboBox_search_TYPE_SelectedIndexChanged);
            // 
            // textBox_search_KEYWORD
            // 
            this.textBox_search_KEYWORD.Location = new System.Drawing.Point(127, 65);
            this.textBox_search_KEYWORD.Name = "textBox_search_KEYWORD";
            this.textBox_search_KEYWORD.Size = new System.Drawing.Size(173, 21);
            this.textBox_search_KEYWORD.TabIndex = 1;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(340, 30);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(95, 23);
            this.button_search.TabIndex = 3;
            this.button_search.Text = "검색";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(340, 65);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(95, 23);
            this.button_next.TabIndex = 4;
            this.button_next.Text = "다음";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_fin
            // 
            this.button_fin.Location = new System.Drawing.Point(340, 140);
            this.button_fin.Name = "button_fin";
            this.button_fin.Size = new System.Drawing.Size(95, 23);
            this.button_fin.TabIndex = 6;
            this.button_fin.Text = "종료";
            this.button_fin.UseVisualStyleBackColor = true;
            this.button_fin.Click += new System.EventHandler(this.button_fin_Click);
            // 
            // textBox_fullname
            // 
            this.textBox_fullname.Enabled = false;
            this.textBox_fullname.Location = new System.Drawing.Point(40, 100);
            this.textBox_fullname.Name = "textBox_fullname";
            this.textBox_fullname.Size = new System.Drawing.Size(260, 21);
            this.textBox_fullname.TabIndex = 2;
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(38, 68);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(0, 12);
            this.label_type.TabIndex = 6;
            // 
            // button_before
            // 
            this.button_before.Location = new System.Drawing.Point(340, 100);
            this.button_before.Name = "button_before";
            this.button_before.Size = new System.Drawing.Size(95, 23);
            this.button_before.TabIndex = 5;
            this.button_before.Text = "이전";
            this.button_before.UseVisualStyleBackColor = true;
            this.button_before.Click += new System.EventHandler(this.button_before_Click);
            // 
            // Form_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 189);
            this.Controls.Add(this.button_before);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.textBox_fullname);
            this.Controls.Add(this.button_fin);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_search_KEYWORD);
            this.Controls.Add(this.comboBox_search_TYPE);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form_Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Form_Search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox_search_TYPE;
        public System.Windows.Forms.TextBox textBox_search_KEYWORD;
        public System.Windows.Forms.Button button_search;
        public System.Windows.Forms.Button button_next;
        public System.Windows.Forms.Button button_fin;
        public System.Windows.Forms.TextBox textBox_fullname;
        public System.Windows.Forms.Label label_type;
        public System.Windows.Forms.Button button_before;
    }
}