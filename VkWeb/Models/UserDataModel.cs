using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VkWeb.Models
{
    public class UserDataModel
    {
        public String URL { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'-'MM'-'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Введите дату")]
        public DateTime date { set; get; }

        public int quantity { set; get; }


        public UserDataModel()
        {
            //top = null;
        }

        public bool ComplianceTest()
        {
            this.URL = this.URL.Trim();
            if (!string.IsNullOrWhiteSpace(this.URL))
            {
                if (this.URL.StartsWith("http://vk.com/") | this.URL.StartsWith("https://vk.com/"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}