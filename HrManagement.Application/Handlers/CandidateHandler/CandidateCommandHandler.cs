using HrManagement.Application.Commands;
using HrManagement.Application.Mappers;
using HrManagement.Application.Responses;
using HrManagement.Core.ModelEntities.Candidate;
using HrManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagement.Application.Handlers.CandidateHandler
{
    public class CandidateCommandHandler(ICandidateRepository candidateRepository) :
        IRequestHandler<AddUpdateCandidateCommand,CommonResponse>
    {
        private readonly ICandidateRepository _candidateRepository= candidateRepository;
        public async Task<CommonResponse> Handle(AddUpdateCandidateCommand command,CancellationToken cancellationToken)
        {
            try
            {
                var returnedEmail = await _candidateRepository.GetUser(command.Email);
                var objCandidateInfo = HrManagementMapper.Mapper.Map<CandidateInfo>(command);

                if (returnedEmail != null) {

                    int id = await _candidateRepository.AddCandidate(objCandidateInfo);
                    if (id > 0)
                    {
                        return new CommonResponse();
                    }
                    else
                    {
                        return new CommonResponse();
                    }
                }
                else
                {
                    int id = await _candidateRepository.UpdateCandidate(objCandidateInfo);
                    if (id > 0)
                    {
                        return new CommonResponse();
                    }
                    else
                    {
                        return new CommonResponse();
                    }
                }

                
            }
            catch
            {
                throw;
            }
        }
    }
}
