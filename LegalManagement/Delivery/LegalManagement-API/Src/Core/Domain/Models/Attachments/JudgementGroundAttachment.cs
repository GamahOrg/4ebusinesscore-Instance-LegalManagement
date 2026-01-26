using _4EPlatform.Domain.Models.CasuseModels;

namespace _4EPlatform.Domain.Models.Attachments
{
    public class JudgementGroundAttachment : AuditEntity<Guid>
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string? AttchmentName { get; set; }
        public Guid JedgementGroundId { get; set; }
        public virtual JudgementGround JedgementGround { get; set; }
    }
}
