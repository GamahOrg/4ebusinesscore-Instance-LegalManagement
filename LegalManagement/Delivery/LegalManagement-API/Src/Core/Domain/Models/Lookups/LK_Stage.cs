using _4EPlatform.Domain.Models.CasuseModels;

namespace _4EPlatform.Domain.Models.Lookups
{
    public class LK_Stage : AuditEntity<int>
    {
        public int CauseRank {  get; set; } 
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsStudy { get; set; } = false;
        public virtual ICollection<CauseStage> CauseStage { get; set; } = new HashSet<CauseStage>();
    }
}
