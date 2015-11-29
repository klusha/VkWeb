using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
namespace VkWeb.Models
{
    public class DBMaster
    {
        private MySqlConnection MyConnection = null;
        public void OpenConnection()
        {
            String Connect = "Database=vk;Data Source=localhost;User Id=root;Password=; charset=utf8";
            MyConnection = new MySqlConnection(Connect);
            MyConnection.Open();
        }

        public MySqlConnection GetConnection()
        {
            return MyConnection;
        }

        public void CloseConnection()
        {
            MyConnection.Close();
        }
    }
}


