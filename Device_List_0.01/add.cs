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

            m.camera_list.Add(new Camera() { camera_manufacturer = comboBox_maker.SelectedItem.ToString(), camera_IP = textBox_IP.Text, camera_ID = textBox_ID.ToString(), camera_PW = textBox_PW.ToString() });

            //................................................................................///이 아래부터 나중에수정할것들//
            /////////입력받은 maker, ip, id, pw 로 카메라 검색/ tab 메뉴의 항목에 값 저장&초기값으로 초기화..
            ///////////////////////////////Device Setting하고 Network Setting만
            int tmp = m.camera_list.Count;
            m.camera_list[tmp - 1].device.device_name = "임시이름 "+tmp;
            ///................]
            m.camera_list[tmp - 1].device.device_PW = textBox_PW.Text;
            m.camera_list[tmp - 1].device.device_username = "임시유저 "+tmp;
            m.camera_list[tmp - 1].device.device_manufacturer = comboBox_maker.SelectedItem.ToString();
            m.camera_list[tmp - 1].device.device_model = "임시모델 "+tmp;
            m.camera_list[tmp - 1].device.device_firmware = "임시firmware "+tmp;
            m.camera_list[tmp - 1].device.enable = false;

            m.textBox_name.Text = m.camera_list[tmp - 1].device.device_name;
            m.textBox_username.Text = m.camera_list[tmp - 1].device.device_username;
            m.textBox_password.Text = m.camera_list[tmp - 1].device.device_PW;
            m.label_dmodel.Text = m.camera_list[tmp - 1].device.device_model;
            m.label_dmanufacturer.Text = m.camera_list[tmp - 1].device.device_manufacturer;
            m.label_dfireware.Text = m.camera_list[tmp - 1].device.device_firmware;

            m.camera_list[tmp - 1].network.network_IP = "임시 " + tmp;
            m.camera_list[tmp - 1].network.network_http = "http " + tmp;
            m.camera_list[tmp - 1].network.network_https = "https" + tmp;
            m.camera_list[tmp - 1].network.network_rtsp = "rtsp" + tmp;

            m.textBox_ip_adress.Text = m.camera_list[tmp - 1].network.network_IP;
            m.textBox_http_port.Text = m.camera_list[tmp - 1].network.network_http;
            m.textBox_https_port.Text = m.camera_list[tmp - 1].network.network_https;
            m.textBox_rtsp_port.Text = m.camera_list[tmp - 1].network.network_rtsp;


            ///m.탭메뉴 아이템들 할당이 add.cs에서 item add될때마다가 아닌 list_view의 아이템을 클릭할 때 마다 선택된 아이템의 설정이 tab메뉴에 보이도록 수정,,,? ? ?
            ///////////////////////////////////////////////////////////////////////////////////////////////////////


            Form_Notification check = new Form_Notification();
            check.Owner = this;
            check.Show();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
