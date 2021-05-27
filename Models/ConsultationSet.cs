namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConsultationSet")]
    public partial class ConsultationSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConsultationSet()
        {
            LettreConsultationSet = new HashSet<LettreConsultationSet>();
            ModeleDevisSet = new HashSet<ModeleDevisSet>();
            PVJSet = new HashSet<PVJSet>();
            FournisseurSet = new HashSet<FournisseurSet>();
        }

        [Key]
        public int IdConsultation { get; set; }

        [Required]
        public string ObjetConsultation { get; set; }

        [Required]
        public string NumConsultation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LettreConsultationSet> LettreConsultationSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModeleDevisSet> ModeleDevisSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PVJSet> PVJSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FournisseurSet> FournisseurSet { get; set; }
    }
}
