
using _4EPlatform.Domain.Models.Lookups;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.LookupsConfigurations
{
    public class LK_AttachmentSourceConfigurations: IEntityTypeConfiguration<LK_AttachmentSource>
    {
        public void Configure(EntityTypeBuilder<LK_AttachmentSource> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
