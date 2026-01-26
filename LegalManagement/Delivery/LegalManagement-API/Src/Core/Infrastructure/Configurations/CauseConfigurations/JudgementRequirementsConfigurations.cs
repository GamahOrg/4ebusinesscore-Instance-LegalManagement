using _4EPlatform.Domain.Models.CasuseModels;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.CauseConfigurations
{
    public class JudgementRequirementsConfigurations : IEntityTypeConfiguration<JudgementRequirements>
    {
        public void Configure(EntityTypeBuilder<JudgementRequirements> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);
        }
    }
}

