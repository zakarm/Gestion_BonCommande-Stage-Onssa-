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

    public partial class MorasseSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MorasseSet()
        {
            this.BCSet = new HashSet<BCSet>();
        }
    
        public int CodeMorasse { get; set; }
        [Display(Name = "Exercice")]
        public string Exercice { get; set; }
        [Display(Name = "Budget")]
        public string Budget { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Code Ligne ")]
        public int Ligne_CodeLigne { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BCSet> BCSet { get; set; }
        public virtual LigneSet Ligne { get; set; }
    }
}
