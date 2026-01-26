using _4EPlatform.Domain.Models.CasuseModels;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.CauseConfigurations
{
    public class CauseHistoryConfigurations : IEntityTypeConfiguration<CauseHistory>
    {
        public void Configure(EntityTypeBuilder<CauseHistory> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
