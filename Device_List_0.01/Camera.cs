using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace Device_List_0._01
{
    public class json_camera
    {
        public string FriendlyNameLong { get; set; }
        public string State { get; set; }
    }
    public class management
    {
        public void serialize(Xmlclass x)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Xmlclass));
            FileStream fs = new FileStream("Emp.xml",FileMode.Create,FileAccess.Write);
            xs.Serialize(fs, x);
            fs.Close();
        }

        public string Request_Json()       //Refresh 버튼을 누르면 http로 json을 가져온다
        {
            string result = null;
            string url = "http://192.168.0.109/video-origins/DESKTOP-U8VKICK";
            Console.WriteLine("url : " + url);

            StringBuilder postParams = new StringBuilder();
            
            byte[] byteDataParams = UTF8Encoding.UTF8.GetBytes(postParams.ToString());

            try
            {       //HttpWebRequest -> for web parshing? 
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);            //요청 만들기

                request.Credentials = new NetworkCredential("root", "root");
                
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();          //요청 받기..?
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();                                        //현재 위치부터 스트림의 끝까지 모든 문자 읽기
                stream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        public List<json_camera> ParseJson(String json)             //JSON Parse 받아온 json 문자열 파싱
        {
            List<json_camera> Server_camera = new List<json_camera>();     //issues 리스트 생성

            JObject obj = JObject.Parse(json);          //JObject 클래스, JSON 문자열 구하기
            List<JToken> array = obj.Children().ToList();//JArray 클래스
            foreach (JToken itemObj in array)
            {
                json_camera issue = new json_camera();                      //리스트에 Parse한 문자열 집어넣기
                issue.FriendlyNameLong = itemObj.First.SelectToken("friendlyNameLong").ToString();
                issue.State = itemObj.First.SelectToken("state").ToString();
                Server_camera.Add(issue);              //리스트 추가
            }
            return Server_camera;
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
        public string camera_connect = "";
        
        public Device device = new Device();
        public Video video = new Video();
        public Image image = new Image();
        public Network network = new Network();
        public Archive archive = new Archive();
        public Event eventsetting = new Event();
    }
}
