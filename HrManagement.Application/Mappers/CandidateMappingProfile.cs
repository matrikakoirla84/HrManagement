using AutoMapper;
using HrManagement.Application.Commands;
using HrManagement.Core.ModelEntities.Candidate;

namespace HrManagement.Application.Mappers
{
    public class CandidateMappingProfile : Profile
    {
        public CandidateMappingProfile()
        {
             CreateMap<AddUpdateCandidateCommand, CandidateInfo>().ReverseMap();
        }
    }
}
