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
    
    public partial class LigneSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LigneSet()
        {
            this.MorasseSet = new HashSet<MorasseSet>();
        }
    
        public int CodeLigne { get; set; }
        public string DescriptionLigne { get; set; }
        public Nullable<int> InfoLrg_CodeLrg { get; set; }
    
        public virtual LrgSet InfoLrg { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MorasseSet> MorasseSet { get; set; }
    }
}
