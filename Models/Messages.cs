using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeLiotAssessment.Models
{
    public class Messages
    {
        [Key]
        public int MessageID { get; set; }
        [ForeignKey("userID")]
        public int UserID { get; set; }
        public DateTime ReceivedAt { get; set; }
        public string? Payload { get; set; }
    }
}
