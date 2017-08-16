using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

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

        public void jasondata()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.0.109/video-origins/DESKTOP-U8VKICK");
            httpWebRequest.Credentials=new NetworkCredential("user", "password");
            //httpWebRequest.PreAuthenticate = true;
            var response = httpWebRequest.GetResponse();
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"user\":\"root\"," +
                              "\"password\":\"root\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
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
