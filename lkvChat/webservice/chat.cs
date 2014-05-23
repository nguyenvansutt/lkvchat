using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using lkvChat.Object;
namespace lkvChat.webservice
{
    public class chat
    {
        public string getResponse(string url, Dictionary<string, string> parameters)
        {

            string postData = string.Join("&", parameters.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray());
            
            //string postData = "username=" + username + "&password=" + password;


            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Post the data to the right place.
            Uri target = new Uri(url);
            WebRequest request = WebRequest.Create(target);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            string json = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                Stream stream = response.GetResponseStream();

                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        json += reader.ReadLine();
                    }
                }
            }
            return json;
            
        }
        public void login(string url,user user,string username, string password)
        {
            Dictionary<string, string> param = new Dictionary<string, string> { { "username", username }, { "password", password } };
            var json = getResponse(url + "/xml/checklogin", param);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, object> response = (Dictionary<string, object>)serializer.DeserializeObject(json);            
            if ((bool)response.FirstOrDefault().Value)
            {
                user.setLogged(username,password);
                
            }else{ throw new Exception("Could not login");}
        }
        public void getListChat(string url, user user, string username, string password)
        {
            Dictionary<string, string> param = new Dictionary<string, string> { { "username", username }, { "password", password } };
            var json = getResponse(url + "/xml/lists", param);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, object> response = (Dictionary<string, object>)serializer.DeserializeObject(json);
            Dictionary<string, object> rows = (Dictionary<string, object>)((Dictionary<string, object>)response["active_chats"])["rows"];
            foreach(var row in rows){
                string temp = serializer.Serialize(row.Value);
                Conversationchat activechat = serializer.Deserialize<Conversationchat>(temp);
            }
            //Dictionary<string, string> response2 = serializer.Deserialize<Dictionary<string, string>>(response1["active_chats"]);
            //Dictionary<string, string> response3 = serializer.Deserialize<Dictionary<string, string>>(response1["rows"]);

            //serializer.Serialize(response3);
            
                //Conversationchat activechat = serializer.Deserialize<Conversationchat>(a);
                
            
            
        }
    }
}
