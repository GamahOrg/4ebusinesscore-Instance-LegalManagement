

using _4EPlatform.Domain.Models.Attachments;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.AttachmentConfigurations
{
    public class JudgementGroundAttachmentConfigurations : IEntityTypeConfiguration<JudgementGroundAttachment>
    {
        public void Configure(EntityTypeBuilder<JudgementGroundAttachment> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);

            builder.HasQueryFilter(e => e.State == State.NotDeleted);
            //builder.HasOne(x => x.CauseStage).WithMany(x => x.JudgementGroundAttachments).HasForeignKey
            //    (x => x.CauseStageId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
