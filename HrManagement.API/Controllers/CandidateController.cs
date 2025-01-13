using HrManagement.Application.Commands;
using HrManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HrManagement.API.Controllers
{
    public class CandidateController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator= mediator;
        [HttpPost]
        [Route("AddUpdate")]
        [ProducesResponseType(typeof(CommonResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AddUpdateCandidate(AddUpdateCandidateCommand objAddUpdateCandidateCommand)
        {
            var objCommonResponse = await _mediator.Send(objAddUpdateCandidateCommand);
            if (objCommonResponse == null) { 
                return NotFound();
            }
            return Ok(objCommonResponse);
        }
    }
    
}
