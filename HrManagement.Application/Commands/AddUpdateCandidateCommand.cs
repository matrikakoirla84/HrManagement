using HrManagement.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HrManagement.Application.Commands
{
    public class AddUpdateCandidateCommand:IRequest<CommonResponse>
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string TimeAvailable { get; set; }
        public string LinkedInProfile {  get; set; }
        public string GitHubProfile {  get; set; }
        public string Remarks {  get; set; }
    }
}
