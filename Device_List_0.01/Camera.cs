﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Device_List_0._01
{
    public class management
    {
        public void serialize(Xmlclass x)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Xmlclass));
            FileStream fs = new FileStream("Emp.xml",FileMode.Create,FileAccess.Write);
            xs.Serialize(fs, x);
            fs.Close();
        }
    }
    public class Xmlclass
    {
        //for Serialization
        public List<Camera> item = new List<Camera>();
    }

    public class Camera
    {
        public string camera_server = "";
        public string camera_manufacturer = "";
        public string camera_IP="";
        public string camera_ID = "";
        public string camera_PW = "";
        public bool camera_connect = true;

        public Device device = new Device();
        public Video video = new Video();
        public Image image = new Image();
        public Network network = new Network();
        public Archive archive = new Archive();
        public Event eventsetting = new Event();
    }
}
