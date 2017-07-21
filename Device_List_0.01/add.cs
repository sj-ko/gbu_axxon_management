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
            string pw="";
            for (int i = 0; i < textBox_PW.TextLength; i++)
                pw = pw + "*";
            
            ListViewItem lvi = new ListViewItem(comboBox_maker.SelectedItem.ToString());
            lvi.SubItems.Add(textBox_IP.Text);
            lvi.SubItems.Add(textBox_ID.Text);
            lvi.SubItems.Add(pw);
            //lvi.SubItems.Add(textBox_PW.Text);
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

            m.camera_list[tmp - 1].network.network_IP = textBox_IP.Text;
            m.camera_list[tmp - 1].network.network_http = "1" + tmp;
            m.camera_list[tmp - 1].network.network_https = "2" + tmp;
            m.camera_list[tmp - 1].network.network_rtsp = "3" + tmp;

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

        private void textBox_PW_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_IP_KeyPress(object sender, KeyPressEventArgs e)
        {

            int iPos = 0;               // IP 구역의 현재 위치
            int iDelimitNumber = 0;     // IP 구역의 갯수

            int iLength = textBox_IP.Text.Length;
            int iIndex = textBox_IP.Text.LastIndexOf(".");

            int iIndex2 = -1;
            while (true)
            {
                iIndex2 = textBox_IP.Text.IndexOf(".", iIndex2 + 1);

                if (iIndex2 == -1)      //. 탐색 끝
                    break;

                ++iDelimitNumber;
            }

            // 숫자키와 백스페이스, '.' 만 입력 가능
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                MessageBox.Show("숫자만 입력 가능합니다", "오류");
                e.Handled = true;
                return;
            }

            if (e.KeyChar != 8)
            {
                if (e.KeyChar != '.')
                {
                    if (iIndex > 0)
                        iPos = iLength - iIndex;
                    else
                        iPos = iLength + 1;

                    if (iPos == 3)
                    {
                        // 255 이상 체크
                        string strTmp = textBox_IP.Text.Substring(iIndex + 1) + e.KeyChar;
                        if (Int32.Parse(strTmp) > 255)
                        {
                            MessageBox.Show("255를 넘길수 없습니다.", "오류");
                            e.Handled = true;
                            return;
                        }
                        else
                        {
                            // 3자리가 넘어가면 자동으로 .을 찍어준다
                            if (iDelimitNumber < 3)
                            {
                                textBox_IP.AppendText(e.KeyChar.ToString());
                                textBox_IP.AppendText(".");
                                iDelimitNumber++;
                                e.Handled = true;
                                return;
                            }
                        }
                    }

                    // IP 마지막 4자리째는 무조건 무시
                    if (iPos == 4)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    // 아이피가 3구역 이상 쓰였으면, 이후 키는 무시한다
                    if (iDelimitNumber + 1 > 3)
                    {
                        MessageBox.Show("IP 주소가 정확하지 않습니다.", "오류");
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        // 연속으로 .을 찍었으면 오류
                        if (textBox_IP.Text.EndsWith("."))
                        {
                            MessageBox.Show("IP 주소가 정확하지 않습니다.", "오류");
                            e.Handled = true;
                            return;
                        }
                        else
                            iDelimitNumber++;
                    }
                }
            }
        }
    }
}
