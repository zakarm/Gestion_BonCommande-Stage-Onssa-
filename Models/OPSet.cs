namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OPSet")]
    public partial class OPSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OPSet()
        {
            OVSet = new HashSet<OVSet>();
        }

        [Key]
        public int IdOP { get; set; }

        [Required]
        public string NumOP { get; set; }

        public DateTime DateOP { get; set; }

        public int InfoOI_IdOI { get; set; }

        public virtual OISet OISet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OVSet> OVSet { get; set; }
    }
}
