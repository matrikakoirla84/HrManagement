using HrManagement.Core.ModelEntities.Candidate;
using HrManagement.Core.Repositories;
using HrManagement.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagement.Infrastructure.Repositories
{
    public class CandidateRepository(EntityFrameworkDbContext entityFrameworkDbContext) : ICandidateRepository
    {
        private readonly EntityFrameworkDbContext _entityFrameworkDbContext= entityFrameworkDbContext;
        public async Task<int> AddCandidate(CandidateInfo objCandidateInfo)
        {
            try
            {
                _entityFrameworkDbContext.CandidateInfo.Add(objCandidateInfo);
                await _entityFrameworkDbContext.SaveChangesAsync();
                return objCandidateInfo.Id;
            }
            catch
            {
                throw;
            }
        }     
        public async Task<int> UpdateCandidate(CandidateInfo objCandidateInfo)
        {
            try
            {
                // Check if the entity is already being tracked
                var trackedEntity = await _entityFrameworkDbContext.CandidateInfo.FindAsync(objCandidateInfo.Id);
                if (trackedEntity != null)
                {
                    // Update the properties of the tracked entity
                    _entityFrameworkDbContext.Entry(trackedEntity).CurrentValues.SetValues(objCandidateInfo);
                }
                else
                {
                    // Attach the entity if it's not being tracked
                    _entityFrameworkDbContext.CandidateInfo.Update(objCandidateInfo);
                }
                // Save changes
                await _entityFrameworkDbContext.SaveChangesAsync();
                return objCandidateInfo.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating candidate", ex);
            }
        }
        public async Task<CandidateInfo> GetUser(string emailAddress)
        {
            return await _entityFrameworkDbContext.CandidateInfo.FirstOrDefaultAsync(x => x.Email == emailAddress);
        }
    }
}
