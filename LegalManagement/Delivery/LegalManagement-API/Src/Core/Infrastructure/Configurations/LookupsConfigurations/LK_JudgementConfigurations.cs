
using _4EPlatform.Domain.Models.Lookups;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.LookupsConfigurations
{
    public class LK_JudgementConfigurations: IEntityTypeConfiguration<LK_Judgement>
    {
        public void Configure(EntityTypeBuilder<LK_Judgement> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
