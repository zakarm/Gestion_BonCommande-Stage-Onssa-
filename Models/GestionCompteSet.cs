namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GestionCompteSet")]
    public partial class GestionCompteSet
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string MotDePasse { get; set; }

        [Required]
        public string TypeCompte { get; set; }
    }
}
