    using _4EPlatform.Domain.Models.CasuseModels;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.CauseConfigurations
{
    public class CauseStageConfigurations: IEntityTypeConfiguration<CauseStage>
    {
        public void Configure(EntityTypeBuilder<CauseStage> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
