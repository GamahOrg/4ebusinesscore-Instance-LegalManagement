

using _4EPlatform.Domain.Models.CasuseModels;
using Microsoft.EntityFrameworkCore;

namespace _4EPlatForm.Infrastrucure.Configurations.CauseConfigurations
{
    public class JudgmentReferenceConfiguration : IEntityTypeConfiguration<JudgmentReference>
    {
        public void Configure(EntityTypeBuilder<JudgmentReference> builder)
        {
            builder
            .HasOne(j => j.Session)
            .WithMany(s => s.JudgmentReferences)
            .HasForeignKey(j => j.SessionId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
