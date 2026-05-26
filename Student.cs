namespace MathLibrary;

public enum PenaltyType { WARNING, PROBATION, SUSPENSION }
public enum PenaltyStatus { ACTIVE, EXPIRED, LIFTED }

public class DisciplinaryRecord
{
    public PenaltyType PenaltyType { get; set; }
    public bool IsActive { get; set; }
}

public class Student
{
    private List<DisciplinaryRecord> penalties = new List<DisciplinaryRecord>();

    public void AddPenalty(DisciplinaryRecord record)
    {
        penalties.Add(record);
    }

    public string GetTranscriptStatus()
    {
        if (penalties.Exists(p => p.IsActive && p.PenaltyType == PenaltyType.SUSPENSION))
            return "BLOCKED";

        if (penalties.Exists(p => p.IsActive && p.PenaltyType == PenaltyType.PROBATION))
            return "RESTRICTED";

        if (penalties.Exists(p => p.IsActive && p.PenaltyType == PenaltyType.WARNING))
            return "FLAGGED";

        return "CLEAR";
    }
}