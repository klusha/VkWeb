using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VkWeb.Models
{
    public class UserDataModel
    {
        public String URL { set; get; }
        public String date { set; get; }
        public String quantity { set; get; }
        //public TopMadels top;

        public UserDataModel()
        {
            //top = null;
        }

        public bool ComplianceTest()
        {
            this.URL = this.URL.Trim();
            if (!string.IsNullOrWhiteSpace(this.URL))
            {
                if (this.URL.StartsWith("http://vk.com/"))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CorrectDate()
        {
            this.date = this.date.Trim();
            DateTime dt;
            bool parse = DateTime.TryParse(this.date, out dt);
            return parse;
        }

        public bool CorrectQuantity()
        {
            // Проверка на то что в поле quantity введено число
            bool IsDigit = this.quantity.Length == this.quantity.Where(c => char.IsDigit(c)).Count();
            return IsDigit;
        }
    }
}