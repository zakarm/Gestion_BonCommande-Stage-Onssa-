namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModeleDevisSet")]
    public partial class ModeleDevisSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModeleDevisSet()
        {
            ProduitSet = new HashSet<ProduitSet>();
        }

        [Key]
        public int IdModeleDevis { get; set; }

        [Required]
        public string NumDevis { get; set; }

        public DateTime Date { get; set; }

        public double Total { get; set; }

        public double Tva { get; set; }

        public double Ttc { get; set; }

        public int InfoFournisseur_IdFournisseur { get; set; }

        public int InfoConsultation_IdConsultation { get; set; }

        public virtual ConsultationSet ConsultationSet { get; set; }

        public virtual FournisseurSet FournisseurSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProduitSet> ProduitSet { get; set; }
    }
}
