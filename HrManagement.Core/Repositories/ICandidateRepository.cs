using HrManagement.Core.ModelEntities.Candidate;

namespace HrManagement.Core.Repositories
{
    public interface ICandidateRepository
    {
        Task<int> AddCandidate(CandidateInfo objCandidateInfo);
        Task<CandidateInfo> GetUser(string emailAddress);
        Task<int> UpdateCandidate(CandidateInfo objCandidateInfo);
    }
}
