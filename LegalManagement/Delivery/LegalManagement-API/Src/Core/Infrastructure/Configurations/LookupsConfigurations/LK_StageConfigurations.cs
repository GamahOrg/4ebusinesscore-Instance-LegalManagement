
using _4EPlatform.Domain.Models.Lookups;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.LookupsConfigurations
{
    public class LK_StageConfigurations: IEntityTypeConfiguration<LK_Stage>
    {
        public void Configure(EntityTypeBuilder<LK_Stage> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);
        }
    }
}
