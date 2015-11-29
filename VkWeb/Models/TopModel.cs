using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.IO;

using MySql.Data.MySqlClient;
using System.Text;
using Newtonsoft.Json.Linq;



namespace VkWeb.Models
{
    public class TopMadels
    {
        public List<String> top { set; get; }
        private DBMaster dbMaster = new DBMaster();

        //public TopMadels(UserDataModel userModel)
        public TopMadels(String date, int quantity)
        {
            top = new List<String>();
            //top = GetTopForDate(userModel.date, Convert.ToInt32(userModel.quantity), 34);
            top = GetTopForDate(date, quantity, 34);
        }

        public List<String> GetTopForDate(String date, int quantity, int idUser)
        {
            Dictionary<int, int> dictionaryTops = new Dictionary<int, int>();
            List<String> tops = new List<String>();
            dictionaryTops = FindByDate(date, quantity, idUser);
            tops = GetListTop(dictionaryTops);
            return tops;
        }


        private Dictionary<int, int> FindByDate(String date, int quantity, int idUser)
        {
            dbMaster.OpenConnection();
            int i = 0;
            String SQL = "SELECT * FROM tops WHERE id_user = " + idUser + " AND data = (SELECT STR_TO_DATE('" + date + "', '%d.%m.%Y'))";
            Dictionary<int, int> dictionaryTops = new Dictionary<int, int>();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read() & (i < quantity))
                    {
                        dictionaryTops.Add(Convert.ToInt32(reader["id_group"]), Convert.ToInt32(reader["count"]));
                        i++;
                        //dateTops = reader["data"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return dictionaryTops;
        }

        private String FindByIdGroup(int idGroup)
        {
            String SQL = "SELECT * FROM Groups WHERE id = " + idGroup;
            dbMaster.OpenConnection();
            String vkIDGroup = "";
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vkIDGroup = reader["id_vk"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return vkIDGroup;
        }

        public String PageData(String apiMetod, String param)
        {
            StringBuilder urlStr = new StringBuilder("https://api.vkontakte.ru/method/");
            urlStr.Append(apiMetod).Append("?").Append(param);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlStr.ToString());
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            return reader.ReadToEnd();
        }

        private List<String> GetListTop(Dictionary<int, int> dictionaryTops)
        {
            List<String> Tops = new List<String>();
            String html = "";
            JObject jsonObj = new JObject();
            foreach (var elementTop in dictionaryTops)
            {
                html = PageData("groups.getById", "group_id=" + FindByIdGroup(elementTop.Key));
                jsonObj = JObject.Parse(html);
                foreach (var result in jsonObj["response"])
                {
                    Tops.Add((String)result["name"]);
                }
            }
            return Tops;
        }


    }
}