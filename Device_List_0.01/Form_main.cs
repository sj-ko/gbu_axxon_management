﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
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

        //////////////////////////////
        public Form_main()
        {
            InitializeComponent();

            listView_device.View = View.Details;
            listView_device.BeginUpdate();
            listView_device.Columns.Add("서버");
            listView_device.Columns.Add("제조사");
            listView_device.Columns.Add("IP");
            listView_device.Columns.Add("연결상태");
            
            //////////////////////////////
            if(System.IO.File.Exists("Emp.xml"))
            try
            {
                XmlDocument xdoc = new XmlDocument();
                // XML 데이타를 파일에서 로드
                xdoc.Load(@"C:\Users\qwer\Documents\Visual Studio 2017\Projects\Device_List_0.01\Device_List_0.01\bin\Debug/Emp.xml");
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
                for (int i=0;i<tmp; i++)
                {
                    string pw = "";
                    for (int j = 0; j<camera_list[i].camera_PW.Length; j++)
                        pw = pw + "*";

                    ListViewItem lvi = new ListViewItem("임시서버");
                    lvi.SubItems.Add(camera_list[i].camera_manufacturer);
                    lvi.SubItems.Add(camera_list[i].camera_IP);
                    lvi.SubItems.Add("connected");
                    listView_device.Items.Add(lvi);
                    
                    x.item.Add(camera_list[i]);
                    M.serialize(x);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\r\n" + ex);
            }
        }
        private void button_listview_collection_Click(object sender, EventArgs e)
        {
            Form_list li = new Form_list();
            li.Owner = this;
            li.Show();
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            Form_add add = new Form_add();
            add.Owner = this;
            add.Show();
        }
        private void button_refresh_Click(object sender, EventArgs e)
        {

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
                ///////////////////////////////Device Setting///////////////////////
                checkBox_enabled.Checked = false;
                textBox_name.Text = "";
                textBox_username.Text = "";
                textBox_password.Text = "";
                label_dmodel.Text = "";
                label_dmanufacturer.Text = "";
                label_dfireware.Text = "";

                ///////////////////////////////Video Streaming///////////////////////
                comboBox_resolution_main.SelectedIndex = -1;
                textBox_framerate_main.Text = "";
                comboBox_codec_main.SelectedIndex = -1;
                textBox_quality_main.Text = "";
                textBox_bitrate_main.Text = "";
                comboBox_resolution_sub.SelectedIndex = -1;
                textBox_framerate_sub.Text = "";
                comboBox_codec_sub.SelectedIndex = -1;
                textBox_quality_sub.Text = "";
                textBox_bitrate_sub.Text = "";

                ///////////////////////////////Image Setting///////////////////////
                trackBar_brightness.Value = 50;
                trackBar_contrast.Value = 50;
                trackBar_sharpness.Value = 50;
                ///////////////////////////////Network Setting///////////////////////
                textBox_ip_adress.Text = "";
                textBox_http_port.Text = "";
                textBox_https_port.Text = "";
                textBox_rtsp_port.Text = "";
                ///////////////////////////////Archive Setting///////////////////////
                comboBox_storage.SelectedIndex = -1;
                comboBox_record_period.SelectedIndex = -1;
                textBox_record_time.Text = "";
                textBox_quality_main.Text = "";
                textBox_framerate.Text = "";
                comboBox_record_stream.SelectedIndex = -1;
                label_archive_name.Text = "";
                label_archive_type.Text = "";
                label_archive_total.Text = "";
                label_archive_free.Text = "";
                ///////////////////////////////Event Setting///////////////////////

                ///////////////////////////////Webpage///////////////////////

                didyouclicklist=false;
            }
        }
        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        private void listView_device_Click(object sender, EventArgs e)      //리스트 아이템 클릭시 tab 속성들 변경
        {
            didyouclicklist = true;
           
            int tmp = 0;
            if (listView_device.FocusedItem != null)
                tmp = listView_device.FocusedItem.Index;
            tabcontrol_menu.SelectedTab = tabPage_device;

            if (camera_list[tmp].camera_connect == false)
                tabcontrol_menu.Enabled = false;
            else
                tabcontrol_menu.Enabled = true;

            ////////Device Setting/////
            checkBox_enabled.Checked = camera_list[tmp].device.enable;
            textBox_name.Text = camera_list[tmp].device.device_name;
            textBox_username.Text = camera_list[tmp].device.device_username;
            textBox_password.Text = camera_list[tmp].device.device_PW;
            label_dmodel.Text = camera_list[tmp].device.device_model;
            label_dmanufacturer.Text = camera_list[tmp].device.device_manufacturer;
            label_dfireware.Text = camera_list[tmp].device.device_firmware;

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
            textBox_ip_adress.Text = camera_list[tmp].network.network_IP;
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
        }
        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<Device Setting>//////////
        private void button_device_modify_Click(object sender, EventArgs e)
        {
            if (didyouclicklist == false)
                MessageBox.Show("우선 카메라를 선택해주세요");
            else
            {
                if (textBox_password.Text.Length < 1 || textBox_name.Text.Length < 1 || textBox_username.Text.Length < 1)
                {
                    MessageBox.Show("모든 항목을 입력해주세요.");
                }
                else
                {
                    int tmp = 0;
                    if (listView_device.FocusedItem != null)
                        tmp = listView_device.FocusedItem.Index;
                    string pw = "";
                    for (int i = 0; i < textBox_password.TextLength; i++)
                        pw = pw + "*";
                    camera_list[tmp].camera_PW = textBox_password.Text;
                    camera_list[tmp].device.enable = checkBox_enabled.Checked;
                    camera_list[tmp].device.device_name = textBox_name.Text;
                    camera_list[tmp].device.device_username = textBox_username.Text;
                    camera_list[tmp].device.device_PW = textBox_password.Text;
                    listView_device.Items[tmp].SubItems[3].Text = pw;

                    x.item.RemoveAt(tmp);
                    x.item.Insert(tmp, camera_list[tmp]);
                    M.serialize(x);
                }
            }
        }

        private void button_device_cancel_Click(object sender, EventArgs e)
        {
            if (didyouclicklist == false)
                MessageBox.Show("우선 카메라를 선택해주세요");
            else
            {
                int tmp = 0;
                if (listView_device.FocusedItem != null)
                    tmp = listView_device.FocusedItem.Index;

                checkBox_enabled.Checked = camera_list[tmp].device.enable;
                textBox_name.Text = camera_list[tmp].device.device_name;
                textBox_username.Text = camera_list[tmp].device.device_username;
                textBox_password.Text = camera_list[tmp].device.device_PW;
            }
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
            if (didyouclicklist == false)
                MessageBox.Show("우선 카메라를 선택해주세요");
            else
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
                        tmp = listView_device.FocusedItem.Index;
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
        }

        private void button_video_cancel_Click(object sender, EventArgs e)
        {
            if (didyouclicklist == false)
                MessageBox.Show("우선 카메라를 선택해주세요");
            else
            {
                int tmp = 0;
                if (listView_device.FocusedItem != null)
                    tmp = listView_device.FocusedItem.Index;
                
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
        }
        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<Image Setting>///////////
        private void button_image_modify_Click(object sender, EventArgs e)
        {
            if (didyouclicklist == false)
                MessageBox.Show("우선 카메라를 선택해주세요");
            else
            {
                int tmp = 0;
                if (listView_device.FocusedItem != null)
                    tmp = listView_device.FocusedItem.Index;

                camera_list[tmp].image.image_brightness = trackBar_brightness.Value;
                camera_list[tmp].image.image_contrast = trackBar_contrast.Value;
                camera_list[tmp].image.image_sharpness = trackBar_sharpness.Value;
                M.serialize(x);
            }
        }

        private void button_image_cancel_Click(object sender, EventArgs e)
        {
            if (didyouclicklist == false)
                MessageBox.Show("우선 카메라를 선택해주세요");
            else
            {
                int tmp = 0;
                if (listView_device.FocusedItem != null)
                    tmp = listView_device.FocusedItem.Index;

                trackBar_brightness.Value = camera_list[tmp].image.image_brightness;
                trackBar_contrast.Value = camera_list[tmp].image.image_contrast;
                trackBar_sharpness.Value = camera_list[tmp].image.image_sharpness;
            }
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<Network Setting>///////////
        private void textBox_ip_adress_KeyPress(object sender, KeyPressEventArgs e)
        {
            Range r = new Range();
            r.ipset(sender, e, textBox_ip_adress);
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
            if (didyouclicklist == false)
                MessageBox.Show("우선 카메라를 선택해주세요");
            else
            {
                if (textBox_ip_adress.Text.Length < 1 || textBox_http_port.Text.Length < 1 || textBox_https_port.Text.Length < 1 || textBox_rtsp_port.Text.Length < 1)
                {
                    MessageBox.Show("모든 항목을 입력해주세요.");
                }
                else
                {
                    int tmp = 0;
                    if (listView_device.FocusedItem != null)
                        tmp = listView_device.FocusedItem.Index;

                    camera_list[tmp].camera_IP = textBox_ip_adress.Text;
                    camera_list[tmp].network.network_IP = textBox_ip_adress.Text;
                    camera_list[tmp].network.network_http = textBox_http_port.Text;
                    camera_list[tmp].network.network_https = textBox_https_port.Text;
                    camera_list[tmp].network.network_rtsp = textBox_rtsp_port.Text;

                    listView_device.Items[tmp].SubItems[1].Text = textBox_ip_adress.Text;

                    x.item.RemoveAt(tmp);
                    x.item.Insert(tmp, camera_list[tmp]);
                    M.serialize(x);
                }
            }
        }

        private void button7_network_cancel_Click(object sender, EventArgs e)
        {
            if (didyouclicklist == false)
                MessageBox.Show("우선 카메라를 선택해주세요");
            else
            {
                int tmp = 0;
                if (listView_device.FocusedItem != null)
                    tmp = listView_device.FocusedItem.Index;

                textBox_ip_adress.Text = camera_list[tmp].network.network_IP;
                textBox_http_port.Text = camera_list[tmp].network.network_http;
                textBox_https_port.Text = camera_list[tmp].network.network_https;
                textBox_rtsp_port.Text = camera_list[tmp].network.network_rtsp;
            }
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
            if (didyouclicklist == false)
                MessageBox.Show("우선 카메라를 선택해주세요");
            else
            {
                if (textBox_record_time.Text.Length < 1 || textBox_framerate.Text.Length < 1)
                {
                    MessageBox.Show("모든 항목을 입력해주세요.");
                }
                else
                {
                    int tmp = 0;
                    if (listView_device.FocusedItem != null)
                        tmp = listView_device.FocusedItem.Index;

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
        }

        private void button_archive_cancel_Click(object sender, EventArgs e)
        {
            if (didyouclicklist == false)
                MessageBox.Show("우선 카메라를 선택해주세요");
            else
            {
                int tmp = 0;
                if (listView_device.FocusedItem != null)
                    tmp = listView_device.FocusedItem.Index;

                comboBox_storage.SelectedIndex = camera_list[tmp].archive.archive_set_storage;
                comboBox_record_period.SelectedIndex = camera_list[tmp].archive.archive_set_record_period;
                textBox_record_time.Text = camera_list[tmp].archive.archive_set_record_time;
                textBox_framerate.Text = camera_list[tmp].archive.archive_framerate;
                comboBox_record_stream.SelectedIndex = camera_list[tmp].archive.archive_set_record_stream;
            }
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
                tmp = listView_device.FocusedItem.Index;
            if(didyouclicklist==true)
               webBrowser.Navigate(camera_list[tmp].network.network_IP);
            
        }
    }
}
