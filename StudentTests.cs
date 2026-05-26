using Xunit;
using MathLibrary;

namespace MathLibrary.Tests;

public class StudentTests
{
    [Fact]
    public void GetTranscriptStatus_NoPenalties_ReturnsClear()
    {
        // Arrange
        var student = new Student();

        // Act
        string result = student.GetTranscriptStatus();

        // Assert
        Assert.Equal("CLEAR", result);
    }

    [Fact]
    public void GetTranscriptStatus_ActiveWarning_ReturnsFlagged()
    {
        // Arrange
        var student = new Student();
        student.AddPenalty(new DisciplinaryRecord
        {
            PenaltyType = PenaltyType.WARNING,
            IsActive = true
        });

        // Act
        string result = student.GetTranscriptStatus();

        // Assert
        Assert.Equal("FLAGGED", result);
    }

    [Fact]
    public void GetTranscriptStatus_ActiveProbation_ReturnsRestricted()
    {
        // Arrange
        var student = new Student();
        student.AddPenalty(new DisciplinaryRecord
        {
            PenaltyType = PenaltyType.PROBATION,
            IsActive = true
        });

        // Act
        string result = student.GetTranscriptStatus();

        // Assert
        Assert.Equal("RESTRICTED", result);
    }

    [Fact]
    public void GetTranscriptStatus_ActiveSuspension_ReturnsBlocked()
    {
        // Arrange
        var student = new Student();
        student.AddPenalty(new DisciplinaryRecord
        {
            PenaltyType = PenaltyType.SUSPENSION,
            IsActive = true
        });

        // Act
        string result = student.GetTranscriptStatus();

        // Assert
        Assert.Equal("BLOCKED", result);
    }

    [Fact]
    public void GetTranscriptStatus_ExpiredPenalty_ReturnsClear()
    {
        // Arrange
        var student = new Student();
        student.AddPenalty(new DisciplinaryRecord
        {
            PenaltyType = PenaltyType.SUSPENSION,
            IsActive = false
        });

        // Act
        string result = student.GetTranscriptStatus();

        // Assert
        Assert.Equal("CLEAR", result);
    }

    [Fact]
    public void GetTranscriptStatus_SuspensionAndWarning_ReturnsBlocked()
    {
        // Arrange
        var student = new Student();
        student.AddPenalty(new DisciplinaryRecord
        {
            PenaltyType = PenaltyType.WARNING,
            IsActive = true
        });
        student.AddPenalty(new DisciplinaryRecord
        {
            PenaltyType = PenaltyType.SUSPENSION,
            IsActive = true
        });

        // Act
        string result = student.GetTranscriptStatus();

        // Assert
        Assert.Equal("BLOCKED", result);
    }
}
// cc = D + 1 = 6 + 1 = 7