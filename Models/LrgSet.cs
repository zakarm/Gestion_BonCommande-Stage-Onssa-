namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LrgSet")]
    public partial class LrgSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LrgSet()
        {
            LigneSet = new HashSet<LigneSet>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodeLrg { get; set; }

        [Required]
        public string DescriptionLrg { get; set; }

        [Required]
        public string NumLrg { get; set; }

        public int? InfoParagraphe_NumPar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneSet> LigneSet { get; set; }

        public virtual ParagrapheSet ParagrapheSet { get; set; }
    }
}
