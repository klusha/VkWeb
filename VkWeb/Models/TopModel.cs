﻿using System;
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
    public class TopMadel
    {
        public List<String> top { set; get; }

        public TopMadel(String date, int quantity)
        {
            top = new List<String>();
            top = GetTopForDate(date, quantity, 34);
        }

        public List<String> GetTopForDate(String date, int quantity, int idUser)
        {
            Dictionary<int, int> dictionaryTops = new Dictionary<int, int>();
            List<String> tops = new List<String>();
            DBMaster dbMaster = new DBMaster();
            JSONMaster JSON = new JSONMaster();
            dictionaryTops = dbMaster.FindByDate(date, quantity, idUser);
            tops = JSON.GetListTop(dictionaryTops);
            return tops;
        }
    }
}