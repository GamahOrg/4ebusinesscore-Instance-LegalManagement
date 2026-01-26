using _4EPlatform.Domain.Models.CasuseModels;

namespace _4EPlatform.Domain.Models.Lookups
{
    public class LK_TypeJudiciary : AuditEntity<int>    
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public virtual ICollection<Cause> Causes { get; set; } = new HashSet<Cause>();
    }
}
