using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Device_List_0._01
{


    public partial class Form_main : Form
    {

        public List<Camera> camera_list = new List<Camera>();

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

        private void button_image_modify_Click(object sender, EventArgs e)
        {
            brightness = trackBar_brightness.Value;
            contrast = trackBar_contrast.Value;
            sharpness = trackBar_sharpness.Value;
        }

        private void button_image_cancel_Click(object sender, EventArgs e)
        {
            trackBar_brightness.Value= brightness;
            trackBar_contrast.Value = contrast;
            trackBar_sharpness.Value = sharpness;
            
        }

        private void listView_device_SelectedIndexChanged(object sender, EventArgs e)
        {


            
            
        }

        private void groupBox_device_Enter(object sender, EventArgs e)
        {

        }

        private void listView_device_Click(object sender, EventArgs e)      //리스트 아이템 클릭시 tab 속성들 변경
        {

            int tmp = listView_device.FocusedItem.Index;

            
            textBox_name.Text = camera_list[tmp].device.device_name;
            textBox_username.Text = camera_list[tmp].device.device_username;
            textBox_password.Text = camera_list[tmp].device.device_PW;
            label_dmodel.Text = camera_list[tmp].device.device_model;
            label_dmanufacturer.Text = camera_list[tmp].device.device_manufacturer;
            label_dfireware.Text = camera_list[tmp].device.device_firmware;


            textBox_ip_adress.Text = camera_list[tmp].network.network_IP;
            textBox_http_port.Text = camera_list[tmp].network.network_http;
            textBox_https_port.Text = camera_list[tmp].network.network_https;
            textBox_rtsp_port.Text = camera_list[tmp].network.network_rtsp;

        }

        private void button_device_modify_Click(object sender, EventArgs e)
        {
            int tmp = listView_device.FocusedItem.Index;

            camera_list[tmp].device.device_name = textBox_name.Text;
            camera_list[tmp].device.device_username=textBox_username.Text;
            camera_list[tmp].device.device_PW=textBox_password.Text ;
            listView_device.Items[tmp].SubItems[3].Text = textBox_password.Text;


        }

        private void button_device_cancel_Click(object sender, EventArgs e)
        {
            int tmp = listView_device.FocusedItem.Index;

            textBox_name.Text = camera_list[tmp].device.device_name;
            textBox_username.Text = camera_list[tmp].device.device_username;
            textBox_password.Text = camera_list[tmp].device.device_PW;
        }

        private void button_network_modify_Click(object sender, EventArgs e)
        {
            int tmp = listView_device.FocusedItem.Index;

            camera_list[tmp].network.network_IP = textBox_ip_adress.Text;
            camera_list[tmp].network.network_http = textBox_http_port.Text;
            camera_list[tmp].network.network_https = textBox_https_port.Text;
            camera_list[tmp].network.network_rtsp = textBox_rtsp_port.Text;
        }

        private void button7_network_cancel_Click(object sender, EventArgs e)
        {
            int tmp = listView_device.FocusedItem.Index;

            textBox_ip_adress.Text = camera_list[tmp].network.network_IP;
            textBox_http_port.Text = camera_list[tmp].network.network_http;
            textBox_https_port.Text = camera_list[tmp].network.network_https;
            textBox_rtsp_port.Text = camera_list[tmp].network.network_rtsp;
        }
    }
}
