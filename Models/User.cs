using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeLiotAssessment.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; } 
        public DateTime DateCreated { get; set; }
        public DateTime DateLastSeen { get; set; }
    }
}
