namespace municipalService.Models
{
    public class ServiceRequest
    {
        public required string ID { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; } // Pending, In Progress, Resolved
        public int Progress { get; set; }  // 0–100%
        public int Priority { get; set; }  // 1 = High, 2 = Medium, 3 = Low
        public DateTime SubmittedAt { get; set; }
    }
}
