using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Tables
{
    public static class Server
    {
        public static JavaScriptSerializer serializer = new JavaScriptSerializer();

        public static string PostQuery(string PHPpath, string query) {

            string response = "";

            try {

                byte[] data = Encoding.UTF8.GetBytes(query);

                HttpWebRequest HTRQ = HttpWebRequest.CreateHttp(PHPpath);
                HTRQ.Method = "POST";
                HTRQ.ContentType = "application/x-www-form-urlencoded";
                HTRQ.ContentLength = data.Length;

                Stream strw = HTRQ.GetRequestStream();
                strw.Write(data, 0, data.Length);
                strw.Close();

                HttpWebResponse HTPR = HTRQ.GetResponse() as HttpWebResponse;
                StreamReader str = new StreamReader(HTPR.GetResponseStream());

                response = str.ReadLine();
                str.Close();
                HTPR.Close();
            }
            catch { MessageBox.Show("Отсутствует подключение к Интренет"); }

            return response == "" || response == "<!-- zzz <!--]-->" ? "{ }" : response;
        }

        public static List<T> Deserialize<T>(string JSON) {

            return serializer.Deserialize<List<T>>(JSON);
        }
    }
}
