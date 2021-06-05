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
    
    public partial class ModeleDevisSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModeleDevisSet()
        {
            this.ProduitSet = new HashSet<ProduitSet>();
        }
    
        public int IdModeleDevis { get; set; }
        public string NumDevis { get; set; }
        public System.DateTime Date { get; set; }
        public double Total { get; set; }
        public double Tva { get; set; }
        public double Ttc { get; set; }
        public int InfoFournisseur_IdFournisseur { get; set; }
        public int InfoConsultation_IdConsultation { get; set; }
    
        public virtual ConsultationSet InfoConsultation { get; set; }
        public virtual FournisseurSet InfoFournisseur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProduitSet> ProduitSet { get; set; }
    }
}
