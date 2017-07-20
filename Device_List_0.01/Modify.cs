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
    public partial class Form_modify : Form
    {
        public Form_modify()
        {
            InitializeComponent();
        }

        private void Form_modify_Load(object sender, EventArgs e)
        {

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Form_main m = (Form_main)this.Owner;

            int tmp = m.listView_device.SelectedItems[0].Index;
            m.listView_device.Items.Remove(m.listView_device.SelectedItems[0]);

           

            ListViewItem lvi = new ListViewItem(comboBox_maker.SelectedItem.ToString());
            lvi.SubItems.Add(textBox_IP.Text);
            lvi.SubItems.Add(textBox_ID.Text);
            lvi.SubItems.Add(textBox_PW.Text);
            m.listView_device.Items.Add(lvi);

            //todoListview.SelectedItems[0].SubItems[0].Text = memoTextBox.Text; 메모

            //m.camera_list[tmp].camera_manufacturer = comboBox_maker.SelectedItem.ToString();
            m.camera_list.RemoveAt(tmp);
            m.camera_list.Add(new Camera() { camera_manufacturer = comboBox_maker.SelectedItem.ToString(), camera_IP = textBox_IP.Text, camera_ID = textBox_ID.ToString(), camera_PW = textBox_PW.ToString() });

            //................................................................................///
            
            m.camera_list[m.camera_list.Count - 1].device.device_name = "임시이름";
            ///................]


            MessageBox.Show("수정되었습니다.");
            this.Close();




        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
