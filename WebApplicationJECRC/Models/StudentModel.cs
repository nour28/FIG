using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationJECRC.Models
{
    public class StudentModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Required]
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; }

        public int BranchID { get; set; }

        [DisplayName("Parents Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string ParentMobilenNumber { get; set; }

        [Required]
        [DisplayName("Letter Alloted")]
        public Nullable<bool> LetterAlloted { get; set; }

        [Required]
        [DisplayName("Has Applied")]
        public Nullable<bool> HasApplied { get; set; }

        [Required]
        [DisplayName("Is Paid")]
        public Nullable<bool> IsPaid { get; set; }

        [DataType(DataType.Currency)]
        public string Amount { get; set; }

        public int OrganiID { get; set; }

        public int FigID { get; set; }

        public int LoginID { get; set; }

        [Required]
        [DisplayName("Organization Name")]
        public string OrganizationName { get; set; }


        [Required]
        [DisplayName("Organization Location ")]
        public string Location { get; set; }

        [Required]
        [DisplayName("Organization Address ")]
        public string Adress { get; set; }

        [Required]
        [DisplayName("Organization Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }
        [Required]
        [DisplayName("FIG Name")]
        public string FigName { get; set; }
        [Required]
        [DisplayName("Field Name")]
        public string FieldName { get; set; }


    }
}