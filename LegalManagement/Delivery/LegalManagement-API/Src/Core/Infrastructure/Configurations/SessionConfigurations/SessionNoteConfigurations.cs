

using _4EPlatform.Domain.Models.SessionModels;
using Domain.Utilities.Enums;

namespace _4EPlatForm.Infrastrucure.Configurations.SessionConfigurations
{
    public class SessionNoteConfigurations: IEntityTypeConfiguration<SessionNote>
    {
        public void Configure(EntityTypeBuilder<SessionNote> builder)
        {
            builder.HasQueryFilter(e => e.State == State.NotDeleted);

            builder.HasQueryFilter(e => e.State == State.NotDeleted);
            builder.HasOne(x => x.CauseStage).WithMany(x => x.SessionNotes).HasForeignKey
                (x => x.CauseStageId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
