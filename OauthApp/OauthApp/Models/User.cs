//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OauthApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public System.Guid userID { get; set; }
        public string Avatar { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Discriminator { get; set; }
    
        public virtual Login Login { get; set; }
    }
}
