namespace municipalService.Models
{
    public class ServiceRequest
    {
        public required string ID { get; set; }
        public string? Description { get; set; }
        public required string Status { get; set; } 
        public int Progress { get; set; } 
        public DateTime SubmittedAt { get; set; }
    }
}
