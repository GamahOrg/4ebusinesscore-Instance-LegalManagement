namespace _4EPlatform.Domain.Models.CasuseModels
{
    public class CauseLitigant : AuditEntity<Guid>
    {
        public Guid LitigantId { get; set; }
        public virtual Litigant Litigant { get; set; }
        public Guid CauseId { get; set; }
        public virtual Cause Cause { get; set; }
        public string? Compliment { get; set; }
    }
}
