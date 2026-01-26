using _4EPlatform.Domain.Models.Lookups;
using Domain.Utilities.Enums;


namespace _4EPlatForm.Infrastrucure.Configurations.LookupsConfigurations
{
    public class LK_CauseCategoryConfigurations: IEntityTypeConfiguration<LK_CauseCategory>
    {
        public void Configure(EntityTypeBuilder<LK_CauseCategory> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
