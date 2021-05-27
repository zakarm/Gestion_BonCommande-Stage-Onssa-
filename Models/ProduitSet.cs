namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProduitSet")]
    public partial class ProduitSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProduitSet()
        {
            ModeleDevisSet = new HashSet<ModeleDevisSet>();
        }

        [Key]
        public int IdProduit { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string Unite { get; set; }

        public int Quantite { get; set; }

        public double Prix_Unitaire { get; set; }

        public double Prix_Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModeleDevisSet> ModeleDevisSet { get; set; }
    }
}
