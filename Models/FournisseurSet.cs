namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FournisseurSet")]
    public partial class FournisseurSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FournisseurSet()
        {
            ModeleDevisSet = new HashSet<ModeleDevisSet>();
            PVJSet = new HashSet<PVJSet>();
            ConsultationSet = new HashSet<ConsultationSet>();
            PVJSet1 = new HashSet<PVJSet>();
        }

        [Key]
        public int IdFournisseur { get; set; }

        [Required (ErrorMessage = "veuillez fournir un nom")]
        [Display (Name = "Nom Fournisseur")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "veuillez fournir Adresse")]
        [Display(Name = "Adresse Fournisseur")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "veuillez fournir RC n°")]
        [Display(Name = "RC n°")]
        public int RC_n { get; set; }

        [Required(ErrorMessage = "veuillez fournir Patente n°")]
        [Display(Name = "Patente n°")]
        public string Patente_n { get; set; }

        [Required(ErrorMessage = "veuillez fournir IF n°")]
        [Display(Name = "IF n°")]
        public int IF_n { get; set; }

        [Required(ErrorMessage = "veuillez fournir CNSS n°")]
        [Display(Name = "CNSS n°")]
        public int CNSS_n { get; set; }

        [Required(ErrorMessage = "veuillez fournir Compte bancaire n°")]
        [Display(Name = "Compte bancaire n°")]
        public string Compte_bancaire_n { get; set; }

        [Required(ErrorMessage = "veuillez fournir ICE")]
        [Display(Name = "ICE")]
        public string ICE { get; set; }

        [Required(ErrorMessage = "veuillez fournir la ville")]
        [Display(Name = "Ville")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "veuillez fournir Banque")]
        [Display(Name = "Banque")]
        public string Banque { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModeleDevisSet> ModeleDevisSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PVJSet> PVJSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultationSet> ConsultationSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PVJSet> PVJSet1 { get; set; }
    }
}
