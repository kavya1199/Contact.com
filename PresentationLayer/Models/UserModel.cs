using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class UserModel
    {

        public int User_ID { get; set; }
        public string User_First_Name { get; set; }
        public string User_Last_Name { get; set; }

        [Required]
        [DisplayName("EmailId")]
        public string User_EmailId { get; set; }

        [Required]
        [DisplayName("Password")]
        public string User_Password { get; set; }
    }
}