using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Immobiliére.Models
{
    // Table : spécifie la table de la base de donné à laquelle la classe est mappée
    [Table("owner", Schema = "public")]
    public class Owner
    {
        [Key]
        public int Id_owner { get; set; }

        [Required(ErrorMessage = "Le nom du propriétaire est requis")]
       
        public string Name_owner { get; set; }
        public string First_name_owner { get; set; }
         [EmailAddress(ErrorMessage = "L'adresse e-mail est requise")]
        public string E_mail_owner { get; set; }
        public string Phone_number_owner { get; set; }
    }
}
