

using _4EPlatform.Domain.Models.Lookups;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.LookupsConfigurations
{
    public class LK_IdentityTypeConfigurations: IEntityTypeConfiguration<LK_IdentityType>
    {
        public void Configure(EntityTypeBuilder<LK_IdentityType> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
