using Domain.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace _4EPlatform.Domain.Models.CasuseModels
{
    public class Cause : AuditEntity<Guid>
    {

        public string? CauseNumber { get; set; }
        public string Title { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? CauseDate { get; set; }
        public string IncidentLocation { get; set; }
        public string Subject { get; set; }
        public virtual ICollection<CauseLitigant> CauseLitigants { get; set; } = new HashSet<CauseLitigant>();
        public int LK_CauseCategoryId { get; set; }
        public virtual LK_CauseCategory LK_CauseCategories { get; set; }
        public int? LK_TypeJudiciaryId { get; set; }
        public virtual LK_TypeJudiciary? LK_TypeJudiciary { get; set; }
        public ClientType ClientType { get; set; }
        public virtual ICollection<CauseStage> CauseStages { get; set; } = new HashSet<CauseStage>();
        public CauseStatus causeStatus { get; set; }
        public virtual ICollection<CauseAssign> CauseAssigns { get; set; } = new HashSet<CauseAssign>();
        public virtual ICollection<CauseComment>? CauseComments { get; set; } = new HashSet<CauseComment>();

    }
}
