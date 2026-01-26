using _4EPlatform.Domain.Models.SessionModels;
using Domain.Utilities.Enums;


namespace _4EPlatForm.Infrastrucure.Configurations.SessionConfigurations
{
        internal class SessionConfiguration  : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
