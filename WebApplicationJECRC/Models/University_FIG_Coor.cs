//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationJECRC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class University_FIG_Coor
    {
        public int ID { get; set; }
        public int LoginID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual Login Login { get; set; }
    }
}
