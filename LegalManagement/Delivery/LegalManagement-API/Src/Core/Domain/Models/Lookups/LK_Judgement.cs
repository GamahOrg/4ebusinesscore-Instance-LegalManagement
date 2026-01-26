using _4EPlatform.Domain.Models.CasuseModels;

namespace _4EPlatform.Domain.Models.Lookups
{
    public class LK_Judgement : AuditEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public virtual ICollection<JudgementGround> JedgementGrounds { get; set; } = new HashSet<JudgementGround>();


    }
}
