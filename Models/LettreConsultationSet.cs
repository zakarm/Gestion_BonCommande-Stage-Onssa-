namespace Projet_Onssa_Web_Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LettreConsultationSet")]
    public partial class LettreConsultationSet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdLettre { get; set; }

        public DateTime DateLettre { get; set; }

        public DateTime DateDelai { get; set; }

        public int? Consultation_IdConsultation { get; set; }

        public virtual ConsultationSet ConsultationSet { get; set; }
    }
}
