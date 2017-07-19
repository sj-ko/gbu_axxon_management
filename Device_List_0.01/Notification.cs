using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Device_List_0._01
{
    public partial class Form_Notification : Form
    {
        public Form_Notification()
        {
            InitializeComponent();
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
    }
}
