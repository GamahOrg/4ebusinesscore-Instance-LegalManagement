
using _4EPlatform.Domain.Models.SessionModels;

namespace _4EPlatform.Domain.Models.CasuseModels
{
    public class JudgmentReference : AuditEntity<Guid>
        // الجدول الخاص بحيثيات الحكم
    {
        public string JudgmentNumber { get; set; }
        public string JudgmentDocument { get; set; }
        public Guid SessionId { get; set; }
        public virtual Session Session { get; set; }
        public Guid CauseStageId { get; set; }
        public virtual CauseStage CauseStage { get; set; }

    }
}
