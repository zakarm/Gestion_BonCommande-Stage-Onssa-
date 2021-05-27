namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OISet")]
    public partial class OISet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OISet()
        {
            OPSet = new HashSet<OPSet>();
            PVRSet = new HashSet<PVRSet>();
        }

        [Key]
        public int IdOI { get; set; }

        [Required]
        public string NumOi { get; set; }

        public DateTime DateOI { get; set; }

        [Required]
        public string NumCompteDebit { get; set; }

        [Required]
        public string VisaControle { get; set; }

        [Required]
        public string VisaCsrs { get; set; }

        public DateTime DatePaiement { get; set; }

        [Required]
        public string VisaSordonnateur { get; set; }

        [Required]
        public string VisaTresorierPayeur { get; set; }

        public int InfoFE_IdFE { get; set; }

        public virtual FESet FESet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OPSet> OPSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PVRSet> PVRSet { get; set; }
    }
}
