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
        public Dictionary<string, object> getResponse(string url, Dictionary<string, string> parameters)
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
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, object> x = (Dictionary<string, object>)serializer.DeserializeObject(json);
            return x;
        }
        public void login(string url,user user,string username, string password)
        {
            Dictionary<string, string> param = new Dictionary<string, string> { { "username", username }, { "password", password } };
            var response = getResponse(url + "/xml/checklogin", param);
            if ((bool)response.FirstOrDefault().Value)
            {
                user.setLogged(username,password);
                
            }else{ throw new Exception("Could not login");}
        }
    }
}
