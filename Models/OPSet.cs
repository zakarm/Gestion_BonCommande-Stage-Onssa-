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
    
    public partial class OPSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OPSet()
        {
            this.OVSet = new HashSet<OVSet>();
        }
    
        public int IdOP { get; set; }
        public string NumOP { get; set; }
        public System.DateTime DateOP { get; set; }
        public int InfoOI_IdOI { get; set; }
    
        public virtual OISet InfoOI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OVSet> OVSet { get; set; }
    }
}
