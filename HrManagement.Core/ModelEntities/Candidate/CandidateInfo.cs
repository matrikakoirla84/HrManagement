using System.ComponentModel.DataAnnotations;

namespace HrManagement.Core.ModelEntities.Candidate
{
    public class CandidateInfo
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TimeAvailable { get; set; }
        public string LinkedInProfile { get; set; }
        public string GitHubProfile { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTs { get; set; } = DateTime.UtcNow;

    }
}
