using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace municipalService.Models
{
    public class ReportFormModel
    {
        [Key]
        public int ReportId { get; set; }

        
        public required string Description { get; set; }

        
        public required string Location { get; set; }

        
        public required string Category { get; set; }

        [NotMapped]
        public IFormFile? FileUpload { get; set; } // For the uploaded image
        public string? FilePath { get; set; }

        public required string RName { get; set; }
        public required string Rnum { get; set; }

        public string Reference { get; set; } = string.Empty;

    }
}
