using _4EPlatform.Domain.Models.CasuseModels;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.CauseConfigurations
{
    public class CauseAssignConfigurations : IEntityTypeConfiguration<CauseAssign>
    {
        public void Configure(EntityTypeBuilder<CauseAssign> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);
        }
    }
}
