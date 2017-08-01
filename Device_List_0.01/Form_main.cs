using System;
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
        //public KeyEventArgs p;
        /////for button_image/////
        private int brightness;
        private int contrast;
        private int sharpness;
        //////////////////////////////
        public Form_main()
        {
            InitializeComponent();

            listView_device.View = View.Details;
            listView_device.BeginUpdate();

            listView_device.Columns.Add("제조사");
            listView_device.Columns.Add("IP");
            listView_device.Columns.Add("ID");
            listView_device.Columns.Add("PW");

            /////for button_image/////
            brightness = trackBar_brightness.Value;
            contrast = trackBar_contrast.Value;
            sharpness = trackBar_sharpness.Value;
            //////////////////////////////
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
                for(int i=0;i<tmp; i++)
                {
                    string pw = "";
                    for (int j = 0; j<camera_list[i].camera_PW.Length; j++)
                        pw = pw + "*";

                    ListViewItem lvi = new ListViewItem(camera_list[i].camera_manufacturer);
                    lvi.SubItems.Add(camera_list[i].camera_IP);
                    lvi.SubItems.Add(camera_list[i].camera_ID);
                    lvi.SubItems.Add(pw);
                    listView_device.Items.Add(lvi);
                    ///////////////////////////////Device Setting///////////////////////
                    checkBox_enabled.Checked = camera_list[i].device.enable;
                    Enabled = camera_list[i].device.enable;
                    textBox_name.Text = camera_list[i].device.device_name;
                    textBox_username.Text = camera_list[i].device.device_username;
                    textBox_password.Text = camera_list[i].device.device_PW;
                    label_dmodel.Text = camera_list[i].device.device_model;
                    label_dmanufacturer.Text = camera_list[i].device.device_manufacturer;
                    label_dfireware.Text = camera_list[i].device.device_firmware;

                    ///////////////////////////////Video Streaming///////////////////////
                    comboBox_resolution_main.SelectedIndex = camera_list[i].video.video_main_resolution;
                    textBox_framerate_main.Text = camera_list[i].video.video_main_framerate;
                    comboBox_codec_main.SelectedIndex = camera_list[i].video.video_main_codec;
                    textBox_quality_main.Text = camera_list[i].video.video_main_quality;
                    textBox_bitrate_main.Text = camera_list[i].video.video_main_bitrate;
                    comboBox_resolution_sub.SelectedIndex = camera_list[i].video.video_sub_resolution;
                    textBox_framerate_sub.Text = camera_list[i].video.video_sub_framerate;
                    comboBox_codec_sub.SelectedIndex = camera_list[i].video.video_sub_codec;
                    textBox_quality_sub.Text = camera_list[i].video.video_sub_quality;
                    textBox_bitrate_sub.Text = camera_list[i].video.video_sub_bitrate;

                    ///////////////////////////////Image Setting///////////////////////

                    ///////////////////////////////Network Setting///////////////////////
                    textBox_ip_adress.Text = camera_list[i].network.network_IP;
                    textBox_http_port.Text = camera_list[i].network.network_http;
                    textBox_https_port.Text = camera_list[i].network.network_https;
                    textBox_rtsp_port.Text = camera_list[i].network.network_rtsp;
                    ///////////////////////////////Archive Setting///////////////////////
                    comboBox_storage.SelectedIndex = camera_list[i].archive.archive_set_storage;
                    comboBox_record_period.SelectedIndex = camera_list[i].archive.archive_set_record_period;
                    textBox_record_time.Text = camera_list[i].archive.archive_set_record_time;
                    textBox_quality_main.Text = camera_list[i].archive.archive_framerate;
                    textBox_framerate.Text = camera_list[i].archive.archive_framerate;
                    comboBox_record_stream.SelectedIndex = camera_list[i].archive.archive_set_record_stream;
                    label_archive_name.Text = camera_list[i].archive.archive_info_name;
                    label_archive_type.Text = camera_list[i].archive.archive_info_type;
                    label_archive_total.Text = camera_list[i].archive.archive_info_total;
                    label_archive_free.Text = camera_list[i].archive.archive_info_free;
                    ///////////////////////////////Event Setting///////////////////////

                    ///////////////////////////////Webpage///////////////////////

                    x.item.Add(camera_list[i]);
                    using (StreamWriter wr = new StreamWriter("Emp.xml"))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(Xmlclass));

                        xs.Serialize(wr, x);
                        wr.Close();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\r\n" + ex);
            }

        }
        private void Form_main_Load(object sender, EventArgs e)
        {

        }
        private void button_add_Click(object sender, EventArgs e)
        {
            Form_add add = new Form_add();
            add.Owner = this;
            add.Show();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            //camera_list.RemoveAt(listView_device.SelectedItems[0].Index);    //리스트 삭제하면서 생성했던 클래스도 삭제하기.. 
            camera_list.RemoveAt(listView_device.Items[listView_device.FocusedItem.Index].Index);
            //listView_device.Items.Remove(listView_device.SelectedItems[0]);
            listView_device.Items.Remove(listView_device.FocusedItem);

            /*
            if(listView_device.FocusedItem.Index < 0)                               //만약 모든 카메라 삭제시
            {
                textBox_name.Text = " ";
                textBox_username.Text = " ";
                textBox_password.Text = " ";
                label_dmodel.Text = " ";
                label_dmanufacturer.Text = " ";
                label_dfireware.Text = " ";

                textBox_ip_adress.Text = " ";
                textBox_http_port.Text = " ";
                textBox_https_port.Text = " ";
                textBox_rtsp_port.Text = " ";
            }
            */

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox_resolution_main_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }


        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<>////////
        private void listView_device_Click(object sender, EventArgs e)      //리스트 아이템 클릭시 tab 속성들 변경
        {

            int tmp = 0;
            if (listView_device.FocusedItem != null)
                tmp = listView_device.FocusedItem.Index;

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

        }
        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<Device Setting>//////////
        private void button_device_modify_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
                tmp = listView_device.FocusedItem.Index;
            string pw = "";
            for (int i = 0; i < textBox_password.TextLength; i++)
                pw = pw + "*";


            camera_list[tmp].device.enable = checkBox_enabled.Checked;
            camera_list[tmp].device.device_name = textBox_name.Text;
            camera_list[tmp].device.device_username=textBox_username.Text;
            camera_list[tmp].device.device_PW=textBox_password.Text ;
            listView_device.Items[tmp].SubItems[3].Text = pw;


        }

        private void button_device_cancel_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
                tmp = listView_device.FocusedItem.Index;

            checkBox_enabled.Checked = camera_list[tmp].device.enable;
            textBox_name.Text = camera_list[tmp].device.device_name;
            textBox_username.Text = camera_list[tmp].device.device_username;
            textBox_password.Text = camera_list[tmp].device.device_PW;
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
            int tmp=0;
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
        }

        private void button_video_cancel_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
                tmp = listView_device.FocusedItem.Index;


            comboBox_resolution_main.SelectedIndex = camera_list[tmp].video.video_main_resolution;
            textBox_framerate_main.Text= camera_list[tmp].video.video_main_framerate;
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
            brightness = trackBar_brightness.Value;
            contrast = trackBar_contrast.Value;
            sharpness = trackBar_sharpness.Value;
        }

        private void button_image_cancel_Click(object sender, EventArgs e)
        {
            trackBar_brightness.Value = brightness;
            trackBar_contrast.Value = contrast;
            trackBar_sharpness.Value = sharpness;
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
            int tmp = 0;
            if (listView_device.FocusedItem!= null)
                tmp = listView_device.FocusedItem.Index;
            //int tmp = listView_device.FocusedItem.Index== null ? 0:listView_device.FocusedItem.Index;

            camera_list[tmp].network.network_IP = textBox_ip_adress.Text;
            camera_list[tmp].network.network_http = textBox_http_port.Text;
            camera_list[tmp].network.network_https = textBox_https_port.Text;
            camera_list[tmp].network.network_rtsp = textBox_rtsp_port.Text;

            listView_device.Items[tmp].SubItems[1].Text = textBox_ip_adress.Text;
        }

        private void button7_network_cancel_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (listView_device.FocusedItem != null)
                tmp = listView_device.FocusedItem.Index;

            textBox_ip_adress.Text = camera_list[tmp].network.network_IP;
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
            int tmp = 0;
            if (listView_device.FocusedItem != null)
                tmp = listView_device.FocusedItem.Index;
            //int tmp = listView_device.FocusedItem.Index== null ? 0:listView_device.FocusedItem.Index;

            camera_list[tmp].archive.archive_set_storage = comboBox_storage.SelectedIndex;
            camera_list[tmp].archive.archive_set_record_period = comboBox_record_period.SelectedIndex;
            camera_list[tmp].archive.archive_set_record_time = textBox_record_time.Text;
            camera_list[tmp].archive.archive_framerate = textBox_framerate.Text;
            camera_list[tmp].archive.archive_set_record_stream = comboBox_record_stream.SelectedIndex;
          
        }

        private void button_archive_cancel_Click(object sender, EventArgs e)
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

        private void groupBox_webpage_Enter(object sender, EventArgs e)         /////임시..
        {
            webBrowser.Navigate("www.naver.com");
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //////<webpage>////////


    }
}
