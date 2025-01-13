using HrManagement.Application.Commands;

namespace HrManagement.UnitTest.MockData
{
    public class CandidateInfoMockData
    {
        public static AddUpdateCandidateCommand GetAddUpdateCandidateInfo()
        {
            return new AddUpdateCandidateCommand()
            {
                Id = 1,
                FirstName = "Matrika",
                LastName = "Koirala",
                PhoneNumber = "123-456-7890",
                Email = "matrika@gmail.com",
                TimeAvailable = "9 AM - 5 PM",
                LinkedInProfile = "https://www.linkedin.com",
                GitHubProfile = "https://github.com",
                Remarks = "Mock Data for Unit Testing"
            };
        }

    }
}
