using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models.CasuseModels
{
    public class JudgementRequirements:AuditEntity<Guid>
    {
        public Guid JudgementGroundId { get; set; }
        public virtual JudgementGround JudgementGround { get; set; }
        public string Text { get; set; } 
        public RequirementType RequirementType { get; set; }
    }
   
}
