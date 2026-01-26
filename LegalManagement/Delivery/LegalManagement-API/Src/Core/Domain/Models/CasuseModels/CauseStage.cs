using _4EPlatform.Domain.Models.SessionModels;
using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models.CasuseModels
{
    public class CauseStage : AuditEntity<Guid>
    {
        public string? CauseStageNumber { get; set; }
        public Guid CauseId { get; set; }
        public virtual Cause Cause { get; set; }
        public int LK_StageId { get; set; }
        public virtual LK_Stage LK_Stage { get; set; }
        public CauseStageStatus Status { get; set; }
        public LitigantStatus Redirector { get; set; } // المتسبب ف الانتقال لمرحلة
        public virtual ICollection<CauseStageAttachment> CauseStageAttachment { get; set; } = new HashSet<CauseStageAttachment>();
        public virtual ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
        public virtual ICollection<CauseHistory> CauseHistories { get; set; } = new HashSet<CauseHistory>();
        public virtual ICollection<SessionNote> SessionNotes { get; set; } = new HashSet<SessionNote>();
        public virtual ICollection<SessionAssignee> SessionAssignees { get; set; } = new HashSet<SessionAssignee>();
        public virtual ICollection<JudgementGround> JedgementGrounds { get; set; } = new HashSet<JudgementGround>();
        public virtual ICollection<SessionAttachment> SessionAttachments { get; set; } = new HashSet<SessionAttachment>();
        public virtual ICollection<JudgmentReference> JudgmentReferences { get; set; } = new HashSet<JudgmentReference>();

        public Guid? UserId { get; set; }
    }
}
