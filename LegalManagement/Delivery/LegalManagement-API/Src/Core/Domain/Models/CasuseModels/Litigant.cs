using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models.CasuseModels
{
    public class Litigant : AuditEntity<Guid>
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public int LK_IdentityTypeId { get; set; }
        public virtual LK_IdentityType LK_IdentityType { get; set; }
        public int? LK_OrganizatioId { get; set; }
        public virtual LK_Organization? LK_Organization { get; set; }
        public string IdentityNumber { get; set; }
        public virtual LitigantStatus LitigantStatus { get; set; }
        public virtual ICollection<CauseLitigant> CauseLitigants { get; set; } = new HashSet<CauseLitigant>();
    }
}
