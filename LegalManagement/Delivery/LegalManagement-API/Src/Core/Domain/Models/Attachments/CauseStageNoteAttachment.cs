using _4EPlatform.Domain.Models.SessionModels;

namespace _4EPlatform.Domain.Models.Attachments
{
    public class CauseStageNoteAttachment : AuditEntity<Guid>
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string? AttchmentName { get; set; }
        public Guid SessionNoteId { get; set; }
        public virtual SessionNote SessionNote { get; set; }
        public int LK_AttachmentSourceId { get; set; }
        public virtual LK_AttachmentSource AttachmentSource { get; set; }
    }
}
