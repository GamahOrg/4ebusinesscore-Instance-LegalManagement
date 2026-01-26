using _4EPlatform.Domain.Models.Attachments;


namespace _4EPlatForm.Infrastrucure.Configurations.AttachmentConfigurations
{
    public class CauseStageAttachmentConfigurations: GenricConfigration<CauseStageAttachment>
    {
        public override void Configure(EntityTypeBuilder<CauseStageAttachment> builder)
        {
           // builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
