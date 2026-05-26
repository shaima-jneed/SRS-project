using Xunit;
using MathLibrary;

namespace MathLibrary.Tests;

public class CalculatorTests
{
    // الاختبار 1: حالة الاسم الفارغ
    [Fact]
    public void InitiateCheck_EmptyStudentName_ReturnsError()
    {
        var request = new TranscriptRequest();
        var result = request.InitiateCheck(false, "");
        Assert.Equal("Error: Student name cannot be empty.", result);
    }

    // الاختبار 2: حالة الطالب المعاقب
    [Fact]
    public void InitiateCheck_HasActivePenalty_ReturnsDenied()
    {
        var request = new TranscriptRequest();
        var result = request.InitiateCheck(true, "Douaa");
        Assert.Equal("Request Denied: Douaa has active disciplinary penalties.", result);
    }

    // الاختبار 3: حالة الطالب السليم (النجاح)
    [Fact]
    public void InitiateCheck_NoActivePenalty_ReturnsApproved()
    {
        var request = new TranscriptRequest();
        var result = request.InitiateCheck(false, "Douaa");
        Assert.Equal("Request Approved: Transcript for Douaa is ready.", result);
    }
}