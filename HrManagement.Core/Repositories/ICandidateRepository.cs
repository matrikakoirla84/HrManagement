using HrManagement.Core.ModelEntities.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagement.Core.Repositories
{
    public interface ICandidateRepository
    {
        Task<int> AddCandidate(CandidateInfo objCandidateInfo);
        Task<CandidateInfo> GetUser(string emailAddress);
        Task<int> UpdateCandidate(CandidateInfo objCandidateInfo);
    }
}
