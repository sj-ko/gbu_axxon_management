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
            
            //................................................................................///
            /////////입력받은 maker, ip, id, pw 로 카메라 검색/ tab 메뉴의 항목에 값 저장&초기값으로 초기화..
            ///////////////////////////////다시하기
            m.camera_list[m.camera_list.Count - 1].device.device_name = "임시이름";
            ///................]
            m.camera_list[m.camera_list.Count - 1].device.device_PW = textBox_PW.Text;
            m.camera_list[m.camera_list.Count - 1].device.device_username = "임시유저";
            m.camera_list[m.camera_list.Count - 1].device.device_manufacturer = comboBox_maker.SelectedItem.ToString();
            m.camera_list[m.camera_list.Count - 1].device.device_model = "임시모델";
            m.camera_list[m.camera_list.Count - 1].device.device_firmware = "임시";
            m.camera_list[m.camera_list.Count - 1].device.enable = false;

            m.textBox_name.Text = m.camera_list[m.camera_list.Count - 1].device.device_name;
            m.textBox_password.Text = m.camera_list[m.camera_list.Count - 1].device.device_PW;
            m.textBox_username.Text = m.camera_list[m.camera_list.Count - 1].device.device_username;
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
