namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PVJSet")]
    public partial class PVJSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PVJSet()
        {
            BCSet = new HashSet<BCSet>();
            CommissionSet = new HashSet<CommissionSet>();
            FournisseurSet1 = new HashSet<FournisseurSet>();
        }

        [Key]
        public int IdPVJ { get; set; }

        public DateTime DatePvj { get; set; }

        [Required]
        public string NumPvj { get; set; }

        public int InfoConsultation_IdConsultation { get; set; }

        public int InfoFournisseur_IdFournisseur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BCSet> BCSet { get; set; }

        public virtual ConsultationSet ConsultationSet { get; set; }

        public virtual FournisseurSet FournisseurSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommissionSet> CommissionSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FournisseurSet> FournisseurSet1 { get; set; }
    }
}
