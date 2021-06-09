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
    public class GetPlayers
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<PlayerDto> Players { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAspNetCoreAngularInMemoryPagingDbContext _context;
        
            public Handler(IAspNetCoreAngularInMemoryPagingDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Players = await _context.Players.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
