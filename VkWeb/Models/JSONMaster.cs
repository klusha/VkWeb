using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VkWeb.Models
{
    public class JSONMaster
    {
        public List<String> GetListTop(Dictionary<int, int> dictionaryTops)
        {
            List<String> Tops = new List<String>();
            String html = "";
            JObject jsonObj = new JObject();
            HttpMaster httpMaster = new HttpMaster();
            DBMaster dbMaster = new DBMaster();
            foreach (var elementTop in dictionaryTops)
            {
                html = httpMaster.PageData("groups.getById", "group_id=" + dbMaster.FindByIdGroup(elementTop.Key));
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