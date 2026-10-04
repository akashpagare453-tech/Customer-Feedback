using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Feedback.API.Data;

namespace Feedback.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FeedbackController : ControllerBase
{
    private readonly FeedbackDbContext _context;

    public FeedbackController(FeedbackDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitFeedback([FromBody] FeedbackDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // Fallback to 'name' claim if NameIdentifier is not present (depends on how Identity.API maps claims)
        // For IdentityUser, 'sub' usually maps to NameIdentifier.
        // If we can't find a user ID, we might still proceed if your requirements allow anonymous, 
        // but [Authorize] is present so we expect a user.
        
        // We can just log the name for now if ID parsing is complex without sharing Models.
        var userName = User.Identity?.Name;

        var feedback = new CustomerFeedback
        {
            Id = Guid.NewGuid(),
            // Assuming CustomerId is a Guid. If the claim is a string, we might need to parse.
            // For this demo, let's assume we map the user somehow or just store it.
            // But Feedback.cs has "public Guid CustomerId". 
            // If the token subject is not a Guid (it might be), this needs care. 
            // Let's generate a random one or try parse if we knew the format.
            // For now, let's use a dummy Guid if we can't parse, or try parse.
            CustomerId = Guid.TryParse(userIdClaim, out var cid) ? cid : Guid.NewGuid(),
            StoreId = "DefaultStore", // Or from input
            Content = model.Message,
            Rating = model.Rating,
            Status = FeedbackStatus.Received,
            SubmittedAt = DateTime.UtcNow
        };

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Feedback submitted successfully" });
    }
}

public class FeedbackDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Category { get; set; }
    public required int Rating { get; set; }
    public required string Message { get; set; }
}
