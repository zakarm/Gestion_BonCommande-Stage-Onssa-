namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MorasseSet")]
    public partial class MorasseSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MorasseSet()
        {
            BCSet = new HashSet<BCSet>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodeMorasse { get; set; }

        [Required]
        public string Exercice { get; set; }

        [Required]
        public string Budget { get; set; }

        [Required]
        public string Description { get; set; }

        public int Ligne_CodeLigne { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BCSet> BCSet { get; set; }

        public virtual LigneSet LigneSet { get; set; }
    }
}
