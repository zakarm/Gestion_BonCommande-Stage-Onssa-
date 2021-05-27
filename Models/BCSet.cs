namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BCSet")]
    public partial class BCSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BCSet()
        {
            FESet = new HashSet<FESet>();
        }

        [Key]
        public int IdBC { get; set; }

        [Required]
        public string NumBc { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public string DelaiExecution { get; set; }

        public DateTime DateBC { get; set; }

        public int InfoMorasse_CodeMorasse { get; set; }

        public int InfoPVJ_IdPVJ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FESet> FESet { get; set; }

        public virtual MorasseSet MorasseSet { get; set; }

        public virtual PVJSet PVJSet { get; set; }
    }
}
