using System.Net;
using System.Threading.Tasks;
using AspNetCoreAngularInMemoryPaging.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAngularInMemoryPaging.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{playerId}", Name = "GetPlayerByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlayerById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlayerById.Response>> GetById([FromRoute]GetPlayerById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Player == null)
            {
                return new NotFoundObjectResult(request.PlayerId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetPlayersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlayers.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlayers.Response>> Get()
            => await _mediator.Send(new GetPlayers.Request());
        
        [HttpPost(Name = "CreatePlayerRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreatePlayer.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePlayer.Response>> Create([FromBody]CreatePlayer.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetPlayersPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlayersPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlayersPage.Response>> Page([FromRoute]GetPlayersPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdatePlayerRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdatePlayer.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdatePlayer.Response>> Update([FromBody]UpdatePlayer.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{playerId}", Name = "RemovePlayerRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemovePlayer.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemovePlayer.Response>> Remove([FromRoute]RemovePlayer.Request request)
            => await _mediator.Send(request);
        
    }
}
