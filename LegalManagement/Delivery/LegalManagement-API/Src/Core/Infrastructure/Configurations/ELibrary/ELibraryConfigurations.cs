using _4EPlatform.Domain.Models.ELibraryModels;


namespace _4EPlatForm.Infrastrucure.Configurations.AttachmentConfigurations
{
    public class ELibraryConfigurations : GenricConfigration<ELibrary>
    {
        public override void Configure(EntityTypeBuilder<ELibrary> builder)
        {
            // builder.HasQueryFilter(e => e.State == State.NotDeleted);


        }
    }
}
