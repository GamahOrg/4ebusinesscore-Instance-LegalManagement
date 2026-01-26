namespace Domain.Utilities.Enums
{
    public enum State
    {
        NotDeleted,
        Deleted
    }
    public enum StatusEnum
    {
        FailedToSave,
        SavedSuccessfully,
        Exception,
        Success,
        Failed,
        FailedToFindTheObject,
        AlreadyExisting
    }


    public enum EnumStudy
    {
        Draft,
        InPath,
        Rejected,
        Approved
    }
    public enum EnumSession
    {

        Draft,
        InPath,
        Rejected,
        Approved,
        Finished,
        Sent
    }
    public enum LawyerType
    {
        Person = 1,
        Office = 2
    }
    public enum LawyerStatus
    {
        Active = 1,
        Banned = 2
    }
    public enum LitigantStatus
    {
        Opponent = 1,
        Client = 2
    }
    public enum ClientType
    {
        Plaintiff = 1, // مندعي
        Defendant = 2 // مدعي عليه
    }
    public enum CauseStageStatus
    {
        IsActive = 1, // منظورة
        Judgement = 2, // منتهية
        Pending = 3, // معلقة
        CrossedOut = 4, // مشطوبة
    }
    public enum CauseStatus
    {
        NewCause = 1, //جديدة
        InProgress, // منظورة) فالجلسات)
        Judgement, // منتهية
        Pending, // معلقة
        CrossedOut //مشطوبة
    }
    public enum SessionJedgementStatus
    {
        AgainstTheAuthority = 1, //ضد الهيئة
        ForTheAuthority, // لصالح الهيئة
        EndTheDispute // إنهاء النزاع
    }
    public enum AssignationType
    {
        Owner = 1, // مدير عام الإدارة
        Supervisor = 2, //مدير الإدارة
        Lawyers = 3, // مستشار
        DataEntry = 4,
        Consultative = 5, // (استشاري (اصحاب الاختصاص
    }
    public enum RequirementType
    {
        Opponent = 1,
        Client = 2
    }
    public enum AttachmentType
    {
        Unknown = 0,
        SessionAttachment = 1,
        CauseAttachment = 2,
        SessionNoteAttachment = 3
    }
}