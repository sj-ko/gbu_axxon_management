using System;
using System.Windows.Forms;

namespace Device_List_0._01
{
    public partial class Form_Notification : Form
    {
        public Form_Notification()
        {
            InitializeComponent();
            this.KeyPreview = true;

        }

        private void button_no_Click(object sender, EventArgs e)
        {
            Form_add f = (Form_add)this.Owner;
            this.Close();
            f.Close();
        }

        private void button_yes_Click(object sender, EventArgs e)
        {
            Form_add f = (Form_add)this.Owner;
            this.Close();
        }

        private void Form_Notification_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                Form_add m = (Form_add)this.Owner;
                m.Focus();
                this.Close();
            }
        }
    }
}
