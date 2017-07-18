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


    public partial class Form_main : Form
    {

        
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


            List<device> device_add = new List<device>();

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
        private void button_modify_Click(object sender, EventArgs e)
        {

        }

        private void button_remove_Click(object sender, EventArgs e)
        {

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

    }
}
