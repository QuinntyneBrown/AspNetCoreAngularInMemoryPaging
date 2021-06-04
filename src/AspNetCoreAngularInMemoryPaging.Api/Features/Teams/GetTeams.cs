using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AspNetCoreAngularInMemoryPaging.Api.Core;
using AspNetCoreAngularInMemoryPaging.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngularInMemoryPaging.Api.Features
{
    public class GetTeams
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<TeamDto> Teams { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAspNetCoreAngularInMemoryPagingDbContext _context;

            public Handler(IAspNetCoreAngularInMemoryPagingDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    Teams = await _context.Teams.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
