//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ProduitSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProduitSet()
        {
            this.ModeleDevisSet = new HashSet<ModeleDevisSet>();
        }
    
        public int IdProduit { get; set; }
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [Display(Name = "Unite")]
        public string Unite { get; set; }
        [Display(Name = "Quantite")]
        public int Quantite { get; set; }
        [Display(Name = "Prix Unitaire")]
        public double Prix_Unitaire { get; set; }
        [Display(Name = "Prix Total")]
        public double Prix_Total { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModeleDevisSet> ModeleDevisSet { get; set; }
    }
}
