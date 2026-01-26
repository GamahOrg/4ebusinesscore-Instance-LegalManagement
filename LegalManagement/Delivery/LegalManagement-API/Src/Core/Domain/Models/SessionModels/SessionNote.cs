using _4EPlatform.Domain.Models.CasuseModels;

namespace _4EPlatform.Domain.Models.SessionModels
{
    public class SessionNote : AuditEntity<Guid>
    {
        public string Description { get; set; }
        public Guid? SessionId { get; set; }
        public virtual Session? Session { get; set; }
        public Guid CauseStageId { get; set; }
        public virtual CauseStage CauseStage { get; set; }
        public virtual ICollection<CauseStageNoteAttachment> CauseStageNoteAttachments { get; set; } = new HashSet<CauseStageNoteAttachment>();
    }
}
