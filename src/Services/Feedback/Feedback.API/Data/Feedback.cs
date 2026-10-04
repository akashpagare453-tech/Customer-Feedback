using System.ComponentModel.DataAnnotations;

namespace Feedback.API.Data;

public class CustomerFeedback
{
    public Guid Id { get; set; }
    
    public Guid CustomerId { get; set; } // From JWT
    
    public string StoreId { get; set; }
    
    public string Content { get; set; }
    
    public int Rating { get; set; }
    
    public DateTime SubmittedAt { get; set; }
    
    public FeedbackStatus Status { get; set; }
}

public enum FeedbackStatus
{
    Received,
    Processed
}
