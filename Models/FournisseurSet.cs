namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FournisseurSet")]
    public partial class FournisseurSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FournisseurSet()
        {
            ModeleDevisSet = new HashSet<ModeleDevisSet>();
            PVJSet = new HashSet<PVJSet>();
            ConsultationSet = new HashSet<ConsultationSet>();
            PVJSet1 = new HashSet<PVJSet>();
        }

        [Key]
        public int IdFournisseur { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Adresse { get; set; }

        public int RC_n { get; set; }

        [Required]
        public string Patente_n { get; set; }

        public int IF_n { get; set; }

        public int CNSS_n { get; set; }

        [Required]
        public string Compte_bancaire_n { get; set; }

        [Required]
        public string ICE { get; set; }

        [Required]
        public string Ville { get; set; }

        [Required]
        public string Banque { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModeleDevisSet> ModeleDevisSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PVJSet> PVJSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultationSet> ConsultationSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PVJSet> PVJSet1 { get; set; }
    }
}
