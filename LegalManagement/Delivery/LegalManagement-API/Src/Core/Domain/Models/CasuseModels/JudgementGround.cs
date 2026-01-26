using _4EPlatform.Domain.Models.SessionModels;
using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models.CasuseModels
{
    
    public class JudgementGround : AuditEntity<Guid>
    {
        //الجدول خاص بتقرير الجلسه وليس حيثيات الحكم
        public int LK_JudgementId { get; set; }
        public virtual LK_Judgement LK_Judgement { get; set; }
        public virtual SessionJedgementStatus SessionJedgementStatus { get; set; }
        //public string ClientRequirments { get; set; }
        //public string OpponentRequirements { get; set; }
        public virtual ICollection<JudgementGroundAttachment> Judgements { get; set; } = new HashSet<JudgementGroundAttachment>();
        public virtual ICollection<JudgementRequirements> JudgementRequirements { get; set; } = new HashSet<JudgementRequirements>();

        public Guid SessionId { get; set; }
        public virtual Session Session { get; set; }
        public string JudgementStatement { get; set; }
        public Guid CauseStageId { get; set; }
        public string TitleJudement { get; set; }
        public virtual CauseStage CauseStage { get; set; }
        public DateTime? NextSession { get; set; }

    }
}
