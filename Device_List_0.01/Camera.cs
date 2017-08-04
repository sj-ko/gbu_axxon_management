using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace Device_List_0._01
{
    public class management
    {
        public void serialize(Xmlclass x)
        {
            using (StreamWriter wr = new StreamWriter("Emp.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Xmlclass));

                xs.Serialize(wr, x);
                wr.Close();
            }
        }
    }
    public class Xmlclass
    {
        //for Serialization
        public List<Camera> item = new List<Camera>();
    }

    public class Camera
    {
        public string camera_manufacturer = "";
        public string camera_IP="";
        public string camera_ID = "";
        public string camera_PW = "";

        public Device device = new Device();
        public Video video = new Video();
        public Image image = new Image();
        public Network network = new Network();
        public Archive archive = new Archive();
        public Event eventsetting = new Event();
    }
}
