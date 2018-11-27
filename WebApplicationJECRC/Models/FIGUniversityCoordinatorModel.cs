using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationJECRC.Models
{
    public class FIGUniversityCoordinatorModel
    {
        public int ID { get; set; }
        public int LoginID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }
    }
}