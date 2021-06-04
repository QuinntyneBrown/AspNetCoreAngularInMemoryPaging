using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreAngularInMemoryPaging.Api.Models;
using AspNetCoreAngularInMemoryPaging.Api.Core;
using AspNetCoreAngularInMemoryPaging.Api.Interfaces;

namespace AspNetCoreAngularInMemoryPaging.Api.Features
{
    public class CreateTeam
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
                var team = new Team(request.Team.City, request.Team.Name);

                _context.Teams.Add(team);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Team = team.ToDto()
                };
            }

        }
    }
}
