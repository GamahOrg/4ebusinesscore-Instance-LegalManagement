using _4EPlatform.Domain.Models.CasuseModels;
using _4EPlatform.Domain.Models.SessionModels;

namespace _4EPlatform.Domain.Models.Attachments
{
    public class SessionAttachment : AuditEntity<Guid>
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string? AttchmentName { get; set; }
        public Guid SessionId { get; set; }
        public virtual Session Session { get; set; }
        public int LK_AttachmentSourceId { get; set; }
        public virtual LK_AttachmentSource AttachmentSource { get; set; }
        public Guid CauseStageId { get; set; }
        public virtual CauseStage CauseStage { get; set; }

    }
}
