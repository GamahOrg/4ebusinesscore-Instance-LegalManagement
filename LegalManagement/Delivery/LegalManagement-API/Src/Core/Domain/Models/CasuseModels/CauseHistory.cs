namespace _4EPlatform.Domain.Models.CasuseModels
{
    public class CauseHistory : AuditEntity<Guid>
    {
        public Guid RecordId { get; set; }
        public Guid? CauseStageId { get; set; }
        public virtual CauseStage? CauseStage { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
    }
}
