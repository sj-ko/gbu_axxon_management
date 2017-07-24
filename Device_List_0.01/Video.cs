using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Device_List_0._01
{
    public class Video
    {
        public ComboBox video_main_resolution;
        public string video_main_framerate="";
        public ComboBox video_main_codec;
        public string video_main_quality="";
        public string video_main_bitrate="";

        public ComboBox video_sub_resolution;
        public string video_sub_framerate="";
        public ComboBox video_sub_codec;
        public string video_sub_quality="";
        public string video_sub_bitrate="";
    }
}
