using _4EPlatform.Domain.Models.Attachments;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.AttachmentConfigurations
{
    public class SessionAttachmentConfigurations: IEntityTypeConfiguration<SessionAttachment>
    {
        public void Configure(EntityTypeBuilder<SessionAttachment> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);
            builder.HasQueryFilter(e => e.State == State.NotDeleted);
            builder.HasOne(x => x.CauseStage).WithMany(x => x.SessionAttachments).HasForeignKey
                (x => x.CauseStageId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
