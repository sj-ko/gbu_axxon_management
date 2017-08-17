using System;
using System.Windows.Forms;

namespace Device_List_0._01
{
    public partial class Form_add : Form
    {
        public Form_add()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (comboBox_maker.SelectedItem == null || textBox_IP.Text.Length < 1 || textBox_ID.Text.Length < 1 || textBox_PW.Text.Length < 1 || 
                textBox_add_latitude.Text.Length < 1 || textBox_add_longgitude.Text.Length < 1)
            {
                MessageBox.Show("모든 항목을 입력해주세요.");
            }
            else
            {
                Range r = new Range();
                r.rangeset_ver2(textBox_add_latitude, -90, 90);
                r.rangeset_ver2(textBox_add_longgitude, -180, 180);
                if (!(textBox_add_latitude.Text == "") && !(textBox_add_longgitude.Text == ""))
                {
                    Form_main m = (Form_main)this.Owner;

                    ListViewItem lvi = new ListViewItem("임시서버");
                    lvi.SubItems.Add(comboBox_maker.SelectedItem.ToString());
                    lvi.SubItems.Add(textBox_IP.Text);
                    
                    m.camera_list.Add(new Camera() { camera_manufacturer = comboBox_maker.SelectedItem.ToString(), camera_IP = textBox_IP.Text, camera_ID = textBox_ID.Text, camera_PW = textBox_PW.Text });

                    //................................................................................///이 아래부터 나중에수정할것들//
                    /////////입력받은 maker, ip, id, pw 로 카메라 검색/ tab 메뉴의 항목에 값 저장&초기값으로 초기화..
                    int tmp = m.camera_list.Count;
                    m.camera_list[tmp - 1].camera_server = "임시서버";
                    m.camera_list[tmp - 1].camera_connect = true;

                    if (m.camera_list[tmp - 1].camera_connect == true)
                        lvi.SubItems.Add("connected");
                    else
                        lvi.SubItems.Add("unconnected");
                    m.listView_device.Items.Add(lvi);           ///리스트 추가
                    ///////////////////////////////Device Setting///////////////////////
                    m.camera_list[tmp - 1].device.enable = true;
                    //m.camera_list[tmp - 1].device.device_name = "임시이름 " + tmp;
                    m.camera_list[tmp - 1].device.device_username = "임시유저 " + tmp;
                    m.camera_list[tmp - 1].device.device_PW = textBox_PW.Text;
                    m.camera_list[tmp - 1].device.device_model = "임시모델 " + tmp;
                    m.camera_list[tmp - 1].device.device_manufacturer = comboBox_maker.SelectedItem.ToString();
                    m.camera_list[tmp - 1].device.device_firmware = "임시firmware " + tmp;
                    m.camera_list[tmp - 1].device.latitude = Convert.ToDouble(textBox_add_latitude.Text);
                    m.camera_list[tmp - 1].device.longitude = Convert.ToDouble(textBox_add_longgitude.Text);

                    m.checkBox_enabled.Checked = m.camera_list[tmp - 1].device.enable;
                    //m.Enabled = m.camera_list[tmp - 1].device.enable;
                    m.textBox_name.Text = m.camera_list[tmp - 1].camera_ID;
                    m.textBox_username.Text = m.camera_list[tmp - 1].device.device_username;
                    m.textBox_password.Text = m.camera_list[tmp - 1].device.device_PW;
                    m.label_dmodel.Text = m.camera_list[tmp - 1].device.device_model;
                    m.label_dmanufacturer.Text = m.camera_list[tmp - 1].device.device_manufacturer;
                    m.label_dfireware.Text = m.camera_list[tmp - 1].device.device_firmware;
                    m.textBox_latitude.Text = m.camera_list[tmp - 1].device.latitude.ToString();
                    m.textBox_longitude.Text = m.camera_list[tmp - 1].device.longitude.ToString();

                    ///////////////////////////////Video Streaming///////////////////////
                    m.camera_list[tmp - 1].video.video_main_resolution = 0;
                    m.camera_list[tmp - 1].video.video_main_framerate = "0" + tmp;
                    m.camera_list[tmp - 1].video.video_main_codec = 0;
                    m.camera_list[tmp - 1].video.video_main_quality = "0" + tmp;
                    m.camera_list[tmp - 1].video.video_main_bitrate = "100" + tmp;
                    m.camera_list[tmp - 1].video.video_sub_resolution = 0;
                    m.camera_list[tmp - 1].video.video_sub_framerate = "0" + tmp;
                    m.camera_list[tmp - 1].video.video_sub_codec = 0;
                    m.camera_list[tmp - 1].video.video_sub_quality = "0" + tmp;
                    m.camera_list[tmp - 1].video.video_sub_bitrate = "100" + tmp;

                    m.comboBox_resolution_main.SelectedIndex = m.camera_list[tmp - 1].video.video_main_resolution;
                    m.textBox_framerate_main.Text = m.camera_list[tmp - 1].video.video_main_framerate;
                    m.comboBox_codec_main.SelectedIndex = m.camera_list[tmp - 1].video.video_main_codec;
                    m.textBox_quality_main.Text = m.camera_list[tmp - 1].video.video_main_quality;
                    m.textBox_bitrate_main.Text = m.camera_list[tmp - 1].video.video_main_bitrate;
                    m.comboBox_resolution_sub.SelectedIndex = m.camera_list[tmp - 1].video.video_sub_resolution;
                    m.textBox_framerate_sub.Text = m.camera_list[tmp - 1].video.video_sub_framerate;
                    m.comboBox_codec_sub.SelectedIndex = m.camera_list[tmp - 1].video.video_sub_codec;
                    m.textBox_quality_sub.Text = m.camera_list[tmp - 1].video.video_sub_quality;
                    m.textBox_bitrate_sub.Text = m.camera_list[tmp - 1].video.video_sub_bitrate;

                    ///////////////////////////////Image Setting///////////////////////
                    m.trackBar_brightness.Value = m.camera_list[tmp - 1].image.image_brightness;
                    m.trackBar_contrast.Value = m.camera_list[tmp - 1].image.image_contrast;
                    m.trackBar_sharpness.Value = m.camera_list[tmp - 1].image.image_sharpness;

                    ///////////////////////////////Network Setting///////////////////////
                    m.camera_list[tmp - 1].network.network_IP = textBox_IP.Text;
                    m.camera_list[tmp - 1].network.network_http = "1" + tmp;
                    m.camera_list[tmp - 1].network.network_https = "2" + tmp;
                    m.camera_list[tmp - 1].network.network_rtsp = "3" + tmp;

                    m.textBox_ip_adress.Text = m.camera_list[tmp - 1].network.network_IP;
                    m.textBox_http_port.Text = m.camera_list[tmp - 1].network.network_http;
                    m.textBox_https_port.Text = m.camera_list[tmp - 1].network.network_https;
                    m.textBox_rtsp_port.Text = m.camera_list[tmp - 1].network.network_rtsp;

                    ///////////////////////////////Archive Setting///////////////////////
                    m.camera_list[tmp - 1].archive.archive_set_storage = 0;
                    m.camera_list[tmp - 1].archive.archive_set_record_period = 0;
                    m.camera_list[tmp - 1].archive.archive_set_record_time = "0" + tmp;
                    m.camera_list[tmp - 1].archive.archive_framerate = "0" + tmp;
                    m.camera_list[tmp - 1].archive.archive_set_record_stream = 0;
                    m.camera_list[tmp - 1].archive.archive_info_name = "임시인포이름";
                    m.camera_list[tmp - 1].archive.archive_info_type = "임시이름타입" + tmp;
                    m.camera_list[tmp - 1].archive.archive_info_total = "0" + tmp;
                    m.camera_list[tmp - 1].archive.archive_info_free = "0" + tmp;

                    m.comboBox_storage.SelectedIndex = m.camera_list[tmp - 1].archive.archive_set_storage;
                    m.comboBox_record_period.SelectedIndex = m.camera_list[tmp - 1].archive.archive_set_record_period;
                    m.textBox_record_time.Text = m.camera_list[tmp - 1].archive.archive_set_record_time;
                    m.textBox_quality_main.Text = m.camera_list[tmp - 1].archive.archive_framerate;
                    m.textBox_framerate.Text = m.camera_list[tmp - 1].archive.archive_framerate;
                    m.comboBox_record_stream.SelectedIndex = m.camera_list[tmp - 1].archive.archive_set_record_stream;
                    m.label_archive_name.Text = m.camera_list[tmp - 1].archive.archive_info_name;
                    m.label_archive_type.Text = m.camera_list[tmp - 1].archive.archive_info_type;
                    m.label_archive_total.Text = m.camera_list[tmp - 1].archive.archive_info_total;
                    m.label_archive_free.Text = m.camera_list[tmp - 1].archive.archive_info_free;
                    ///////////////////////////////Event Setting///////////////////////
                    m.tabcontrol_menu.SelectedTab = m.tabPage_device;
                    ///////////////////////////////Webpage///////////////////////
                    //m.webBrowser.Navigate(m.textBox_ip_adress.Text);
                    /////xml 파일 저장///

                    m.x.item.Add(m.camera_list[tmp - 1]);
                    m.M.serialize(m.x);
                    m.didyouclicklist = false;
                    Form_Notification check = new Form_Notification();
                    check.Owner = this;
                    check.Show();
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_IP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.ipset(sender, e, textBox_IP);
        }

        private void textBox_add_latitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.check_effectiveness(sender, e, textBox_add_latitude);
        }

        private void textBox_add_longgitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.check_effectiveness(sender, e, textBox_add_longgitude);
        }
    }
}
