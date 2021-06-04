using System.Net;
using System.Threading.Tasks;
using AspNetCoreAngularInMemoryPaging.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAngularInMemoryPaging.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{teamId}", Name = "GetTeamByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTeamById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTeamById.Response>> GetById([FromRoute] GetTeamById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Team == null)
            {
                return new NotFoundObjectResult(request.TeamId);
            }

            return response;
        }

        [HttpGet(Name = "GetTeamsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTeams.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTeams.Response>> Get()
            => await _mediator.Send(new GetTeams.Request());

        [HttpPost(Name = "CreateTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTeam.Response>> Create([FromBody] CreateTeam.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetTeamsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTeamsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTeamsPage.Response>> Page([FromRoute] GetTeamsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTeam.Response>> Update([FromBody] UpdateTeam.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{teamId}", Name = "RemoveTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTeam.Response>> Remove([FromRoute] RemoveTeam.Request request)
            => await _mediator.Send(request);

    }
}
