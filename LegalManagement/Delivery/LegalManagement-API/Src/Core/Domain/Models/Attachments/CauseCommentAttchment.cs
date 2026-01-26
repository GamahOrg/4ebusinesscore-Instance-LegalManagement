

using _4EPlatform.Domain.Models.CasuseModels;

namespace _4EPlatform.Domain.Models.Attachments
{
    public class CauseCommentAttchment : AuditEntity<Guid>
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Guid CauseCommentId { get; set; }
        public virtual CauseComment CauseComment { get; set; }
    }
}
