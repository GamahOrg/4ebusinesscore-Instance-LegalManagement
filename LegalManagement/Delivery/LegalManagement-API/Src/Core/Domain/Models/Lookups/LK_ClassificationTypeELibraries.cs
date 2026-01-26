using _4EPlatform.Domain.Models.ELibraryModels;

namespace _4EPlatform.Domain.Models.Lookups
{
    public class LK_ClassificationTypeELibraries : AuditEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public virtual ICollection<ELibrary> ELibraries { get; set; } = new HashSet<ELibrary>();
    }
}
