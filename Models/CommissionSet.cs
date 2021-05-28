namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommissionSet")]
    public partial class CommissionSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommissionSet()
        {
            PVRSet = new HashSet<PVRSet>();
            PVJSet = new HashSet<PVJSet>();
        }

        [Key]
        public int IdCommission { get; set; }

        [Required(ErrorMessage = "veuillez fournir un Nom")]
        [Display(Name = "Nom Commission")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "veuillez fournir un Prenom")]
        [Display(Name = "Prénom Commission")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "veuillez fournir un Fonction")]
        [Display(Name = "Fonction")]
        public string Fonction { get; set; }

        [Required(ErrorMessage = "veuillez fournir un Affectation")]
        [Display(Name = "Affectation")]
        public string Affectation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PVRSet> PVRSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PVJSet> PVJSet { get; set; }
    }
}
