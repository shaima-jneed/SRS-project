using Xunit;
using DisciplinarySystem;
using System;

namespace DisciplinarySystem.Tests;

public class DisciplinaryRecordTests
{
    [Fact]
    public void IsActive_StatusIsActiveAndFutureDate_ReturnsTrue()
    {
        // Arrange
        var record = new DisciplinaryRecord
        {
            Status = PenaltyStatus.ACTIVE,
            EndDate = DateTime.Now.AddDays(5) // تاريخ مستقبلي
        };

        // Act
        bool result = record.IsActive();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsActive_StatusIsExpired_ReturnsFalse()
    {
        // Arrange
        var record = new DisciplinaryRecord
        {
            Status = PenaltyStatus.EXPIRED,
            EndDate = DateTime.Now.AddDays(5)
        };

        // Act
        bool result = record.IsActive();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsActive_StatusIsLifted_ReturnsFalse()
    {
        // Arrange
        var record = new DisciplinaryRecord
        {
            Status = PenaltyStatus.LIFTED,
            EndDate = DateTime.Now.AddDays(5)
        };

        // Act
        bool result = record.IsActive();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsActive_StatusActiveButPastDate_ReturnsFalse()
    {
        // Arrange
        var record = new DisciplinaryRecord
        {
            Status = PenaltyStatus.ACTIVE,
            EndDate = DateTime.Now.AddDays(-2) // تاريخ قديم منتهي
        };

        // Act
        bool result = record.IsActive();

        // Assert
        Assert.False(result);
    }
}