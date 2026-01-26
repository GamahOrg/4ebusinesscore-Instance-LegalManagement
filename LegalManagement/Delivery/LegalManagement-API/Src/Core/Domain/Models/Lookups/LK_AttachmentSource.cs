namespace _4EPlatform.Domain.Models.Lookups
{
    public class LK_AttachmentSource : AuditEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public virtual ICollection<SessionAttachment> SessionAttachments { get; set; } = new HashSet<SessionAttachment>();
        public virtual ICollection<CauseStageAttachment> CauseStageAttachments { get; set; } = new HashSet<CauseStageAttachment>();
    }
}
