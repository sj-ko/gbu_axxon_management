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
    public partial class Form_list : Form
    {
        public Form_list()
        {
            InitializeComponent();

            listView_excel.View = View.Details;
            listView_excel.BeginUpdate();
        }

        private void Form_list_Load(object sender, EventArgs e)
        {
            Form_main r = (Form_main)this.Owner;
            
            for (int i=0;i< r.camera_list.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(r.camera_list[i].camera_server);
                lvi.SubItems.Add(r.camera_list[i].camera_IP);
                lvi.SubItems.Add(r.camera_list[i].device.device_manufacturer);
                lvi.SubItems.Add(r.camera_list[i].device.device_model);
                lvi.SubItems.Add(r.camera_list[i].device.device_name);
                lvi.SubItems.Add(r.camera_list[i].device.device_username);
                lvi.SubItems.Add(r.camera_list[i].device.device_PW);
                r.comboBox_resolution_main.SelectedIndex = r.camera_list[i].video.video_main_resolution;
                lvi.SubItems.Add(r.comboBox_resolution_main.SelectedItem.ToString());
                r.comboBox_codec_main.SelectedIndex = r.camera_list[i].video.video_main_codec;
                lvi.SubItems.Add(r.comboBox_codec_main.SelectedItem.ToString());
                listView_excel.Items.Add(lvi);
            }
        }
    }
}
