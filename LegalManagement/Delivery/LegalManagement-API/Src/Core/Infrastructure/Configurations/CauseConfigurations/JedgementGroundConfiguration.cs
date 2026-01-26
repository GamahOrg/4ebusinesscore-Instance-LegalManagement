using _4EPlatform.Domain.Models.CasuseModels;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.CauseConfigurations
{
    public class JedgementGroundConfiguration: IEntityTypeConfiguration<JudgementGround>
    {
        public void Configure(EntityTypeBuilder<JudgementGround> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);
            builder.HasOne(x => x.CauseStage).WithMany(x => x.JedgementGrounds).HasForeignKey
               (x => x.CauseStageId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("JudgementGroundReport");
        }
    }
}
