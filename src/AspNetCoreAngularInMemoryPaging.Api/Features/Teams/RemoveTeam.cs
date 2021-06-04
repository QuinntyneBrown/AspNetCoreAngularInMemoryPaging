using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using AspNetCoreAngularInMemoryPaging.Api.Models;
using AspNetCoreAngularInMemoryPaging.Api.Core;
using AspNetCoreAngularInMemoryPaging.Api.Interfaces;

namespace AspNetCoreAngularInMemoryPaging.Api.Features
{
    public class RemoveTeam
    {
        public class Request : IRequest<Response>
        {
            public Guid TeamId { get; set; }
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
                var team = await _context.Teams.SingleAsync(x => x.TeamId == request.TeamId);

                _context.Teams.Remove(team);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Team = team.ToDto()
                };
            }

        }
    }
}
