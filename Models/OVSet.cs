namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OVSet")]
    public partial class OVSet
    {
        [Key]
        public int IdOV { get; set; }

        [Required]
        public string NumOV { get; set; }

        [Required]
        public string SousOrdonnateur { get; set; }

        [Required]
        public string TresorierPayeur { get; set; }

        public int InfoOP_IdOP { get; set; }

        public virtual OPSet OPSet { get; set; }
    }
}
