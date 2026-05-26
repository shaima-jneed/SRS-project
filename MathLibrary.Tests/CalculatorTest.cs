using Xunit;
using MathLibrary;

namespace MathLibrary.Tests;

public class CalculatorTests
{
    [Fact]
    public void InitiateCheck_EmptyStudentName_ReturnsError()
    {
        var request = new TranscriptRequest();
        var result = request.InitiateCheck(false, "");
        Assert.Equal("Error: Student name cannot be empty.", result);
    }

    [Fact]
    public void InitiateCheck_HasActivePenalty_ReturnsDenied()
    {
        var request = new TranscriptRequest();
        var result = request.InitiateCheck(true, "Douaa");
        Assert.Equal("Request Denied: Douaa has active disciplinary penalties.", result);
    }

    [Fact]
    public void InitiateCheck_NoActivePenalty_ReturnsApproved()
    {
        var request = new TranscriptRequest();
        var result = request.InitiateCheck(false, "Douaa");
        Assert.Equal("Request Approved: Transcript for Douaa is ready.", result);
    }
}
