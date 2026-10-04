using Microsoft.EntityFrameworkCore;

namespace Feedback.API.Data;

public class FeedbackDbContext : DbContext
{
    public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options)
    {
    }

    public DbSet<CustomerFeedback> Feedbacks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerFeedback>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.StoreId).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Content).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.Rating).IsRequired();
            entity.Property(e => e.SubmittedAt).HasDefaultValueSql("GETUTCDATE()");
        });
    }
}
