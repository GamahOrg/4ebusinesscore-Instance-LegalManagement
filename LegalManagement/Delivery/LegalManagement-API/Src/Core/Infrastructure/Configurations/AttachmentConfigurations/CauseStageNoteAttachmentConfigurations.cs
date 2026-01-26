using _4EPlatform.Domain.Models.Attachments;


namespace _4EPlatForm.Infrastrucure.Configurations.AttachmentConfigurations
{
    public class CauseStageNoteAttachmentConfigurations : GenricConfigration<CauseStageNoteAttachment>
    {
        public override void Configure(EntityTypeBuilder<CauseStageNoteAttachment> builder)
        {
            // builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
