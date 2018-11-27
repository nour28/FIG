using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationJECRC.Models
{
    public class LoginModel
    {
        public int ID { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string Psw { get; set; }

        public string LoadingErrorMessage { get; set; }
    }
}