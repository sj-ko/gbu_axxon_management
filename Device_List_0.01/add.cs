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
    public partial class Form_add : Form
    {
        public Form_add()
        {
            InitializeComponent();
        }

        private void Form_add_Load(object sender, EventArgs e)
        {

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Form_main m = (Form_main)this.Owner;

            ListViewItem lvi = new ListViewItem(comboBox_maker.SelectedItem.ToString());
            lvi.SubItems.Add(textBox_IP.Text);
            lvi.SubItems.Add(textBox_ID.Text);
            lvi.SubItems.Add(textBox_PW.Text);
            m.listView_device.Items.Add(lvi);
            //device_add.Add(new device()){device_manufacturer= comboBox_maker.SelectedItem.ToString(),device_IP= textBox_IP.Text,device_ID= textBox_ID,device_pw= textBox_PW});
        }
    }
}
