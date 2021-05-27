using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Projet_Onssa_Web_Mvc.Models
{
    public partial class Onssa_Model : DbContext
    {
        public Onssa_Model()
            : base("name=OnssaModel")
        {
        }

        public virtual DbSet<BCSet> BCSet { get; set; }
        public virtual DbSet<CommissionSet> CommissionSet { get; set; }
        public virtual DbSet<ConsultationSet> ConsultationSet { get; set; }
        public virtual DbSet<FESet> FESet { get; set; }
        public virtual DbSet<FournisseurSet> FournisseurSet { get; set; }
        public virtual DbSet<GestionCompteSet> GestionCompteSet { get; set; }
        public virtual DbSet<LettreConsultationSet> LettreConsultationSet { get; set; }
        public virtual DbSet<LigneSet> LigneSet { get; set; }
        public virtual DbSet<LrgSet> LrgSet { get; set; }
        public virtual DbSet<ModeleDevisSet> ModeleDevisSet { get; set; }
        public virtual DbSet<MorasseSet> MorasseSet { get; set; }
        public virtual DbSet<OISet> OISet { get; set; }
        public virtual DbSet<OPSet> OPSet { get; set; }
        public virtual DbSet<OVSet> OVSet { get; set; }
        public virtual DbSet<ParagrapheSet> ParagrapheSet { get; set; }
        public virtual DbSet<ProduitSet> ProduitSet { get; set; }
        public virtual DbSet<PVJSet> PVJSet { get; set; }
        public virtual DbSet<PVRSet> PVRSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BCSet>()
                .HasMany(e => e.FESet)
                .WithRequired(e => e.BCSet)
                .HasForeignKey(e => e.InfoBC_IdBC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommissionSet>()
                .HasMany(e => e.PVRSet)
                .WithMany(e => e.CommissionSet)
                .Map(m => m.ToTable("CommissionPVR").MapLeftKey("ListCommission_IdCommission").MapRightKey("ListPVR_IdPVR"));

            modelBuilder.Entity<CommissionSet>()
                .HasMany(e => e.PVJSet)
                .WithMany(e => e.CommissionSet)
                .Map(m => m.ToTable("PVJCommission").MapLeftKey("ListCommissions_IdCommission").MapRightKey("ListPVJ_IdPVJ"));

            modelBuilder.Entity<ConsultationSet>()
                .HasMany(e => e.LettreConsultationSet)
                .WithOptional(e => e.ConsultationSet)
                .HasForeignKey(e => e.Consultation_IdConsultation);

            modelBuilder.Entity<ConsultationSet>()
                .HasMany(e => e.ModeleDevisSet)
                .WithRequired(e => e.ConsultationSet)
                .HasForeignKey(e => e.InfoConsultation_IdConsultation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConsultationSet>()
                .HasMany(e => e.PVJSet)
                .WithRequired(e => e.ConsultationSet)
                .HasForeignKey(e => e.InfoConsultation_IdConsultation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConsultationSet>()
                .HasMany(e => e.FournisseurSet)
                .WithMany(e => e.ConsultationSet)
                .Map(m => m.ToTable("ConsultationFournisseur").MapLeftKey("ListConsultation_IdConsultation").MapRightKey("ListFournisseur_IdFournisseur"));

            modelBuilder.Entity<FESet>()
                .HasMany(e => e.OISet)
                .WithRequired(e => e.FESet)
                .HasForeignKey(e => e.InfoFE_IdFE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FournisseurSet>()
                .HasMany(e => e.ModeleDevisSet)
                .WithRequired(e => e.FournisseurSet)
                .HasForeignKey(e => e.InfoFournisseur_IdFournisseur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FournisseurSet>()
                .HasMany(e => e.PVJSet)
                .WithRequired(e => e.FournisseurSet)
                .HasForeignKey(e => e.InfoFournisseur_IdFournisseur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FournisseurSet>()
                .HasMany(e => e.PVJSet1)
                .WithMany(e => e.FournisseurSet1)
                .Map(m => m.ToTable("PVJFournisseur").MapLeftKey("ListFournisseursRepondu_IdFournisseur").MapRightKey("ListPVJ1_IdPVJ"));

            modelBuilder.Entity<LigneSet>()
                .HasMany(e => e.MorasseSet)
                .WithRequired(e => e.LigneSet)
                .HasForeignKey(e => e.Ligne_CodeLigne)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LrgSet>()
                .HasMany(e => e.LigneSet)
                .WithOptional(e => e.LrgSet)
                .HasForeignKey(e => e.InfoLrg_CodeLrg);

            modelBuilder.Entity<ModeleDevisSet>()
                .HasMany(e => e.ProduitSet)
                .WithMany(e => e.ModeleDevisSet)
                .Map(m => m.ToTable("ModeleDevisProduit").MapLeftKey("ListModeleDevis_IdModeleDevis").MapRightKey("ListProduit_IdProduit"));

            modelBuilder.Entity<MorasseSet>()
                .HasMany(e => e.BCSet)
                .WithRequired(e => e.MorasseSet)
                .HasForeignKey(e => e.InfoMorasse_CodeMorasse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OISet>()
                .HasMany(e => e.OPSet)
                .WithRequired(e => e.OISet)
                .HasForeignKey(e => e.InfoOI_IdOI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OISet>()
                .HasMany(e => e.PVRSet)
                .WithRequired(e => e.OISet)
                .HasForeignKey(e => e.InfoOI_IdOI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OPSet>()
                .HasMany(e => e.OVSet)
                .WithRequired(e => e.OPSet)
                .HasForeignKey(e => e.InfoOP_IdOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParagrapheSet>()
                .HasMany(e => e.LrgSet)
                .WithOptional(e => e.ParagrapheSet)
                .HasForeignKey(e => e.InfoParagraphe_NumPar);

            modelBuilder.Entity<PVJSet>()
                .HasMany(e => e.BCSet)
                .WithRequired(e => e.PVJSet)
                .HasForeignKey(e => e.InfoPVJ_IdPVJ)
                .WillCascadeOnDelete(false);
        }
    }
}
