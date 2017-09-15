using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Device_List_0._01
{
    public partial class Form_main : Form
    {
        public List<Camera> camera_list = new List<Camera>();
        public Xmlclass x = new Xmlclass();
        public Xmlclass dexml = new Xmlclass();
        public management M = new management();
        public bool didyouclicklist = false;
        public bool treadgo = true;
        //////////////////////////////
        public Form_main()
        {
            InitializeComponent();

            listView_device.View = View.Details;
            listView_device.BeginUpdate();
            listView_device.Columns.Add("서버");
            listView_device.Columns.Add("카메라 ID");
            listView_device.Columns.Add("카메라 이름");
            listView_device.Columns.Add("연결상태");

            //////////////////////////////
            if (System.IO.File.Exists("Emp.xml"))
            {
                try
                {
                    XmlDocument xdoc = new XmlDocument();
                    // XML 데이타를 파일에서 로드
                    xdoc.Load("Emp.xml");
                    XmlElement root = xdoc.DocumentElement;
                    // 노드 요소들
                    XmlNodeList nodes = root.SelectNodes("/Xmlclass/item/Camera");
                    ///////////////deserialize////////////////////
                    using (StreamReader rd = new StreamReader("Emp.xml"))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(Xmlclass));
                        dexml = (Xmlclass)xs.Deserialize(rd);
                        rd.Close();
                    }
                    camera_list.AddRange(dexml.item);

                    int tmp = camera_list.Count;
                    for (int i = 0; i < tmp; i++)
                    {
                        ListViewItem lvi = new ListViewItem(camera_list[i].camera_server);
                        lvi.SubItems.Add(camera_list[i].camera_ID);
                        lvi.SubItems.Add(camera_list[i].camera_name);
                        if (camera_list[tmp - 1].camera_connect == "connected" || camera_list[tmp - 1].camera_connect == "signal_restored")
                        {
                            lvi.SubItems.Add("connected");
                        }
                        else
                        {
                            lvi.SubItems.Add("unconnected");
                        }
                        listView_device.Items.Add(lvi);

                        x.item.Add(camera_list[i]);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("XML 문제 발생\r\n" + ex);
                }
            }
            tabcontrol_menu.Enabled = false; // this disables the controls on it
            tabcontrol_menu.Visible = false; // this hides the controls on it.
        }

        private void button_listview_collection_Click(object sender, EventArgs e)
        {
            Form_list li = new Form_list();
            li.Owner = this;
            li.Show();
            treadgo = true;
            Thread thread1 = new Thread(new ThreadStart(StartThread));
            thread1.Start();
        }

        private void StartThread()
        {
            while (treadgo)
            {
                listView_device.Invoke(new MethodInvoker(refresh));
                Thread.Sleep(5000);
            }
        }

        private void refresh()
        {
            camera_list.Clear();
            listView_device.Items.Clear();
            ///////////////////////////////////카메라 받아오는 코드 테스트/////////////
            management server = new management();
            List<json_camera> J = new List<json_camera>();
            string json = server.Request_Json();
            J = server.ParseJson(json);

            for (int i = 0; i < J.Count; i++)
            {
                camera_list.Add(new Camera() { camera_server = J[i].Server, camera_ID = J[i].JCamera_id, camera_name = J[i].FriendlyNameLong, camera_connect = J[i].State, video_url=J[i].video_url });
            }

            int tmp = camera_list.Count;
            Xmlclass re = new Xmlclass();               //
            for (int i = 0; i < tmp; i++)
            {
                ListViewItem lvi = new ListViewItem(camera_list[i].camera_server);
                lvi.SubItems.Add(camera_list[i].camera_ID);
                lvi.SubItems.Add(camera_list[i].camera_name);
                if (camera_list[i].camera_connect == "connected" || camera_list[i].camera_connect == "signal_restored")
                {
                    lvi.SubItems.Add("connected");
                }
                else
                {
                    lvi.SubItems.Add("unconnected");
                }
                listView_device.Items.Add(lvi);

                re.item.Add(camera_list[i]);
            }
            M.serialize(re);
            x = re;
            tabcontrol_menu.Enabled = false; // this disables the controls on it
            tabcontrol_menu.Visible = false; // this hides the controls on it.
            didyouclicklist = false;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            Form_add add = new Form_add();
            add.Owner = this;
            add.Show();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (didyouclicklist == true)
            {
                tabcontrol_menu.SelectedTab = tabPage_device;
                if (listView_device.FocusedItem != null)
                {
                    camera_list.RemoveAt(listView_device.Items[listView_device.FocusedItem.Index].Index);
                    x.item.RemoveAt(listView_device.Items[listView_device.FocusedItem.Index].Index);
                    listView_device.Items.Remove(listView_device.FocusedItem);

                    M.serialize(x);
                }
                tabcontrol_menu.Enabled = false; // this disables the controls on it
                tabcontrol_menu.Visible = false; // this hides the controls on it.
                didyouclicklist =false;
            }
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        private void listView_device_Click(object sender, EventArgs e)      //리스트 아이템 클릭시 tab 속성들 변경
        {
            treadgo = false;
            didyouclicklist = true;
            tabcontrol_menu.Enabled = true; // this disables the controls on it
            tabcontrol_menu.Visible = true; // this hides the controls on it.

            int tmp = 0;
            if (listView_device.FocusedItem != null)
            {
                tmp = listView_device.FocusedItem.Index;
            }
            tabcontrol_menu.SelectedTab = tabPage_device;

            if (camera_list[tmp].camera_connect == "connected" || camera_list[tmp].camera_connect == "signal_restored")
            {
                tabcontrol_menu.Enabled = true;
            }
            else
            {
                tabcontrol_menu.Enabled = false;
            }

            ////////Device Setting/////
            checkBox_enabled.Checked = camera_list[tmp].device.enable;
            textBox_name.Text = camera_list[tmp].camera_name;
            textBox_username.Text = camera_list[tmp].username;
            textBox_password.Text = camera_list[tmp].user_PW;
            label_dmodel.Text = camera_list[tmp].device.device_model;
            label_dmanufacturer.Text = camera_list[tmp].device.device_manufacturer;
            label_dfireware.Text = camera_list[tmp].device.device_firmware;
            textBox_latitude.Text = camera_list[tmp].device.latitude.ToString();
            textBox_longitude.Text = camera_list[tmp].device.longitude.ToString();

            ////////Video Setting/////
            comboBox_resolution_main.SelectedIndex = camera_list[tmp].video.video_main_resolution;
            textBox_framerate_main.Text = camera_list[tmp].video.video_main_framerate;
            comboBox_codec_main.SelectedIndex = camera_list[tmp].video.video_main_codec;
            textBox_quality_main.Text = camera_list[tmp].video.video_main_quality;
            textBox_bitrate_main.Text = camera_list[tmp].video.video_main_bitrate;
            comboBox_resolution_sub.SelectedIndex = camera_list[tmp].video.video_sub_resolution;
            textBox_framerate_sub.Text = camera_list[tmp].video.video_sub_framerate;
            comboBox_codec_sub.SelectedIndex = camera_list[tmp].video.video_sub_codec;
            textBox_quality_sub.Text = camera_list[tmp].video.video_sub_quality;
            textBox_bitrate_sub.Text = camera_list[tmp].video.video_sub_bitrate;

            ////////Image Setting/////
            trackBar_brightness.Value = camera_list[tmp].image.image_brightness;
            trackBar_contrast.Value = camera_list[tmp].image.image_contrast;
            trackBar_sharpness.Value = camera_list[tmp].image.image_sharpness;

            ////////Network Setting/////
            textBox_ip_address.Text = camera_list[tmp].network.network_IP;
            textBox_http_port.Text = camera_list[tmp].network.network_http;
            textBox_https_port.Text = camera_list[tmp].network.network_https;
            textBox_rtsp_port.Text = camera_list[tmp].network.network_rtsp;

            ////////Archive Setting/////
            comboBox_storage.SelectedIndex = camera_list[tmp].archive.archive_set_storage;
            comboBox_record_period.SelectedIndex = camera_list[tmp].archive.archive_set_record_period;
            textBox_record_time.Text = camera_list[tmp].archive.archive_set_record_time;
            textBox_framerate.Text = camera_list[tmp].archive.archive_framerate;
            comboBox_record_stream.SelectedIndex = camera_list[tmp].archive.archive_set_record_stream;
            label_archive_name.Text = camera_list[tmp].archive.archive_info_name;
            label_archive_type.Text = camera_list[tmp].archive.archive_info_type;
            label_archive_total.Text = camera_list[tmp].archive.archive_info_total;
            label_archive_free.Text = camera_list[tmp].archive.archive_info_free;

            ////////Event Setting/////

            ////////webpage/////
            //webBrowser.Navigate(textBox_ip_adress.Text);

            axWindowsMediaPlayer.URL = camera_list[tmp].video_url;
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<Device Setting>//////////
        private void textBox_latitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.check_effectiveness(sender, e, textBox_latitude);
        }

        private void textBox_longitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.check_effectiveness(sender, e, textBox_longitude);
        }

        private void button_device_modify_Click(object sender, EventArgs e)
        {
            if (textBox_password.Text.Length < 1 || textBox_name.Text.Length < 1 || textBox_username.Text.Length < 1 ||
                textBox_latitude.Text.Length < 1 || textBox_longitude.Text.Length < 1)
            {
                MessageBox.Show("모든 항목을 입력해주세요.");
            }
            else
            {
                int tmp = 0;
                if (listView_device.FocusedItem != null)
                {
                    tmp = listView_device.FocusedItem.Index;
                }

                Range r = new Range();
                r.rangeset_ver2(textBox_latitude, -90, 90);
                r.rangeset_ver2(textBox_longitude, -180, 180);
                if (!(textBox_latitude.Text == "") && !(textBox_longitude.Text == ""))
                {
                    camera_list[tmp].device.enable = checkBox_enabled.Checked;
                    camera_list[tmp].camera_name = textBox_name.Text;
                    camera_list[tmp].username = textBox_username.Text;
                    camera_list[tmp].user_PW = textBox_password.Text;
                    camera_list[tmp].device.latitude = Convert.ToDouble(textBox_latitude.Text);
                    camera_list[tmp].device.longitude = Convert.ToDouble(textBox_longitude.Text);

                    listView_device.Items[tmp].SubItems[2].Text = textBox_name.Text;

                    x.item.RemoveAt(tmp);
                    x.item.Insert(tmp, camera_list[tmp]);
                    M.serialize(x);
                }
            }
        }

        private void button_device_cancel_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
            {
                tmp = listView_device.FocusedItem.Index;
            }

            checkBox_enabled.Checked = camera_list[tmp].device.enable;
            textBox_name.Text = camera_list[tmp].camera_name;
            textBox_username.Text = camera_list[tmp].username;
            textBox_password.Text = camera_list[tmp].user_PW;
            textBox_latitude.Text = camera_list[tmp].device.latitude.ToString();
            textBox_longitude.Text = camera_list[tmp].device.longitude.ToString();
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<Video Streaming>////////////
        private void textBox_framerate_main_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_framerate_main, 1, 60);
        }

        private void textBox_quality_main_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_quality_main, 1, 10);
        }

        private void textBox_bitrate_main_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_bitrate_main, 100, 10000);
        }

        private void textBox_framerate_sub_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_framerate_sub, 1, 60);
        }

        private void textBox_quality_sub_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_quality_sub, 1, 10);
        }

        private void textBox_bitrate_sub_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_bitrate_sub, 100, 10000);
        }

        private void button_video_modify_Click(object sender, EventArgs e)
        {
            if (textBox_framerate_main.Text.Length < 1 || textBox_quality_main.Text.Length < 1 || textBox_bitrate_main.Text.Length < 1 ||
                    textBox_framerate_sub.Text.Length < 1 || textBox_quality_sub.Text.Length < 1 || textBox_bitrate_sub.Text.Length < 1)
            {
                MessageBox.Show("모든 항목을 입력해주세요.");
            }
            else
            {
                int tmp = 0;
                if (listView_device.FocusedItem != null)
                {
                    tmp = listView_device.FocusedItem.Index;
                }
                camera_list[tmp].video.video_main_resolution = comboBox_resolution_main.SelectedIndex;
                camera_list[tmp].video.video_main_framerate = textBox_framerate_main.Text;
                camera_list[tmp].video.video_main_codec = comboBox_codec_main.SelectedIndex;
                camera_list[tmp].video.video_main_quality = textBox_quality_main.Text;
                camera_list[tmp].video.video_main_bitrate = textBox_bitrate_main.Text;

                camera_list[tmp].video.video_sub_resolution = comboBox_resolution_sub.SelectedIndex;
                camera_list[tmp].video.video_sub_framerate = textBox_framerate_sub.Text;
                camera_list[tmp].video.video_sub_codec = comboBox_codec_sub.SelectedIndex;
                camera_list[tmp].video.video_sub_quality = textBox_quality_sub.Text;
                camera_list[tmp].video.video_sub_bitrate = textBox_bitrate_sub.Text;
               
                x.item.RemoveAt(tmp);
                x.item.Insert(tmp, camera_list[tmp]);
                M.serialize(x);
            }
        }

        private void button_video_cancel_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
            {
                tmp = listView_device.FocusedItem.Index;
            }

            comboBox_resolution_main.SelectedIndex = camera_list[tmp].video.video_main_resolution;
            textBox_framerate_main.Text = camera_list[tmp].video.video_main_framerate;
            comboBox_codec_main.SelectedIndex = camera_list[tmp].video.video_main_codec;
            textBox_quality_main.Text = camera_list[tmp].video.video_main_quality;
            textBox_bitrate_main.Text = camera_list[tmp].video.video_main_bitrate;

            comboBox_resolution_sub.SelectedIndex = camera_list[tmp].video.video_sub_resolution;
            textBox_framerate_sub.Text = camera_list[tmp].video.video_sub_framerate;
            comboBox_codec_sub.SelectedIndex = camera_list[tmp].video.video_sub_codec;
            textBox_quality_sub.Text = camera_list[tmp].video.video_sub_quality;
            textBox_bitrate_sub.Text = camera_list[tmp].video.video_sub_bitrate;
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<Image Setting>///////////
        private void button_image_modify_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
            {
                tmp = listView_device.FocusedItem.Index;
            }

            camera_list[tmp].image.image_brightness = trackBar_brightness.Value;
            camera_list[tmp].image.image_contrast = trackBar_contrast.Value;
            camera_list[tmp].image.image_sharpness = trackBar_sharpness.Value;
            M.serialize(x);
        }

        private void button_image_cancel_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
            {
                tmp = listView_device.FocusedItem.Index;
            }

            trackBar_brightness.Value = camera_list[tmp].image.image_brightness;
            trackBar_contrast.Value = camera_list[tmp].image.image_contrast;
            trackBar_sharpness.Value = camera_list[tmp].image.image_sharpness;
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<Network Setting>///////////
        private void textBox_ip_adress_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.ipset(sender, e, textBox_ip_address);
        }

        private void textBox_http_port_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_http_port, 0, 65535);
        }

        private void textBox_https_port_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_https_port, 0, 65535);
        }

        private void textBox_rtsp_port_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_rtsp_port, 0, 65535);
        }

        private void button_network_modify_Click(object sender, EventArgs e)
        {
            if (textBox_ip_address.Text.Length < 1 || textBox_http_port.Text.Length < 1 || textBox_https_port.Text.Length < 1 ||
                    textBox_rtsp_port.Text.Length < 1 )
            {
                MessageBox.Show("모든 항목을 입력해주세요.");
            }
            else
            {
                int tmp = 0;
                if (listView_device.FocusedItem != null)
                    tmp = listView_device.FocusedItem.Index;

                //camera_list[tmp].camera_IP = textBox_ip_adress.Text;
                camera_list[tmp].network.network_IP = textBox_ip_address.Text;
                camera_list[tmp].network.network_http = textBox_http_port.Text;
                camera_list[tmp].network.network_https = textBox_https_port.Text;
                camera_list[tmp].network.network_rtsp = textBox_rtsp_port.Text;
                
                x.item.RemoveAt(tmp);
                x.item.Insert(tmp, camera_list[tmp]);
                M.serialize(x);
            }
        }

        private void button7_network_cancel_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
            {
                tmp = listView_device.FocusedItem.Index;
            }

            textBox_ip_address.Text = camera_list[tmp].network.network_IP;
            textBox_http_port.Text = camera_list[tmp].network.network_http;
            textBox_https_port.Text = camera_list[tmp].network.network_https;
            textBox_rtsp_port.Text = camera_list[tmp].network.network_rtsp;
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<Archive Setting>////////
        private void textBox_record_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_record_time, 0, 10);
        }

        private void textBox_framerate_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_framerate, 1, 60);
        }

        private void button_archive_modify_Click(object sender, EventArgs e)
        {
            if (textBox_record_time.Text.Length < 1 || textBox_framerate.Text.Length < 1)
            {
                MessageBox.Show("모든 항목을 입력해주세요.");
            }
            else
            {
                int tmp = 0;
                if (listView_device.FocusedItem != null)
                {
                    tmp = listView_device.FocusedItem.Index;
                }

                camera_list[tmp].archive.archive_set_storage = comboBox_storage.SelectedIndex;
                camera_list[tmp].archive.archive_set_record_period = comboBox_record_period.SelectedIndex;
                camera_list[tmp].archive.archive_set_record_time = textBox_record_time.Text;
                camera_list[tmp].archive.archive_framerate = textBox_framerate.Text;
                camera_list[tmp].archive.archive_set_record_stream = comboBox_record_stream.SelectedIndex;

                x.item.RemoveAt(tmp);
                x.item.Insert(tmp, camera_list[tmp]);
                M.serialize(x);
            }
        }

        private void button_archive_cancel_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
            {
                tmp = listView_device.FocusedItem.Index;
            }

            comboBox_storage.SelectedIndex = camera_list[tmp].archive.archive_set_storage;
            comboBox_record_period.SelectedIndex = camera_list[tmp].archive.archive_set_record_period;
            textBox_record_time.Text = camera_list[tmp].archive.archive_set_record_time;
            textBox_framerate.Text = camera_list[tmp].archive.archive_framerate;
            comboBox_record_stream.SelectedIndex = camera_list[tmp].archive.archive_set_record_stream;
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<Event Setting>////////
        private void textBox_sensitivity_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_sensitivity, 1, 100);
        }

        private void textBox_minimux_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_minimux, 1, 100);
        }

        private void textBox_maximum_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.rangeset(sender, e, textBox_maximum, 1, 100);
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<webpage>////////
        private void groupBox_webpage_VisibleChanged(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
            {
                tmp = listView_device.FocusedItem.Index;
            }
            if (didyouclicklist == true)
            {
                webBrowser.Navigate(camera_list[tmp].network.network_IP);
            }
        }

        private void listView_device_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                didyouclicklist = true;
                tabcontrol_menu.Enabled = true; // this disables the controls on it
                tabcontrol_menu.Visible = true; // this hides the controls on it.

                int tmp = 0;
                if (listView_device.FocusedItem != null)
                {
                    tmp = listView_device.FocusedItem.Index;
                }
                tabcontrol_menu.SelectedTab = tabPage_device;

                if (camera_list[tmp].camera_connect == "connected" || camera_list[tmp].camera_connect == "signal_restored")
                {
                    tabcontrol_menu.Enabled = true;
                }
                else
                {
                    tabcontrol_menu.Enabled = false;
                }

                ////////Device Setting/////
                checkBox_enabled.Checked = camera_list[tmp].device.enable;
                textBox_name.Text = camera_list[tmp].camera_name;
                textBox_username.Text = camera_list[tmp].username;
                textBox_password.Text = camera_list[tmp].user_PW;
                label_dmodel.Text = camera_list[tmp].device.device_model;
                label_dmanufacturer.Text = camera_list[tmp].device.device_manufacturer;
                label_dfireware.Text = camera_list[tmp].device.device_firmware;
                textBox_latitude.Text = camera_list[tmp].device.latitude.ToString();
                textBox_longitude.Text = camera_list[tmp].device.longitude.ToString();

                ////////Video Setting/////
                comboBox_resolution_main.SelectedIndex = camera_list[tmp].video.video_main_resolution;
                textBox_framerate_main.Text = camera_list[tmp].video.video_main_framerate;
                comboBox_codec_main.SelectedIndex = camera_list[tmp].video.video_main_codec;
                textBox_quality_main.Text = camera_list[tmp].video.video_main_quality;
                textBox_bitrate_main.Text = camera_list[tmp].video.video_main_bitrate;
                comboBox_resolution_sub.SelectedIndex = camera_list[tmp].video.video_sub_resolution;
                textBox_framerate_sub.Text = camera_list[tmp].video.video_sub_framerate;
                comboBox_codec_sub.SelectedIndex = camera_list[tmp].video.video_sub_codec;
                textBox_quality_sub.Text = camera_list[tmp].video.video_sub_quality;
                textBox_bitrate_sub.Text = camera_list[tmp].video.video_sub_bitrate;

                ////////Image Setting/////
                trackBar_brightness.Value = camera_list[tmp].image.image_brightness;
                trackBar_contrast.Value = camera_list[tmp].image.image_contrast;
                trackBar_sharpness.Value = camera_list[tmp].image.image_sharpness;

                ////////Network Setting/////
                textBox_ip_address.Text = camera_list[tmp].network.network_IP;
                textBox_http_port.Text = camera_list[tmp].network.network_http;
                textBox_https_port.Text = camera_list[tmp].network.network_https;
                textBox_rtsp_port.Text = camera_list[tmp].network.network_rtsp;

                ////////Archive Setting/////
                comboBox_storage.SelectedIndex = camera_list[tmp].archive.archive_set_storage;
                comboBox_record_period.SelectedIndex = camera_list[tmp].archive.archive_set_record_period;
                textBox_record_time.Text = camera_list[tmp].archive.archive_set_record_time;
                textBox_framerate.Text = camera_list[tmp].archive.archive_framerate;
                comboBox_record_stream.SelectedIndex = camera_list[tmp].archive.archive_set_record_stream;
                label_archive_name.Text = camera_list[tmp].archive.archive_info_name;
                label_archive_type.Text = camera_list[tmp].archive.archive_info_type;
                label_archive_total.Text = camera_list[tmp].archive.archive_info_total;
                label_archive_free.Text = camera_list[tmp].archive.archive_info_free;

                ////////Event Setting/////

                ////////webpage/////
                //webBrowser.Navigate(textBox_ip_adress.Text);
                axWindowsMediaPlayer.URL = camera_list[tmp].video_url;
            }
        }
    }
}

