using _4EPlatform.Domain.Models.CasuseModels;

namespace _4EPlatform.Domain.Models.SessionModels
{
    public class Session : AuditEntity<Guid>
    {
        public DateTime SessionDate { get; set; }
        public string CourtName { get; set; }
        public string AreaName { get; set; }
        public string? Location { get; set; }
        public virtual ICollection<SessionAssignee> Assignees { get; set; } = new HashSet<SessionAssignee>();
        public virtual ICollection<SessionAttachment> Attachments { get; set; } = new HashSet<SessionAttachment>();
        public virtual ICollection<SessionNote> SessionNote { get; set; } = new HashSet<SessionNote>();
        public Guid CauseStageId { get; set; }
        public virtual CauseStage CauseStage { get; set; }
        public virtual ICollection<JudgementGround> JedgementGrounds { get; set; } = new HashSet<JudgementGround>();
        public virtual ICollection<JudgmentReference> JudgmentReferences { get; set; } = new HashSet<JudgmentReference>();
    }
}
