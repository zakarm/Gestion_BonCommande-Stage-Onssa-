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

    public partial class LrgSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LrgSet()
        {
            this.LigneSet = new HashSet<LigneSet>();
        }
    
        public int CodeLrg { get; set; }
        [Display(Name = "Description Lrg")]
        public string DescriptionLrg { get; set; }
        [Display(Name = "Num Lrg")]
        public string NumLrg { get; set; }
        [Display(Name = "Num Paragraphe")]
        public Nullable<int> InfoParagraphe_NumPar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneSet> LigneSet { get; set; }
        public virtual ParagrapheSet InfoParagraphe { get; set; }
    }
}
