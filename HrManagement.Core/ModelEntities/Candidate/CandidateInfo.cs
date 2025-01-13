using HrManagement.Core.ModelEntities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagement.Core.ModelEntities.Candidate
{
    public class CandidateInfo: CommonRequest
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
       

    }
}
