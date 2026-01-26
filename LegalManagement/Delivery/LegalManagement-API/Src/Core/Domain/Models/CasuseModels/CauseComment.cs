

namespace _4EPlatform.Domain.Models.CasuseModels
{
    public class CauseComment : AuditEntity<Guid>
    {
        public Guid CauseId { get; set; }
        public virtual Cause Cause { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<CauseCommentAttchment> CauseCommentAttchments { get; set; } = new HashSet<CauseCommentAttchment>();
    }
}
