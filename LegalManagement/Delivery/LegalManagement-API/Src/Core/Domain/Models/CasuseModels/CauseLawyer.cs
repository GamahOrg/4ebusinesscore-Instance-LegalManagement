using _4EPlatform.Domain.Models.SessionModels;
using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models.CasuseModels
{
    public class CauseLawyer : AuditEntity<Guid>
    {
        public LitigantStatus litigantStatus { get; set; }
        public bool IsInternal { get; set; }
        public Guid? UserId { get; set; }
        public LawyerStatus lawyerStatus { get; set; }
        public string? LawyerName { get; set; }
        public string? Phone { get; set; }
        public LawyerType lawyerType { get; set; }
        public virtual ICollection<SessionAssignee> SessionAssignees { get; set; } = new HashSet<SessionAssignee>();
        public virtual ICollection<CauseAssign> CauseAssigns { get; set; } = new HashSet<CauseAssign>();

    }
}
