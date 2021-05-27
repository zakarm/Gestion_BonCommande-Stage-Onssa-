namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FESet")]
    public partial class FESet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FESet()
        {
            OISet = new HashSet<OISet>();
        }

        [Key]
        public int IdFE { get; set; }

        public int CreditsBudgetaires { get; set; }

        public int DepensesEngagees { get; set; }

        public int Disponible { get; set; }

        public int EngagementDepensesPropose { get; set; }

        [Required]
        public string NumFe { get; set; }

        public int InfoBC_IdBC { get; set; }

        public virtual BCSet BCSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OISet> OISet { get; set; }
    }
}
