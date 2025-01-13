using AutoMapper;
using HrManagement.Application.Commands;
using HrManagement.Core.ModelEntities.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
