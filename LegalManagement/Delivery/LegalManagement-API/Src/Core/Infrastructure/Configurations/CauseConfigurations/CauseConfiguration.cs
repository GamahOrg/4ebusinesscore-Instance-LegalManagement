using _4EPlatform.Domain.Models.CasuseModels;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.CauseConfigurations
{
    public class CauseConfiguration : IEntityTypeConfiguration<Cause>
    {
        public void Configure(EntityTypeBuilder<Cause> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);

            
        }
    }
}
