using _4EPlatform.Domain.Models.Attachments;
using _4EPlatform.Domain.Models.CasuseModels;
using _4EPlatform.Domain.Models.ELibraryModels;
using _4EPlatform.Domain.Models.Lookups;
using _4EPlatform.Domain.Models.SessionModels;

namespace _4EPlatForm.Infrastrucure.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        #region Lookups 
        public virtual DbSet<LK_IdentityType> LK_IdentityTypes { get; set; }
        public virtual DbSet<LK_AttachmentSource> LK_AttachmentSources { get; set; }
        public virtual DbSet<LK_CauseCategory> LK_CauseCategories { get; set; }
        public virtual DbSet<LK_Judgement> LK_Judgements { get; set; }
        public virtual DbSet<LK_Stage> LK_Stages { get; set; }
        public virtual DbSet<LK_ClassificationTypeELibraries> LK_ClassificationTypeELibraries { get; set; }
        public virtual DbSet<LK_TypeJudiciary> LK_TypeJudiciary { get; set; }
        public virtual DbSet<LK_Organization> LK_Organization { get; set; }
        #endregion
        #region Cause 
        public virtual DbSet<Cause> Causes { get; set; }
        public virtual DbSet<CauseHistory> CauseHistorys { get; set; }
        public virtual DbSet<CauseStage> CauseStages { get; set; }
        public virtual DbSet<Litigant> Litigants { get; set; }
        public virtual DbSet<JudgementGround> JedgementGrounds { get; set; }
        public virtual DbSet<CauseAssign> CauseAssigns { get; set; }
        public virtual DbSet<JudgementRequirements> JudgementRequirements { get; set; }
        public virtual DbSet<CauseLawyer> CauseLawyers { get; set; }
        public virtual DbSet<CauseComment> CauseComments { get; set; }
        public virtual DbSet<CauseCommentAttchment> CauseCommentAttchments { get; set; }
        public virtual DbSet<JudgmentReference> JudgmentReferences { get; set; }

        #endregion
        #region Attachments
        public virtual DbSet<CauseStageAttachment> CauseStageAttachments { get; set; }
        public virtual DbSet<JudgementGroundAttachment> JudgementGroundAttachments { get; set; }
        public virtual DbSet<SessionAttachment> SessionAttachments { get; set; }
        public virtual DbSet<CauseStageNoteAttachment> CauseStageNoteAttachments { get; set; }
        #endregion

        #region Sessions
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionNote> SessionNotes { get; set; }
        public virtual DbSet<SessionAssignee> SessionAssignees { get; set; }
        #endregion

        #region E-Library
        public virtual DbSet<ELibrary> ELibraries { get; set; }

        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}
