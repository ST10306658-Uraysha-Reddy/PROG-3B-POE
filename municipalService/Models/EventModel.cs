using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace municipalService.Models
{
    public class EventModel
    {
        public required string Title { get; set; }
        public required string Category { get; set; }
        public DateTime Date { get; set; }
        public required string Description { get; set; }
    }
}
