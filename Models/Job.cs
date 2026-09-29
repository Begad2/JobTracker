
namespace JobTracker.Api.Models;
public class Job
{
    public int Id { set; get; }

    public string Company { set; get; } = string.Empty;

    public string Position { set; get; } = string.Empty;

    public string Location { set; get; } = string.Empty;

    public string Url { set; get; } = string.Empty;

    public decimal? Salary { set; get; }

    public JobStatus Status { set; get; }

    public DateTime? AppliedAt { set; get; }

    public string Note { set; get; } = string.Empty;

    public DateTime CreatedAt { set; get; }
}

public enum JobStatus
{
    Saved,
    Applied,
    Interviewed,
    Rejected,
    Offer,
    Accepted,
    Withdrawn
}