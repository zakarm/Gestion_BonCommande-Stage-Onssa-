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

    public partial class PVJSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PVJSet()
        {
            this.BCSet = new HashSet<BCSet>();
            this.CommissionSet = new HashSet<CommissionSet>();
            this.FournisseurSet1 = new HashSet<FournisseurSet>();
        }
    
        public int IdPVJ { get; set; }
        [Display(Name = "Date procès verbal de jugement")]
        public System.DateTime DatePvj { get; set; }
        [Display(Name = "Num procès verbal de jugement")]
        public string NumPvj { get; set; }
        [Display(Name = "Id Consultation")]
        public int InfoConsultation_IdConsultation { get; set; }
        [Display(Name = "Id Fournisseur")]
        public int InfoFournisseur_IdFournisseur { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BCSet> BCSet { get; set; }
        public virtual ConsultationSet InfoConsultation { get; set; }
        public virtual FournisseurSet InfoFournisseur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommissionSet> CommissionSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FournisseurSet> FournisseurSet1 { get; set; }
    }
}
