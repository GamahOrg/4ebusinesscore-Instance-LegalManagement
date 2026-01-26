

using _4EPlatform.Domain.Models.SessionModels;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.SessionConfigurations
{
    public class SessionAssigneeConfigurations: IEntityTypeConfiguration<SessionAssignee>
    {
        public void Configure(EntityTypeBuilder<SessionAssignee> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);
            builder.HasQueryFilter(e => e.State == State.NotDeleted);
            builder.HasOne(x => x.CauseStage).WithMany(x => x.SessionAssignees).HasForeignKey
                (x => x.CauseStageId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
