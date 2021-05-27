namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PVRSet")]
    public partial class PVRSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PVRSet()
        {
            CommissionSet = new HashSet<CommissionSet>();
        }

        [Key]
        public int IdPVR { get; set; }

        public DateTime DatePVR { get; set; }

        [Required]
        public string NumPvr { get; set; }

        public int InfoOI_IdOI { get; set; }

        public virtual OISet OISet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommissionSet> CommissionSet { get; set; }
    }
}
