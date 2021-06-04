using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreAngularInMemoryPaging.Api.Core;
using AspNetCoreAngularInMemoryPaging.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngularInMemoryPaging.Api.Features
{
    public class UpdateTeam
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Team).NotNull();
                RuleFor(request => request.Team).SetValidator(new TeamValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public TeamDto Team { get; set; }
        }

        public class Response : ResponseBase
        {
            public TeamDto Team { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAspNetCoreAngularInMemoryPagingDbContext _context;

            public Handler(IAspNetCoreAngularInMemoryPagingDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var team = await _context.Teams.SingleAsync(x => x.TeamId == request.Team.TeamId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Team = team.ToDto()
                };
            }

        }
    }
}
