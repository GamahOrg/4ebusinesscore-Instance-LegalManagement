using _4EPlatform.Domain.Models.CasuseModels;

namespace _4EPlatform.Domain.Models.Lookups
{
    public class LK_Organization : AuditEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public virtual ICollection<Litigant> Litigants { get; set; } = new HashSet<Litigant>();
    }
}
