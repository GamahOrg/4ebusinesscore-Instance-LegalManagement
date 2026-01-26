using _4EPlatform.Domain.Models.CasuseModels;
using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models.SessionModels
{
    public class SessionAssignee : AuditEntity<Guid>
    {
        public Guid? UserId { get; set; }
        //public string? ExternalLawyer { get; set; }
        public Guid? SessionId { get; set; }
        public Guid? CauseLawyerId { get; set; }
        public virtual CauseLawyer? CauseLawyer { get; set; }
        public virtual Session? Session { get; set; }
        public Guid CauseStageId { get; set; }
        public virtual CauseStage CauseStage { get; set; }
        public AssignationType AssignationType { get; set; }
    }
}
