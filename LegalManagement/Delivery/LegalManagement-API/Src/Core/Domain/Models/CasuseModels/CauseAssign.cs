using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models.CasuseModels
{
    public class CauseAssign : AuditEntity<Guid>
    {
        public Guid CauseId { get; set; }
        public virtual Cause Cause { get; set; }
        public AssignationType AssignationType { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CauseLawyerId { get; set; }
        public virtual CauseLawyer? CauseLawyer { get; set; }
    }
}
