using _4EPlatform.Domain.Models.CasuseModels;
using Domain.Utilities.Enums;


namespace _4EPlatForm.Infrastrucure.Configurations.CauseConfigurations
{
    public class LitigantConfigurations: IEntityTypeConfiguration<Litigant>
    {
        public void Configure(EntityTypeBuilder<Litigant> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
