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
    
    public partial class PVRSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PVRSet()
        {
            this.CommissionSet = new HashSet<CommissionSet>();
        }
    
        public int IdPVR { get; set; }
        public System.DateTime DatePVR { get; set; }
        public string NumPvr { get; set; }
        public int InfoOI_IdOI { get; set; }
    
        public virtual OISet InfoOI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommissionSet> CommissionSet { get; set; }
    }
}
