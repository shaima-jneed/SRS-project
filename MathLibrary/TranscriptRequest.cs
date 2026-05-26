using System;

namespace MathLibrary;

public class TranscriptRequest 
{
 
    public string requestId { get; set; }
    public string studentId { get; set; }
    public DateTime requestDate { get; set; }

   
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

/*
CC = D + 1
D = 2
CC = 3
if (string.IsNullOrEmpty(studentName))  شرط if 
if (hasActivePenalty)  شرط if 
*/
