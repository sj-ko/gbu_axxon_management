using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device_List_0._01
{
    public class Camera
    {
        public string camera_manufacturer = "";
        public string camera_IP="";
        public string camera_ID = "";
        public string camera_PW = "";

        Device device = new Device();
        Video video = new Video();
        Image image = new Image();
        Network network = new Network();
        Archive archive = new Archive();
        Event eventsetting = new Event();
        Webpage webpage = new Webpage();
    }
}
