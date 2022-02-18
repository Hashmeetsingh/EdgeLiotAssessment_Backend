using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EdgeLiotAssessment
{
    public class UserDetails
    {
        [Required]
        [JsonPropertyName("user")]
        public int User { get; set; } = 0;

        [Required]
        [JsonPropertyName("userName")] 
        public string? UserName { get; set; } = "xlr8solutions";

        [Required]
        [JsonPropertyName("email")]
        public string? Email { get; set; } = "hello@xlr8solutions.com";

        [Required]
        [JsonPropertyName("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [JsonPropertyName("payload")]
        public string? Payload { get; set; } = "AB004568==";
    }

    public class Userdtls
    {
        [JsonPropertyName("userName")]
        public string? UserName { get; set; }
        [JsonPropertyName("dateLastSeen")]
        public string? DateLastSeen { get; set; }
        [JsonPropertyName("userCount")]
        public int userCount { get; set; } 
    }

    public class ResponseModel 
    {
        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("userdtls")]
        public List<Userdtls>? Userdtls { get; set; }
    }
}