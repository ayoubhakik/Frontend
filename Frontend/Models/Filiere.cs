using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Frontend.Models
{
    [Table("Filieres")]
    public class Filiere
    {
        [Key]
        public int id_filiere { get; set; }
        public string nom_filiere { get; set; }
        [JsonIgnore]
        public virtual ICollection<Etudiant> Etudiants { get; set; }
    }
}