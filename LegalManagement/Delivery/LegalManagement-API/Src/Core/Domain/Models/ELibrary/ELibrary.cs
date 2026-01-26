namespace _4EPlatform.Domain.Models.ELibraryModels
{
    public class ELibrary:AuditEntity<Guid>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string? Url { get; set; }        
        public string ImagePath { get; set; }
        public string? ImageName { get; set; }
        public string FilePath { get; set; }
        public string? FileName { get; set; }
        public int? LK_ClassificationTypeELibraryId { get; set; }
        public virtual LK_ClassificationTypeELibraries? LK_ClassificationTypeELibrary { get; set; }

    }
}
