namespace DisciplinarySystem;

public enum PenaltyStatus
{
    ACTIVE,
    EXPIRED,
    LIFTED
}

public class DisciplinaryRecord
{
    public string RecordId { get; set; }
    public string PenaltyType { get; set; }
    public PenaltyStatus Status { get; set; }
    public DateTime EndDate { get; set; }

    
    public bool IsActive()
    {
        if (Status == PenaltyStatus.ACTIVE && EndDate > DateTime.Now)
        {
            return true;
        }
        return false;
    }
}
//cc= D+1 = 2+1 = 3 
// مستوى التعقيد بسيط وسهل الاختبار