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
                var objExistingCandidateInfo = await _candidateRepository.GetUser(command.Email);
                var objCandidateInfo = HrManagementMapper.Mapper.Map<CandidateInfo>(command);

                if (objExistingCandidateInfo is null) {

                    int id = await _candidateRepository.AddCandidate(objCandidateInfo);
                    if (id > 0)
                    {
                        return new CommonResponse()
                        {
                            Success=true,
                            Code="000",
                            Message="Successfully Added"
                        };
                    }
                    else
                    {
                        return new CommonResponse()                        
                        {
                            Success=false,
                            Code="111",
                            Message="Unable to Add Candidate Details"
                        };
                        
                    }
                }
                else
                {
                    objCandidateInfo.Id = objExistingCandidateInfo.Id;
                    int id = await _candidateRepository.UpdateCandidate(objCandidateInfo);
                    if (id > 0)
                    {
                        return new CommonResponse()
                        {
                            Success = true,
                            Code = "000",
                            Message = "Successfully Updated"
                        };
                    }
                    else
                    {
                        return new CommonResponse()
                        {
                            Success = false,
                            Code = "222",
                            Message = "Unable to Update Candidate Details"
                        };

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
