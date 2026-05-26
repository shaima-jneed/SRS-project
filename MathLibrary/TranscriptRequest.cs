using System;

namespace MathLibrary;

public class TranscriptRequest 
{
    // الخصائص المأخوذة تماماً من الـ Class Diagram الخاص بكِ
    public string requestId { get; set; }
    public string studentId { get; set; }
    public DateTime requestDate { get; set; }

    // التعقيد  = 3
   
    public string InitiateCheck(bool hasActivePenalty, string studentName) 
    {
        if (string.IsNullOrEmpty(studentName)) 
        {
            return "Error: Student name cannot be empty."; 
        }

        if (hasActivePenalty) 
        {
            return $"Request Denied: {studentName} has active disciplinary penalties.";
        }
        
        else 
        {
            return $"Request Approved: Transcript for {studentName} is ready.";
        }
    }
}